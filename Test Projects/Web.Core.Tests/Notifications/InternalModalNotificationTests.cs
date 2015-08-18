using System;
using System.Web.Mvc;
using CloudCore.Web.Core.BaseControllers;
using CloudCore.Web.Core.Notifications;
using Frameworkone.UnitTestUtilities.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Core.Tests.Notifications
{
    [TestClass]
    public class InternalModalNotificationTests : BaseControllerTest<CoreController>
    {
        private const string Message = "Message";
        private const string Title = "Title";

        [TestMethod]
        public void CanRenderNotification()
        {
            Controller.ShowSuccessMessage("Message", "Title");
            AssertResult(RenderNotification());
        }

        private void AssertResult(string result)
        {
            Assert.AreEqual(string.Format("<script type=\"text/javascript\">$(document).ready(function () {{ShowSuccess('{0}', '{1}');}});</script><div id=\"cError\" class=\"notifyBase gradient\" style=\"display:none;\">\r\n<div class=\"notifyImg\">&nbsp;</div><div class=\"text\"><span class=\"title\"></span><br>\r\n<span class=\"content\"></span></div>\r\n<div class=\"clickClose\">&nbsp;</div>\r\n</div>", Message, Title)
                , result);
        }

        private string RenderNotification()
        {
            var notification = NotificationBaloonMessage.Get(Controller.TempData);
            var renderer = new NotificationBaloonRender(notification);
            return renderer.Render().ToString();

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NotificationRenderer_ConstructWithNullArgument_ExceptionThrown()
        {
            var fail = new NotificationBaloonRender(null);
        }

        [TestMethod]
        public void CoreMaster_No_Notification_DoesNotWriteNotificationRendering()
        {
            var masterView = CreateCoreMaster();
            masterView.RenderNotificationTest(Controller);
            Assert.IsFalse(masterView.WriteLiteralHasBeenCalled);
        }

        [TestMethod]
        public void CoreMaster_ControllerShowMessage_ViewWritesNotificationRendering()
        {
            Controller.ShowSuccessMessage("Message", "Title");
            var masterView = CreateCoreMaster();
            masterView.RenderNotificationTest(Controller);
            Assert.IsTrue(masterView.WriteLiteralHasBeenCalled);
        }

        private CoreMasterMock CreateCoreMaster()
        {
            var masterView = new CoreMasterMock();
            masterView.Context = Controller.HttpContext;
            return masterView;
        }
    }

    public class FakeView : IView
    {
        public void Render(ViewContext viewContext, System.IO.TextWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
