using System;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using CloudCore.Domain;
using CloudCore.Web.Models;
using CloudCore.Web.Core.BaseControllers;
using CloudCore.Web.Core.Razor.Extensions;
using CloudCore.Web.Core.Security.Authentication;


namespace CloudCore.Web.Controllers
{
    public class ToolsController : InternalAuthenticatedController
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            SessionInfo.ActiveTab = 4;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Logs()
        {
            var model = new LogsModel();
            model.LoadLogs();

            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteOldLogs()
        {
            // TODO: ????
            var model = new LogsModel();
            // model.DeleteOldLogs();

            ShowSuccessMessage("Logs older than a month has been removed.");

            return RedirectToAction("Logs");
        }

        public ActionResult PersonalDetails()
        {
            var user = new LoggedInUserModel();
            return View(user);
        }

        [HttpPost]
        public ActionResult PersonalDetails(LoggedInUserModel usermodel)
        {
            var mainImage = WebImage.GetImageFromRequest();

            usermodel.UpdateImage(mainImage);
            usermodel.Update();

            return View("Index");
        }

        public ActionResult Notifications()
        {
            SessionInfo.ActiveTab = 5;
            var userNotifications = new UserNotificationModelResult();
            userNotifications.LoadNotifications();
            return View(userNotifications);
        }

        public ActionResult ViewAccessPools()
        {
            var details = new PersonalDetailsModel();
            return View(details);
        }

        public ActionResult UpdatePersonalDetails()
        {
            var user = new LoggedInUserModel();
            return View(user);
        }

        [HttpPost]
        public ActionResult UpdatePersonalDetails(LoggedInUserModel usermodel)
        {
            try
            {
                var image = WebImage.GetImageFromRequest();
                usermodel.Update();
                usermodel.UpdateImage(image);
                ShowSuccessMessage("Your details have been updated successfully.");
                return View(usermodel);
            }
            catch (ArgumentException)
            {
                ShowErrorMessage("Invalid file, unable to extract an image from the file provided.");
                return View(usermodel);
            }
        }

        public ActionResult ChangePassword()
        {
            var model = new ChangePasswordModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            try
            {
                ViewBag.Title = "Change Password";
                model.ChangePassword();

                ShowSuccessMessage("Password has been updated successfully");
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
            return View(model);
        }

        public ActionResult PersonalLoginHistory()
        {
            var model = new PersonalLoginHistorySearchModel
            {
                StartDate = DateTime.Today.AddDays(-1),
                EndDate = DateTime.Today
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult PersonalLoginHistory(PersonalLoginHistorySearchModel model)
        {
            try
            {
                model.Search( CloudCoreIdentity.UserId);
            }
            catch (ArgumentException ex)
            {
                ShowErrorMessage(ex.Message);
            }

            return View(model);
        }

        public ActionResult GlobalLoginHistory()
        {
            var model = new GlobalLoginHistorySearchModel
            {
                EndDate = DateTime.Today,
                StartDate = DateTime.Today.AddDays(-20)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult GlobalLoginHistory(GlobalLoginHistorySearchModel model)
        {
            try
            {
                model.Search();
            }
            catch (ArgumentException ex)
            {
                ShowErrorMessage(ex.Message);
            }

            return View(model);
        }

        public ActionResult Favourites()
        {
            var model = new ViewFavouriteActionsModel();
            model.GetFavourites();
            return View(model);
        }

        public ActionResult RemoveFavourite(Guid reference)
        {
            var favourite = new ViewFavouriteActionsModel();
            favourite.RemoveFavourite( reference);
            ShowSuccessMessage("Favourite Removed Successfully");
            return RedirectToAction("Favourites");
        }

        public ActionResult Modules()
        {
            ViewBag.Title = "Installed System Modules";
            var model = new InstalledSystemModulesModel();
            return View(model);
        }

        public ActionResult ModuleDetails(int moduleIndex)
        {
            var model = new ModuleModel { Key = moduleIndex };
            ViewBag.Title = "System Module: Module Details";
            return View(model);
        }

        public ActionResult Campaigns()
        {
            return View();
        }
    }

    public static class HttpPostedFileBaseExtensions
    {
        public static bool HasFile(this HttpFileCollectionBase file)
        {
            return (file != null && file.Count > 0);
        }
    }
}
