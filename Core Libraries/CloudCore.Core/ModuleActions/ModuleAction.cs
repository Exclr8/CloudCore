using System;
using System.Linq;
using CloudCore.Core.Modules;
using CloudCore.Domain;
using Environment = CloudCore.Core.Modules.Environment;

namespace CloudCore.Core.ModuleActions
{
    public class ModuleAction
    {
        private const string DuplicateActionErrorFormat = "Could load system action because a duplicate item with the Id (Guid) was already loaded. Guid value: {0}";

        public CloudCoreModule SystemModule { get; set; }
        public int? DatabaseActionId { get; set; }
        public int ListIndex { get; internal set; }
        public bool IsNew { get; set; }
        public bool IsFolder { get; internal set; }
        public bool IsMenuItem { get; set; }
        public Guid ActionGuid { get; set; }
        public Guid? ParentFolderGuid { get; protected internal set; }
        public SystemActionType ActionType { get; set; }
        public string ActionTitle { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public ModuleAction()
        {
            IsNew = true;
            ParentFolderGuid = null;
        }

        protected IModuleConfiguration FindConfigInModule(CloudCoreModule module)
        {
            //return Environment.GetModuleActionsConfiguration(module);
            return module.ActionsConfiguration();
        }

        protected static void ValidateDuplication(Guid actionGuid)
        {
            if (Environment.LoadedModuleActions.HasAction(actionGuid))
                throw new ModuleLoadException(String.Format(DuplicateActionErrorFormat, actionGuid));
        }
    }
}