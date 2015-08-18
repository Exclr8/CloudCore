using CloudCore.Core.Menu;
using CloudCore.Core.Modules;

namespace CloudCore.WebModuleTest.Areas.Test
{
    public class TestModuleConfiguration : IModuleConfiguration
    {
        public void LoadModuleActions(MenuRoot root)
        {
            var testFolder = root.AddMenuFolder("0BAEA491-B78D-485A-A190-3544B4500DAF", "Administration123");

            testFolder.AddMenuAction("0BFEA491-C78A-983A-2180-3544C4500DAD", Domain.SystemActionType.Details,
                "Test Menu Item", "TestController", "TestMenuItem");

        }

        public string GetAreaName()
        {
            return "Test";
        }
    }
}