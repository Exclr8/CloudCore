using System;
using System.Web;
using System.Web.Mvc;

namespace CloudCore.Web.Core.Notifications
{
    [Serializable]
    public class NotificationBaloonMessage
    {
        public const string NotificationCookieName = "CloudCoreNotification";

        public NotificationBaloonMessage() { }

        public NotificationBaloonMessage(NotificationBaloonType notificationType, string message, string title = "")
        {
            NotificationType = notificationType;
            Message = message;
            Title = title;
        }

        public NotificationBaloonType NotificationType { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }

        public static void Create(TempDataDictionary contextTempData, NotificationBaloonType notificationType, string message, string title = "")
        {
            contextTempData[NotificationCookieName] = new NotificationBaloonMessage(notificationType, message, title);
        }

        public static NotificationBaloonMessage Get(TempDataDictionary contextTempData)
        {
            return contextTempData[NotificationCookieName] as NotificationBaloonMessage;
        }
    }
}
