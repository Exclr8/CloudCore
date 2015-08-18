using System;
using System.Linq;
using System.Collections.Generic;
using System.IdentityModel.Services;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using CloudCore.Configuration.ConfigFile;
using CloudCore.Core.Data;
using CloudCore.Core.DependencyResolution;
using CloudCore.Core.Hosting.VirtualFiles;
using CloudCore.Core.Logging;
using CloudCore.Core.Modules;
using CloudCore.Logging;
using CloudCore.Web.Core.Api.Documentation;
using CloudCore.Web.Core.Configuration;
using CloudCore.Web.Core.Modules;
using Microsoft.Practices.Unity.Mvc;
using Environment = CloudCore.Core.Modules.Environment;
using CloudCore.Domain.Security;
using System.Web.Optimization;
using CloudCore.Core.TaskList;
using CloudCore.Core.TaskList.Standard;
using CloudCore.Domain.Workflow;
using CloudCore.Data;
using CloudCore.Web.Core.MvcFilters;

namespace CloudCore.Web.Core
{
    public abstract class WebApplication : HttpApplication, IModuleHost
    {
        private readonly static CloudCoreResourcePathProvider<EmbeddedResourceVirtualFile> virtualPathProvider = new CloudCoreResourcePathProvider<EmbeddedResourceVirtualFile>();
        public static CloudCoreResourcePathProvider<EmbeddedResourceVirtualFile> VirtualPathProvider
        {
            get { return virtualPathProvider; }
        }

        protected WebApplication()
        {
            ConfigureLogging();
        }

        private void ConfigureLogging()
        {
            Logger.SetLogger(GetLogger(), Configuration.Logging.VerbosityLevel);
        }

        protected virtual ILogger GetLogger()
        {
            return new TraceLogger();
        }

        protected void Application_BeginRequest()
        {
            CultureConfig.RegisterCulture();
            HandleOfflineStatus();
            Begin_Request();
        }

        protected void Application_EndRequest()
        {
            End_Request();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            var httpException = exception as HttpException;

            if (httpException != null)
            {
                string logRefId = GenerateNewLogRefId();

                string action;

                switch (httpException.GetHttpCode())
                {
                    case 404:
                        action = "NotFound";
                        Logger.Warn(String.Format(@"Log Reference #{0} - Unknown {1} request: {2}", logRefId, Request.HttpMethod, Request.RawUrl), "Web Application Warning");
                        break;
                    default:
                        action = "GenericError";
                        Logger.Error(String.Format(@"Log Reference #{0} - Web Application Error: {0}. Stack trace: {1}", logRefId, exception.Message, exception.StackTrace), exception, "Web Application Error");
                        break;
                }

                if (string.IsNullOrWhiteSpace(action))
                {
                    Response.Clear();
                    Server.ClearError();
                    Response.Redirect(String.Format("~/CUI/Error/{0}/?logRefId={1}&message={2}", logRefId, action));
                }
            }
            else
            {
                var cryptoException = exception as CryptographicException;

                if (cryptoException != null)
                {
                    Logger.Warn(String.Format(@"Warning: Decryption Error encountered (Possible reasons: Invalid cookie, New private keys in configuration). {0}. Details: {1}", exception.Message, exception.StackTrace), "Web Application");
                    FederatedAuthentication.SessionAuthenticationModule.SignOut();
                    Server.ClearError();
                    return;
                }

                Logger.Error(String.Format(@"Web Application Error: {0}. Stack trace: {1}", exception.Message, exception.StackTrace), exception, "Web Application Error");
            }
        }

        /// <summary>
        /// Plug into Application_BeginRequest
        /// </summary>
        protected virtual void Begin_Request()
        {
        }

        /// <summary>
        /// Plug into Application_EndRequest
        /// </summary>
        protected virtual void End_Request()
        {
        }
        
        /// <summary>
        /// Register additional bundles.
        /// </summary>
        /// <param name="additionalBundles"></param>
        protected virtual void OnBundleRegistering(BundleCollection additionalBundles)
        {
        }

        /// <summary>
        /// Register aditional global filters.
        /// </summary>
        /// <param name="additionalFilters"></param>
        protected virtual void OnGlobalFilterRegistering(GlobalFilterCollection additionalFilters)
        {
        }

