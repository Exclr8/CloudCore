using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Practices.Unity;
using CloudCore.Domain.Workflow;
using System.Collections.Generic;
using CloudCore.Logging;

namespace CloudCore.Core.Modules
{
    public abstract class CloudCoreModule : ICloudCoreModule
    {
        protected CloudCoreModule() { }

        protected CloudCoreModule(string defaultNamespace, CloudCoreModuleType moduleType, Assembly assembly)
        {
            Initialize(defaultNamespace, moduleType, assembly);
        }

        private void Initialize(string defaultNamespace, CloudCoreModuleType moduleType, Assembly assembly)
        {
            ValidateArguments(defaultNamespace, assembly);
            SetProperties(defaultNamespace, moduleType, assembly);
        }

        private void SetProperties(string defaultNamespace, CloudCoreModuleType moduleType, Assembly assembly)
        {
            UniqueModuleId = GetUniqueId(assembly);
            Version = assembly.GetName().Version.ToString();
            LastWriteTime = File.GetLastWriteTime(assembly.Location);
            Assembly = assembly;
            DefaultNamespace = defaultNamespace;
            ModuleType = moduleType;
            ModuleIndex = 0;
        }

        private static void ValidateArguments(string defaultNamespace, Assembly assembly)
        {
            // TODO: Also check default name space against regular expression to only allow proper namespace notation and characters
            if (String.IsNullOrWhiteSpace(defaultNamespace))
                throw new ArgumentOutOfRangeException("defaultNamespace");

            if (assembly == null)
                throw new ArgumentNullException("assembly");
        }

        private Guid GetUniqueId(Assembly assembly)
        {
            var guidAttribute = (GuidAttribute) assembly.GetCustomAttributes(typeof (GuidAttribute), true)[0];
            return Guid.Parse(guidAttribute.Value);
        }

        public Guid UniqueModuleId { get; private set; }
        public string DefaultNamespace { get; set; }
        public CloudCoreModuleType ModuleType { get; set; }
        public Assembly Assembly { get; set; }
        public DateTime LastWriteTime { get; private set; }
        public int ModuleIndex { get; set; }
        public int SystemModuleIdOnDatbase { get; set; }
        public string Version { get; private set; }
        public string AssemblyName { get { return Assembly.FullName; } }
        public int ModuleTypeId { get { return (int)ModuleType; } }
        public virtual void OnRegister() { }

        public virtual void AdditionalIoCConfiguration(IUnityContainer container) { }
		
		public virtual IEnumerable<ITaskListQuery> GetCustomQueryList()
        { 
            return new List<ITaskListQuery>();
        }

        public IModuleConfiguration ActionsConfiguration()
        {
            try
            {
                var configurations = (from a in Assembly.GetTypes()
                                      where a.IsClass && !a.IsAbstract && a.GetInterfaces().Contains(typeof(IModuleConfiguration))
                                      select a).ToList();

                if (configurations.Count > 1)
                {
                    throw new ModuleLoadException(
                        "Cannot load module configuration, because the module has more than one type of IModuleConfiguration inside it.");
                }

                if (configurations.Count > 0)
                {
                    var configType = configurations.First();
                    var configuration = (Activator.CreateInstance(configType) as IModuleConfiguration);
                    return configuration;
                }

            }
            catch (ReflectionTypeLoadException ex)
            {
                foreach (var x in ex.LoaderExceptions)
                {
                    Logger.Error(string.Format("Unable to examine assembly \"{0}\" for types of IModuleConfiguration.", AssemblyName), x);
                }

                throw;
            }

            return null;
        }
    }
}
