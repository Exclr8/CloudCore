using System;
using System.Web.Mvc;
using CloudCore.Web.Core.BaseViews.Master;

namespace Web.Core.Tests.Notifications
{
    public class CoreMasterMock : CoreMaster<object>
    {
        public bool WriteLiteralHasBeenCalled = false;

        public override void WriteLiteral(object value)
        {
            WriteLiteralHasBeenCalled = true;
        }

        public void RenderNotificationTest(Controller controller)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.TextWriter tw = new System.IO.StringWriter(sb);
            ViewContext = new ViewContext(controller.ControllerContext, new FakeView(), new ViewDataDictionary(), controller.TempData, tw);
            RenderNotification();
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}