        protected void SessionAuthenticationModule_SessionSecurityTokenReceived(object sender, SessionSecurityTokenReceivedEventArgs e)
        {
            var now = DateTime.UtcNow;
            var validFrom = e.SessionToken.ValidFrom;
            var validTo = e.SessionToken.ValidTo;
            var sessionLifetime = validTo.Subtract(e.SessionToken.ValidFrom);

            var sessionTimeHasExpired = now > validTo;
            var sessionTimeIsHalfExpired = now > validFrom.AddMinutes(sessionLifetime.TotalMinutes / 2);

            // http://www.michael-mckenna.com/Blog/2013/2/the-problem-with-absolute-token-expiration-in-windows-identity-foundation-wif
            if (!sessionTimeHasExpired && sessionTimeIsHalfExpired)
            {
                // If the session has not expired but the session lifetime is already half spent, reissue the cookie. 
                e.SessionToken = (sender as SessionAuthenticationModule).CreateSessionSecurityToken(e.SessionToken.ClaimsPrincipal, e.SessionToken.Context,
                now, now.AddMinutes(sessionLifetime.TotalMinutes), e.SessionToken.IsPersistent);
                e.ReissueCookie = true;
            }
        }

        private void HandleOfflineStatus()
        {
            //Refactor once it is possible to use controller instead of hard links.
            if (ShouldShowOffline)
            {
                if (Request.Path.StartsWith("/api/"))
                    WriteApiErrorResponse();
                else
                    Response.Redirect("~/CUI/Offline/");
            }
        }

        private void WriteApiErrorResponse()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            Response.ContentType = "text/plain";
            Response.Write("Offline");

            Response.TrySkipIisCustomErrors = true;
        }

        private bool ShouldShowOffline
        {
            get
            {
                var isOffline = AppSettings.GetConfiguration("Offline", "false").ToLower() == "true";

                return isOffline &&
                       !Request.Path.StartsWith("/CUI/Offline/") &&
                       !Request.Path.StartsWith("/Core/Asset/");
            }
        }

        protected void Application_Start()
        {
            LogAppStart();
            InitializeIoC();
            SetAuthenticationCookieHandler();
            ProtectApplicationConfigurationSection();
            LoadModules();
            RegisterAreas();
            RegisterBundles();
            RegisterGlobalFilters();
            RegisterDefaultRoutes();
            RegisterViewEngine();
            LogAppStarted();
        }

        private void InitializeIoC()
        {
            Logger.Info("Initializing Inversion of Control...");
            IoC.Initialize();
        }

        private void LogAppStart()
        {
            Logger.Info(
                string.Format("Web Application \"{0}\", version {1}, is starting...",
                    ReadConfig.SettingsOnWebApplication.WebSettings.SiteName,
                    ReadConfig.SettingsOnWebApplication.WebSettings.SiteVersion), LogCategories.WebAppInitialize,
                ignoreVerbosityConfig: true);
        }

        private void SetAuthenticationCookieHandler()
        {
            FederatedAuthentication.FederationConfiguration.CookieHandler.Name =
                Hash.Calculate(Configuration.WebSettings.SiteName);
        }

        private void ProtectApplicationConfigurationSection()
        {
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpRuntime.AppDomainAppVirtualPath);
            var section = Configuration;

            if (section == null)
            {
                throw new InvalidOperationException("Could not find a valid \"cloudCore\" section in the \"web.config\" file of the web application.");
            }

