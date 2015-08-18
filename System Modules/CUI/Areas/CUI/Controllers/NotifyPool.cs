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
        public ActionResult NotifyPool()
        {
            var model = new NotificationModelForPool();
            return View(model);
        }

        [HttpPost]
        public ActionResult NotifyPool(NotificationModelForPool model)
        {
            int? notificationId = 0;
            CloudCoreDB.Context.Cloudcore_NotificationCreateByAccessPool(model.AccessPoolId, CloudCoreIdentity.UserId, model.Subject, model.Message, ref notificationId);
            

            SessionInfo.LastNotifyUpdate = DateTime.Now.AddDays(-1);
            ShowSuccessMessage(string.Format(@"Users in Access Pool ""{0}"" have been notified.", model.AccessPoolName));
            return View(model);
        }
    }
}
