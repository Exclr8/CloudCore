using CloudCore.Core.Logging;
using CloudCore.Core.Menu;
using CloudCore.Data;
using CloudCore.Domain;
using CloudCore.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CloudCore.Core.Modules
{
    public class ModuleHostRegistrar
    {
        private IModuleHost moduleHost;

        private List<CloudCoreModule> modules;

        public ModuleHostRegistrar(IModuleHost moduleHost)
        {
            this.moduleHost = moduleHost;
        }

        public void Register()
        {
            modules = moduleHost.RegisterModules();

            foreach (var module in modules)
            {
                var service = new ModuleRegistrationService(module);
                service.Execute();
            }

            moduleHost.OnAllModulesRegistered(modules);
        }       
    }

    public class ModuleRegistrationService
    {
        private CloudCoreModule module;

        public ModuleRegistrationService(CloudCoreModule module)
        {
            this.module = module;
        }

        public void Execute()
        {
            RegisterModule(module);
            module.OnRegister();
        }

        private void RegisterModule(CloudCoreModule module)
        {
            var moduleAlreadyLoaded = Environment.LoadedModules.FirstOrDefault(r => r.UniqueModuleId == module.UniqueModuleId) != null;

            if (moduleAlreadyLoaded)
            {
                Logger.Warn(
                    string.Format(
                        "A CloudCore-based assembly with unique GUID {0} has already been registered. Module load for '{1}' will be ignored.",
                        module.UniqueModuleId,
                        module.AssemblyName),
                    LogCategories.AppInit,
                    ignoreVerbosityConfig: true);
            }
            else
            {
                try
                {
                    RegisterModuleInDatabase(module);

                    //Has to be added to Environment.LoadedModules before RegisterModuleActions
                    //RegisterModuleActions will try to access module from Environment.LoadedModules
                    Environment.LoadedModules.Add(module);
                    module.ModuleIndex = Environment.LoadedModules.IndexOf(module);

                    RegisterModuleActions(module);
                }
                catch (Exception ex)
                {
                    if (module.ModuleType == CloudCoreModuleType.Core || module.ModuleType == CloudCoreModuleType.Assets)
                        throw new Exception(
                            string.Format(
                                "Terminating application by reason of module LOAD FAILED for {0}. Please refer to the logs for more information.",
                                module.AssemblyName), ex);
                    else
                        throw;
                }
            }
        }

        private void RegisterModuleInDatabase(CloudCoreModule module)
        {
            var systemModule = new SystemModule
            {
                SystemModuleId = 0,
                AssemblyName = module.AssemblyName,
                SystemModuleGuid = module.UniqueModuleId
            };

            int? systemModuleId = null;
            CloudCoreDB.Context.Cloudcore_SystemModuleUpload(module.AssemblyName, module.UniqueModuleId, ref systemModuleId);

            //The bottom statement should always be true, I cannot see why the Exception would ever be thrown...
            //if (systemModuleId.GetValueOrDefault(0) > 0)
            module.SystemModuleIdOnDatbase = systemModuleId.Value;
            //else
            //    throw new Exception("Could not register the CloudCore module \"" + module.AssemblyName +
            //                        "\" in the database. Reason unknown.");
        }

        private void RegisterModuleActions(CloudCoreModule module)
        {
            var configuration = module.ActionsConfiguration();

            if (configuration != null)
                MenuRoot.AddModuleActions(module, configuration);
        }
    }
}
