using System;
using System.Linq;
using System.Reflection;
using CloudCore.Core.ModuleActions;
using CloudCore.Core.Modules;
using CloudCore.Domain;
using Environment = CloudCore.Core.Modules.Environment;

namespace CloudCore.Core.Menu
{
    public class MenuRoot : ModuleFolder
    {
        public readonly MenuRoot Root;
        public MenuRoot(CloudCoreModule module)
        {
            ActionGuid = Guid.Empty;
            ParentFolderGuid = Guid.Empty;
            ActionTitle = "Menu Options";
            SystemModule = module;
            Environment.LoadedModuleActions.AddAction(this);
            Root = this;
        }

        public void AddSystemAction(string actionGuid, SystemActionType actionType, string actionTitle, string controller, string action)
        {
            ValidateDuplication(Guid.Parse(actionGuid));

            string callingAssemblyName = Assembly.GetCallingAssembly().FullName;
            var module = Environment.LoadedModules.SingleOrDefault(
                m => m.AssemblyName == callingAssemblyName);

            var systemAction = new ModuleAction()
            {
                ActionGuid = Guid.Parse(actionGuid),
                ActionType = actionType,
                ActionTitle = actionTitle,
                Area = module == null ? string.Empty : FindConfigInModule(module).GetAreaName(),
                Controller = controller,
                Action = action,
                IsMenuItem = false,
                SystemModule = module
            };

            Environment.LoadedModuleActions.AddAction(systemAction);
        }

        internal static void AddModuleActions(CloudCoreModule module, IModuleConfiguration moduleConfiguration)
        {
            var moduleRoot = GetModuleRoot(module, moduleConfiguration);
            moduleConfiguration.LoadModuleActions(moduleRoot as MenuRoot);
        }
            
        private static ModuleAction GetModuleRoot(CloudCoreModule module, IModuleConfiguration moduleConfiguration)
        {
            return Environment.LoadedModuleActions.GetRoot() ??
                   CreateNewModuleRoot(module, moduleConfiguration);
        }

        private static ModuleAction CreateNewModuleRoot(CloudCoreModule module, IModuleConfiguration moduleConfiguration)
        {
            var moduleRoot = new MenuRoot(module);
            return moduleRoot;
        }
    }
}
