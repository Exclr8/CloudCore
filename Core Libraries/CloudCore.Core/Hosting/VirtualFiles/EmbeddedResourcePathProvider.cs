using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;
using CloudCore.Core.Logging;
using CloudCore.Core.Modules;
using CloudCore.Logging;
using Environment = CloudCore.Core.Modules.Environment;

namespace CloudCore.Core.Hosting.VirtualFiles
{
    public class CloudCoreResourcePathProvider<T> : VirtualPathProvider where T : CloudCoreVirtualFile
    {
        public const string ConfigKeyAllowOverrides =
            "CloudCore.Web.Core.Hosting.EmbeddedResourcePathProvider.AllowOverrides";

        public virtual bool AllowOverrides
        {
            get
            {
                string toParse = ConfigurationManager.AppSettings[ConfigKeyAllowOverrides];

                if (String.IsNullOrEmpty(toParse))
                    return false;

                bool retVal;
                bool.TryParse(toParse, out retVal);
                return retVal;
            }
        }

        public override bool FileExists(string virtualPath)
        {
            if (virtualPath == null)
            {
                throw new ArgumentNullException("virtualPath");
            }
            if (virtualPath.Length == 0)
            {
                throw new ArgumentOutOfRangeException("virtualPath");
            }

            string absolutePath = VirtualPathUtility.ToAbsolute(virtualPath);
                // new code: virtualPath.Replace("~", /*HttpContext.Current*/Context.Request.Url.Host);

            if (VirtualFileBaseCollection.Files.Contains(absolutePath))
            {
                return true;
            }

            return base.FileExists(absolutePath);
        }

        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies,
            DateTime utcStart)
        {
            if (virtualPath == null)
            {
                throw new ArgumentNullException("virtualPath");
            }
            if (virtualPath.Length == 0)
            {
                throw new ArgumentOutOfRangeException("virtualPath");
            }
            string absolutePath = VirtualPathUtility.ToAbsolute(virtualPath);

            AggregateCacheDependency retVal = null;

            if (virtualPathDependencies != null)
            {
                foreach (string virtualPathDependency in virtualPathDependencies)
                {
                    using (CacheDependency dependencyToAdd = GetCacheDependency(virtualPathDependency, null, utcStart))
                    {
                        if (dependencyToAdd == null)
                        {
                            continue;
                        }

                        if (retVal == null)
                        {
                            retVal = new AggregateCacheDependency();
                        }
                        retVal.Add(dependencyToAdd);
                    }
                }
            }

            using (
                CacheDependency primaryDependency = (FileHandledByBaseProvider(absolutePath)
                    ? (base.GetCacheDependency(absolutePath, null, utcStart))
                    : (new CacheDependency(VirtualFileBaseCollection.Files[absolutePath].Module.Assembly.Location,
                        utcStart))))
            {
                if (primaryDependency != null)
                {
                    if (retVal == null)
                    {
                        retVal = new AggregateCacheDependency();
                    }
                    retVal.Add(primaryDependency);
                }
            }
            return retVal;
        }

        public override VirtualFile GetFile(string virtualPath)
        {
            if (virtualPath == null)
            {
                throw new ArgumentNullException("virtualPath");
            }
            if (virtualPath.Length == 0)
            {
                throw new ArgumentOutOfRangeException("virtualPath");
            }

            string absolutePath = VirtualPathUtility.ToAbsolute(virtualPath);
            if (FileHandledByBaseProvider(absolutePath))
            {
                return base.GetFile(absolutePath);
            }

            var vFile = (VirtualFile) VirtualFileBaseCollection.Files[absolutePath];
            return vFile;
        }

        protected override void Initialize()
        {
            Logger.Info(string.Format("Initializing {0}", GetType().Name), LogCategories.WebProcessingResources,
                true);
            LoadAllModuleResources();
            base.Initialize();
        }

        public void LoadAllModuleResources()
        {
            foreach (CloudCoreModule item in Environment.LoadedModules)
            {
                Logger.Info(
                    string.Format("Processing embedded resources for module {0}...", item.Assembly.GetName().Name),
                    LogCategories.WebProcessingResources, true);

                if ((item.ModuleType == CloudCoreModuleType.Core) ||
                    (item.ModuleType == CloudCoreModuleType.Assets) ||
                    (item.ModuleType == CloudCoreModuleType.Web))
                {
                    if (string.IsNullOrWhiteSpace(item.DefaultNamespace))
                    {
                        throw new NotSupportedException(
                            "CloudCore-based core modules are required to have a namespace specified.");
                    }

                    ProcessEmbeddedFiles(item);
                }
            }
        }

