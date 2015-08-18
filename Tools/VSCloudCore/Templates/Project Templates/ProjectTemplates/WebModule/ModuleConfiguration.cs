using CloudCore.Core.Modules;

namespace $safeprojectname$.Areas.$webmodule.areaname$
{
    public class $safeprojectname$ModuleConfiguration : IModuleConfiguration
    {
        public override void LoadModuleActions(ModuleRoot root)
        {
            /* WARNING: All Guid values must be specified as constants - do not call "new Guid()" functions */

            /* Add administration menu folders */
            var $webmodule.areaname$Folder     = this.AddMenuFolder("$guid1$", rootFolder, "$webmodule.areaname$");

            /* Add system actions that appear on the menu structure */
            //$webmodule.areaname$Folder.AddMenuAction("8FFC48CB-236A-4D68-B1B9-7AC2B4B91462", SystemActionType.Search, "Sample Title", "SampleController", "SampleAction");

            /* Add system actions that do not appear on the menu but need to be managed by access rights */
            //root.AddSystemAction("46785E92-FDCC-43AF-8BC2-1B59082B2C4C", SystemActionType.Details, "Sample Details", "SampleController", "SampleAction2");
        }
        
        public string GetAreaName()
        {
            return "$webmodule.areaname$";
        }
    }

}