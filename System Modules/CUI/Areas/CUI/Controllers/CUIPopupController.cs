using System;
using System.Data.SqlClient;
using System.IO;
using System.Web.Mvc;
using System.Linq;
using CloudCore.Domain;
using CloudCore.Web.Areas.CUI.Helpers;
using CloudCore.Web.Models;
using CloudCore.Web.Core.BaseControllers;
using CloudCore.Web.Core.Caching;
using CloudCore.Web.Core.Security.Authentication;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using CloudCore.Data;

namespace CloudCore.Web.Controllers
{
    public partial class CUIPopupController : AuthenticatedPopupController
    {
        public ActionResult AddDashboard(int tilePosition)
        {
            var model = new AvailableUsersDashboardItemsModel
            {
                TilePosition = tilePosition
            };

            model.PopulateUserAvailableDashboardItems( CloudCoreIdentity.UserId);

            return View(model);
        }

        [HttpPost]
        public ActionResult AddDashboard(AvailableUsersDashboardItemsModel model)
        {
            model.DashboardAddToCurrentUser();

            return ClosePopUpResult();
        }

        public ActionResult UserNotification(int notificationId)
        {
            var userId = CloudCoreIdentity.UserId;

            var model = new UserNotificationModel();
            model.LoadUserNotificationAndMarkAsRead(userId, notificationId);

            SessionInfo.HasNotifications = CloudCoreDB.Context.Cloudcore_VwUserNotification.Where(un => un.UserId == userId && un.HasRead == false).Any();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult UserNotification(UserNotificationModel model)
        {
            CloudCoreDB.Context.Cloudcore_NotificationRemove((int)model.NotificationId, CloudCoreIdentity.UserId);
            ShowSuccessMessage("Notification successfully removed");
            return RedirectToAction("Notifications", "Tools", new { area = "CUI" });
        }

        public ActionResult CloseNotification(UserNotificationModel model)
        {
            return ClosePopUpResult();
        }

        public ActionResult SearchFavourite()
        {
            return View(new AddFavouritesSearchModel());
        }

        [HttpPost]
        public ActionResult SearchFavourite(AddFavouritesSearchModel model)
        {
            model.Search();
            return View(model);
        }

        public ActionResult AddFavourite(Guid Reference)
        {
            try
            {
                UserProfile.AddFavourite( Reference, FavouriteType.Menu);
                ShowSuccessMessage("Favourite Added Successfully");
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("7 menu item favourites"))
                {
                    ShowErrorMessage(ex.Message);
                }
            }

            return ClosePopUpResult();
        }

        public ActionResult ViewDashboard(int tilePosition)
        {
            var userId = CloudCoreIdentity.UserId;
            var dashboardTasks = new DashboardHelper();

            var userDashboardData = dashboardTasks.GetUserDashboardTileData(userId, tilePosition);

            var model = new ViewDashboardModel();

            if (userDashboardData != null)
            {
                model.TilePosition = tilePosition;
                model.UserId = CloudCoreIdentity.UserId;
                model.TileContextDefined = true;
                model.TileContext = userDashboardData.ResultData;
            }
            else
            {
                model.TilePosition = tilePosition;
                model.UserId = CloudCoreIdentity.UserId;
            }

            return View(model);
        }
    }
}
