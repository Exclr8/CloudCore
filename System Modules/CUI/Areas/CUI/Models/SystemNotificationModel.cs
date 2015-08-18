using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using CloudCore.Web.Core;
using CloudCore.Web.Core.BaseModels;
using CloudCore.Web.Core.Security.Authentication;

using CloudCore.Data;

namespace CloudCore.Web.Models
{
    public class SystemNotificationModel : BaseContextModel
    {
        public override void InitializeSidebar(Sidebar sidebar, UrlHelper urlHelper)
        {
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, "Last Notifications", urlHelper.Action("Index", "SystemNotification", new { area = "CUI" }));
            sidebar.AddSidebarItem(SidebarObjectType.ManageConfigure, "Notify User", urlHelper.Action("NotifyUser", "SystemNotification", new { area = "CUI" }));
            sidebar.AddSidebarItem(SidebarObjectType.ManageConfigure, "Notify User Pool", urlHelper.Action("NotifyPool", "SystemNotification", new { area = "CUI" }));
        }
    }

    public class NotificationHistoryModel : SystemNotificationModel
    {
        [Display(Name = "User Notifications")]
        public List<UserNotificationModel> Notifications { get; set; }

        public NotificationHistoryModel()
        {
            var userId = CloudCoreIdentity.UserId;
            
            Notifications = (CloudCoreDB.Context.Cloudcore_VwUserNotification
                .Where(un => un.CreatorId == userId)
                .OrderByDescending(order => order.Created)
                .Select(un => new UserNotificationModel
                {
                    Created = un.Created.ToString(),
                    HasRead = un.HasRead,
                    Message = un.Message,
                    NotificationId = un.NotificationId,
                    Subject = un.Subject
                })).ToList(); //Take only certain amount of rows... i.e not all
         }
    }

    public class NotificationMessageModel : SystemNotificationModel
    {
        public DateTime Created { get; set; }
        public bool HasRead { get; set; }
        public int NotificationId { get; set; }
        [Required]
        [StringLength(50,ErrorMessage="A Maximum of 50 characters allowed")]
        public string Subject { get; set; }

        public string TaskId { get; set; }
        
        [Required]
        [StringLength(1000, ErrorMessage = "A Maximum of 1000 characters allowed")]
        public string Message { get; set; }

    }

    public class NotificationModelForUser : NotificationMessageModel
    {
        public int UserId { get; set; }

        [Display(Name = "User")]
        [Required(ErrorMessage = "Please select a user to notify")]
        public string UserFullName { get; set; }

        public string LookupInputId { get; set; }
        public string LookupInputIdValue { get; set; }
    }

    public class NotificationModelForPool : NotificationMessageModel
    {
        public int AccessPoolId { get; set; }
        
        [Display(Name = "Access Pool")]
        [Required(ErrorMessage = "Please select an access pool to notify")]
        public string AccessPoolName { get; set; }

    }
}