            if (section.Encrypted && !section.SectionInformation.IsProtected)
            {
                section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
                config.Save();
            }
        }

        private void LoadModules()
        {
            Logger.Info("Loading Modules...", LogCategories.AppInit, ignoreVerbosityConfig: true);
            CloudCore.Core.Modules.Environment.InitializeModuleHost(this);
        }

        private void RegisterAreas()
        {
            Logger.Info("Registering Web Areas...", LogCategories.WebAppInitialize, ignoreVerbosityConfig: true);
            RegisterAPIDocumentationCustomObjectSamples(CustomSamples.CustomObjectSamples);
            AreaRegistration.RegisterAllAreas();
        }

        private void RegisterBundles()
        {
            Logger.Info("Registering Bundles...", LogCategories.WebAppInitialize, ignoreVerbosityConfig: true);
            
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            OnBundleRegistering(BundleTable.Bundles);
        }

        private void RegisterGlobalFilters()
        {
            Logger.Info("Registering Global Filters...", LogCategories.WebAppInitialize, ignoreVerbosityConfig: true);
            OnGlobalFilterRegistering(GlobalFilters.Filters);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        private void RegisterDefaultRoutes()
        {
            Logger.Info("Registering Default Routes...", LogCategories.WebAppInitialize, ignoreVerbosityConfig: true);
            RouteConfig.RegisterDefaultRoutes(RouteTable.Routes, Configuration);
        }

        private void RegisterViewEngine()
        {
            Logger.Info("Registering View Engines...", LogCategories.WebAppInitialize, ignoreVerbosityConfig: true);
            ViewEngineConfig.RegisterViewEngine();
        }

        private void LogAppStarted()
        {
            Logger.Info(
                string.Format("Web Application \"{0}\", version {1}, has started. Awaiting requests.",
                    ReadConfig.SettingsOnWebApplication.WebSettings.SiteName,
                    ReadConfig.SettingsOnWebApplication.WebSettings.SiteVersion), LogCategories.WebAppInitialize,
                ignoreVerbosityConfig: true);
        }

        private string GenerateNewLogRefId()
        {
            var logRefIdBytes = new byte[3];
            var random = new Random();
            random.NextBytes(logRefIdBytes);
            var logRefId = string.Empty;
            logRefIdBytes.ToList().ForEach(chr => logRefId += chr.ToString("x2"));
            return DateTime.UtcNow.ToString("yyyyMMdd") + logRefId;
        }

        public static CloudCoreWebSection Configuration
        {
            get
            {
                return ReadConfig.SettingsOnWebApplication;
            }
        }

        protected abstract IEnumerable<CloudCoreModule> RegisterWebModules();

        public virtual void RegisterAPIDocumentationCustomObjectSamples(Dictionary<Type, object> customObjectSamples)
        {
            Logger.Info("Registering API Documentation...", LogCategories.WebAppInitialize, ignoreVerbosityConfig: true);
        }

        List<CloudCoreModule> IModuleHost.RegisterModules()
        {
            var modulesToLoad = GetCoreModules();
            modulesToLoad.AddRange(RegisterWebModules());
            return modulesToLoad;
        }

        private List<CloudCoreModule> GetCoreModules()
        {
            var modulesToLoad = new List<CloudCoreModule>
            {
                new CloudCoreDataModule(),
                new CoreCommonModule(),
                new CoreWebModule()
            };
            return modulesToLoad;
        }

        private void EnumerateStandardTaskLists()
        {
            var standardTaskLists = new List<ITaskListQuery> 
                                    {
                                        new AllTaskQuery(),
                                        new AllActiveTaskQuery(),
                                        new OfferedTaskQuery(),
                                        new AllocatedTaskQuery(),
                                        new StartedTaskQuery(),
                                        new SuspendedTaskQuery()
                                    };

            TaskListQueryList.StandardTaskList = standardTaskLists.ToArray();
        }

        private void EnumerateModuleCustomTaskLists(CloudCoreModule module)
        {
            var customQueries = TaskListQueryList.CustomQueryList as List<ITaskListQuery>;
            customQueries.AddRange(module.GetCustomQueryList());
        }

        private void SetResolver()
        {
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(IoC.Container));
            DependencyResolver.SetResolver(new UnityDependencyResolver(IoC.Container));
        }

        void IModuleHost.OnAllModulesRegistered(List<CloudCoreModule> loadedModules)
        {
            Logger.Info("Processing Module Embedded Resources...", LogCategories.AppInit, ignoreVerbosityConfig: true);
            HostingEnvironment.RegisterVirtualPathProvider(VirtualPathProvider);

            EnumerateStandardTaskLists();

            foreach (var module in loadedModules)
            {
                if (module.ModuleType == CloudCoreModuleType.Web)
                {
                    SetResolver();
                }

                IoC.AdditionalConfiguration(module);
                

                EnumerateModuleCustomTaskLists(module);   
            }
        }
    }
}
