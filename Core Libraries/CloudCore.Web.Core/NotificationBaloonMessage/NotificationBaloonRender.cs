using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CloudCore.Web.Core.Notifications
{
    public class NotificationBaloonRender
    {
        private readonly NotificationBaloonMessage notification;

        public NotificationBaloonRender(NotificationBaloonMessage notification)
        {
            if (notification == null)
                throw new ArgumentNullException("notification", @"Argument value for parameter ""notification"" cannot be null.");

            this.notification = notification;
        }

        public MvcHtmlString Render(bool isPopUp = false)
        {
            return new MvcHtmlString(string.Format("{0}{1}",
                GenerateShowNotificationJavascript(isPopUp),
                Render_Wireframe()));
        }

        private string GenerateShowNotificationJavascript(bool isPopUp)
        {
            var title = GetTitle();
            var callNotify = string.Format(@"{0}Show{1}('{2}', '{3}');", isPopUp ? "parent." : string.Empty,
                                        notification.NotificationType,
                                        GetSafeMessage(),
                                        title);

            return string.Format(@"<script type=""text/javascript"">" +
                                                "$(document).ready(function () {" +
                                                @"{{0}}" +
                                                @"});</script>", callNotify);
        }

        private string GetTitle()
        {
            return string.IsNullOrEmpty(notification.Title)
                ? notification.NotificationType.ToString()
                : notification.Title;
        }

        private string GetSafeMessage()
        {
            return notification.Message.Replace(@"\r\n", " - ")
                .Replace(@"\", @"\\")
                .Replace("'", @"\'")
                .Replace(";", @"")
                .Replace("\r\n", @"<br />");
        }

        private string Render_Wireframe()
        {
            return @"<div id=""cError"" class=""notifyBase gradient"" style=""display:none;"">" + Environment.NewLine +
                                            @"<div class=""notifyImg"">&nbsp;</div>" +
                                            @"<div class=""text""><span class=""title""></span><br>" + Environment.NewLine +
                                            @"<span class=""notificationMessageContent""></span></div>" + Environment.NewLine +
                                            @"<div class=""clickClose"">&nbsp;</div>" + Environment.NewLine +
                                            @"</div>";
        }
    }
}
