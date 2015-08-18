using System.Data.SqlClient;
using System.Web.Mvc;
using CloudCore.Domain;
using CloudCore.Web.Models;
using CloudCore.Web.Core;
using CloudCore.Web.Core.BaseControllers;

using CloudCore.Data;
using CloudCore.Web.Core.Security.Authentication;

namespace CloudCore.Web.Controllers
{
    public partial class SystemNotificationController : InternalAuthenticatedController
    {
        public ActionResult Index()
        {
            var model = new NotificationHistoryModel();
            return View(model);
        }

        public ActionResult Remove(int notificationId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CloudCoreDB.Context.Cloudcore_NotificationDelete(notificationId);

                    ShowSuccessMessage("Notification has been successfully removed.");
                }
                else
                {
                    ShowErrorMessage(Common.GetErrorListFromModelState(ModelState));
                }
            }
            catch (SqlException sqlError)
            {
                ShowErrorMessage(sqlError.Message);
            }

            return RedirectToAction("Index", "SystemNotification");

        }

        public JsonResult MarkSelectedNotificationsAsRead(int[] notificationIds)
        {
            foreach (var id in notificationIds)
                CloudCoreDB.Context.Cloudcore_NotificationMarkAsRead(CloudCoreIdentity.UserId, id);
            return Json(notificationIds);
        }

        public JsonResult MarkNotificationAsRead(int notificationId)
        {
            CloudCoreDB.Context.Cloudcore_NotificationMarkAsRead(CloudCoreIdentity.UserId, notificationId);
            return Json(notificationId);
        }

        public JsonResult ToggleImportant(int notificationId)
        {
            int? important = 0;
            CloudCoreDB.Context.Cloudcore_NotificationToggleImportant(CloudCoreIdentity.UserId, notificationId, ref important);
            return Json(important);
        }

        public JsonResult DeleteMessage(int notificationId)
        {
            CloudCoreDB.Context.Cloudcore_NotificationRemove(notificationId, CloudCoreIdentity.UserId);
            return Json(notificationId);
        }
    }
}
