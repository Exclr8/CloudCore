using System;
using System.Linq;
using System.Reflection;
using CloudCore.Core.ModuleActions;
using CloudCore.Domain;
using Environment = CloudCore.Core.Modules.Environment;

namespace CloudCore.Core.Menu
{
    public class ModuleFolder : ModuleAction
    {
        public ModuleFolder()
        {
            IsFolder = true;
            IsNew = true;
            Controller = string.Empty;
            Action = string.Empty;
        }

        public ModuleFolder AddMenuFolder(string actionGuid, string folderName)
        {
            ValidateDuplication(Guid.Parse(actionGuid));

            var callingAssemblyName = Assembly.GetCallingAssembly().FullName;
            var module = Environment.LoadedModules.SingleOrDefault(m => m.AssemblyName == callingAssemblyName);

            var menuFolder = new ModuleFolder()
            {
                ActionGuid = Guid.Parse(actionGuid),
                ParentFolderGuid = this.ActionGuid,
                ActionTitle = folderName,
                IsMenuItem = true,
                Area = module == null ? string.Empty : FindConfigInModule(module).GetAreaName(),
                SystemModule = module
            };

            Environment.LoadedModuleActions.AddAction(menuFolder);
            return menuFolder;
        }

        public ModuleAction AddMenuAction(string actionGuid, SystemActionType actionType, string actionTitle, string controller, string action)
        {
            ValidateDuplication(Guid.Parse(actionGuid));

            string callingAssemblyName = Assembly.GetCallingAssembly().FullName;
            var module = Environment.LoadedModules.SingleOrDefault(
                m => m.AssemblyName == callingAssemblyName);

            var menuAction = new ModuleAction()
            {
                ActionGuid = Guid.Parse(actionGuid),
                ParentFolderGuid = this.ActionGuid,
                ActionType = actionType,
                ActionTitle = actionTitle,
                Area = module == null ? string.Empty : FindConfigInModule(module).GetAreaName(),
                Controller = controller,
                Action = action,
                IsMenuItem = true,
                SystemModule = module
            };

            Environment.LoadedModuleActions.AddAction(menuAction);
            return menuAction;
        }
    }
}