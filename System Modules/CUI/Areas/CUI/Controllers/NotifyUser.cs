using System;
using System.Web.Mvc;
using CloudCore.Domain;
using CloudCore.Web.Models;
using CloudCore.Web.Core.BaseControllers;
using CloudCore.Web.Core.Security.Authentication;
using CloudCore.Data;

namespace CloudCore.Web.Controllers
{
    public partial class SystemNotificationController : InternalAuthenticatedController
    {
        public ActionResult NotifyUser()
        {
            var model = new NotificationModelForUser();
            return View(model);
        }

        [HttpPost]
        public ActionResult NotifyUser(NotificationModelForUser model)
        {
            int? notificationId = 0;
            CloudCoreDB.Context.Cloudcore_NotificationCreateByUser(model.UserId, CloudCoreIdentity.UserId, model.Subject, model.Message, ref notificationId);
            
            SessionInfo.LastNotifyUpdate = DateTime.Now.AddDays(-1);
            ShowSuccessMessage(string.Format(@"User ""{0}"" has been notified.", model.UserFullName));
            return View(model);
        }

    }
}