        private static string MapResourceToWebApplication(string baseNamespace, string resourcePath)
        {
            ValidateResourceParameters(baseNamespace, resourcePath);
            EnsureBaseNamespaceInPath(baseNamespace, resourcePath);
            var newResourcePath = RemoveNamespaceFromPath(baseNamespace, resourcePath);
            var extSeparator = FindLastPeriodIn(newResourcePath);
            var resourceFilePath = ReplaceAllButLastPeriodIn(newResourcePath, extSeparator);
            var retVal = MapResourceToAppRoot(resourceFilePath);
            return retVal;
        }

        private static string MapResourceToAppRoot(string resourceFilePath)
        {
            return VirtualPathUtility.Combine("~/", resourceFilePath);
        }

        private static void ValidateResourceParameters(string baseNamespace, string resourcePath)
        {
            ValidateResourcePath("baseNamespace", baseNamespace);
            ValidateResourcePath("resourcePath", resourcePath);
        }

        private static void EnsureBaseNamespaceInPath(string baseNamespace, string resourcePath)
        {
            if (resourcePath.IndexOf(baseNamespace + ".", StringComparison.Ordinal) != 0)
            {
                throw new InvalidOperationException(
                    "Base resource namespace must appear at the start of the embedded resource path.");
            }
        }

        private static string RemoveNamespaceFromPath(string baseNamespace, string resourcePath)
        {
            string newResourcePath = resourcePath.Remove(0, baseNamespace.Length + 1);
            return newResourcePath;
        }

        private static int FindLastPeriodIn(string newResourcePath)
        {
            int position = newResourcePath.LastIndexOf(".", StringComparison.Ordinal);
            return position;
        }

        private static string ReplaceAllButLastPeriodIn(string newResourcePath, int extSeparator)
        {
            string resourceFilePath = newResourcePath.Substring(0, extSeparator).Replace(".", "/") +
                                      newResourcePath.Substring(extSeparator, newResourcePath.Length - extSeparator);
            return resourceFilePath;
        }

        private static void ValidateResourcePath(string paramName, string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("paramName");
            }
            if (path.Length == 0)
            {
                throw new ArgumentOutOfRangeException("paramName");
            }
            if (path.StartsWith(".") || path.EndsWith("."))
            {
                throw new ArgumentOutOfRangeException(paramName, path,
                    paramName + @" may not start or end with a period.");
            }
            if (path.IndexOf("..", StringComparison.Ordinal) >= 0)
            {
                throw new ArgumentOutOfRangeException(paramName, path,
                    paramName + @" may not contain two or more periods together.");
            }
        }

        private bool FileHandledByBaseProvider(string absolutePath)
        {
            return (AllowOverrides && base.FileExists(absolutePath)) ||
                   !VirtualFileBaseCollection.Files.Contains(absolutePath);
        }

        public static void ProcessEmbeddedFiles(CloudCoreModule module)
        {
            Logger.Info(string.Format("Processing embedded resource {0}...", module.Assembly.GetName().Name),
                LogCategories.WebProcessingResources, true);

            var assemblyResourceNames = new List<string>(module.Assembly.GetManifestResourceNames());
            assemblyResourceNames =
                assemblyResourceNames.Where(r => r.StartsWith(module.DefaultNamespace + ".")).ToList();

            if (assemblyResourceNames.Count == 0)
            {
                return;
            }

            foreach (string resPath in assemblyResourceNames)
            {
                const string warningLogMessageTemplate =
                    @"Could not map Web Application Embedded Resource Path: {0}. Path is invalid.";
                string mappedPath;
                try
                {
                    mappedPath =
                        VirtualPathUtility.ToAbsolute(MapResourceToWebApplication(module.DefaultNamespace, resPath));
                }
                catch
                {
                    Logger.Warn(string.Format(warningLogMessageTemplate, resPath),
                        LogCategories.WebProcessingResources, true);
                    continue;
                }

                var file = Activator.CreateInstance(typeof(T), mappedPath.Replace("-", "_").ToLower(), module, resPath);

                if (VirtualFileBaseCollection.Files.Contains(file))
                {
                    Logger.Warn(
                        string.Format(@"{0}. Resource already exists, duplicate ignored.", string.Format(warningLogMessageTemplate, resPath)),
                        LogCategories.WebProcessingResources, true);
                    continue;
                }

                try
                {
                    VirtualFileBaseCollection.Files.Add((T)file);
                }
                catch
                {
                    Logger.Warn(string.Format(@"{0}. Could not load the resource into memory.", resPath),
                        LogCategories.WebProcessingResources, true);
                }
            }
        }
    }
}
