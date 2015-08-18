using System.Web.Mvc;
using CloudCore.Web.Core.Notifications;

namespace CloudCore.Web.Core.BaseViews.Master
{
    public abstract class CoreMaster<T> : WebViewPage<T>
    {
        public override void ExecutePageHierarchy()
        {
            base.ExecutePageHierarchy();
            RenderNotification();
        }

        protected void RenderNotification()
        {
            var notification = NotificationBaloonMessage.Get(TempData);

            if (notification == null)
                return;

            var notificationRenderer = new NotificationBaloonRender(notification);
            WriteLiteral(notificationRenderer.Render());
        }
    }
}