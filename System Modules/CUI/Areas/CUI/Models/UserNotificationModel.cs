using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CloudCore.Domain;
using CloudCore.Web.Core.Security.Authentication;
using CloudCore.Web.Html;

using CloudCore.Data;

namespace CloudCore.Web.Models
{
    public class UserNotificationModel
    {
        public string Created { get; set; }
        public bool HasRead { get; set; }
        public bool Important { get; set; }
        public long NotificationId { get; set; }
        public string Subject { get; set; }       
        public string Message { get; set; }

        public string MessageWithLinks
        {
            get
            {
                return Message.HtmlLinkifyString();
            }
        }

        public void LoadUserNotificationAndMarkAsRead(int userId, int notificationId)
        {
            var dbContext = CloudCoreDB.Context;
            var notification = dbContext.Cloudcore_VwUserNotification.Where(un => un.UserId == userId && un.NotificationId == notificationId).SingleOrDefault();

            if (notification != null)
            {
                Created = notification.Created.ToString();
                HasRead = true;
                Subject = notification.Subject;
                Message = notification.Message;
                Important = notification.Important;
                NotificationId = notification.NotificationId;

                if (!notification.HasRead)
                    dbContext.Cloudcore_NotificationMarkAsRead(userId, notificationId);
            }
        }
    }

    public class UserNotificationModelResult : LoggedInUserModel
    {
        [Display(Name = "User Notifications")]
        public List<UserNotificationModel> Notifications { get; set; }

        public void LoadNotifications()
        {
            UserId = CloudCoreIdentity.UserId;

            Notifications = (CloudCoreDB.Context.Cloudcore_VwUserNotification
                .Where(un => un.UserId == UserId)
                .Select(un => new UserNotificationModel
                {
                    Created = un.Created.ToString(),
                    HasRead = un.HasRead,
                    Message = un.Message,
                    NotificationId = un.NotificationId,
                    Important = un.Important,
                    Subject = un.Subject
                })).ToList();
        }
    }

    public class UserNotificationSideBarModel : UserNotificationModelResult
    {
        public List<UserNotificationModel> TodayList { get; set; }
        public List<UserNotificationModel> YesterdayList { get; set; }
        public List<UserNotificationModel> WeekList { get; set; }
        public List<UserNotificationModel> OlderList { get; set; }

        public UserNotificationSideBarModel()
        {
            TodayList = new List<UserNotificationModel>();
            YesterdayList = new List<UserNotificationModel>();
            WeekList = new List<UserNotificationModel>();
            OlderList = new List<UserNotificationModel>();

            this.LoadNotifications();
            this.FilterNotifications();
        }

        public void LoadNotifications(int limit = 20)
        {
            UserId = CloudCoreIdentity.UserId;

            Notifications = (CloudCoreDB.Context.Cloudcore_VwUserNotification
                .Where(un => un.UserId == UserId)
                .Take(limit)
                .OrderByDescending(un => un.Created)
                .Select(un => new UserNotificationModel
                {
                    Created = un.Created.ToString(),
                    HasRead = un.HasRead,
                    Message = un.Message,
                    NotificationId = un.NotificationId,
                    Important = un.Important,
                    Subject = un.Subject
                })).ToList();
        }

        private void FilterNotifications()
        {
            foreach (var notification in Notifications)
            {
                var created = DateTime.Parse(notification.Created);

                if (created.Date == DateTime.Now.Date)
                    TodayList.Add(notification);
                else if(created.Date == DateTime.Now.Date.AddDays(-1))
                    YesterdayList.Add(notification);
                else if (created.Date >= DateTime.Now.Date.AddDays(-7))
                    WeekList.Add(notification);
                else
                    OlderList.Add(notification);
            }
        }
    }
}
