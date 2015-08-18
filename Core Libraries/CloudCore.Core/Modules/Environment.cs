using CloudCore.Configuration.ConfigFile;
using CloudCore.Core.Logging;
using CloudCore.Core.Menu;
using CloudCore.Core.ModuleActions;
using CloudCore.Data;
using CloudCore.Domain;
using CloudCore.Logging;
using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;

namespace CloudCore.Core.Modules
{
    public static class Environment
    {
        public static readonly ModuleActionList LoadedModuleActions = new ModuleActionList();
        public static List<CloudCoreModule> LoadedModules { get; private set; }

        public static string CoreVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static int ApplicationId { get; private set; }
        
        public static void InitializeModuleHost(IModuleHost moduleHost)
        {
            LoadedModules = new List<CloudCoreModule>();
            AuthenticateHostApplication();
            
            var registrar = new ModuleHostRegistrar(moduleHost);
            registrar.Register();

            SyncAllModuleActions();
        }

        private static void AuthenticateHostApplication()
        {
            const string formatInvalidKeyExceptionMessage = "CloudCore Application Key {0} is invalid. Authentication failed.";
            try
            {
                Guid appGuid;
                var keyFromConfig = ReadConfig.CommonCloudCoreApplicationSettings.Keys.ApplicationKey;

                if (!Guid.TryParse(keyFromConfig, out appGuid))
                    throw new SecurityException(string.Format(formatInvalidKeyExceptionMessage, keyFromConfig));

                var application = CloudCoreDB.Context.Cloudcore_SystemApplication.Where(sa => sa.ApplicationGuid == appGuid).SingleOrDefault();

                if (application == null)
                    throw new SecurityException(string.Format(formatInvalidKeyExceptionMessage, keyFromConfig));

                if (application.Enabled == false)
                    throw new SecurityException(string.Format(formatInvalidKeyExceptionMessage, keyFromConfig));

                DateTime? currentDate = DateTime.Now; 
                ApplicationId = application.ApplicationId;
                CloudCoreDB.Context.Cloudcore_LoginUpdate(0, ApplicationId, ref currentDate);


                Logger.Info( string.Format(@"Application authorized as ""{0}"" instance ""{1} ({2})"".",
                              application.ApplicationName, application.ApplicationId, GetInstanceNumber()),
                          LogCategories.AppInit,
                          ignoreVerbosityConfig: true);
            }
            catch (Exception ex)
            {
                Logger.Fatal(ex.Message, ex, LogCategories.AppInit);
                throw;
            }
        }

        private static void SyncAllModuleActions()
        {
            if (LoadedModuleActions.HasItems())
            {
                ModuleDeployment
                    .Synchronize()
                    .SystemActions();
            }
        }

        private static string GetInstanceNumber()
        {
            if (RoleEnvironment.IsAvailable)
                return RoleEnvironment.CurrentRoleInstance.Id;

            // TODO: Implement!
            return "<Unknown - IaaS>";
        }
    }
}
