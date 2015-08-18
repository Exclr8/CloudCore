using System;
using System.Web.Mvc;
using System.Web.UI;
using CloudCore.Admin.Models;
using CloudCore.Data;
using CloudCore.Web.Core.BaseControllers;

namespace CloudCore.Admin.Controllers
{
    public class AdminPopupController : AuthenticatedPopupController
    {
        public ActionResult AddAccessPoolUser(int accesspoolId)
        {
            var model = new AccessPoolUserSearch { AccessPoolId = accesspoolId };
            return PartialView("AddAccessPoolUser", model);
        }

        public ActionResult AddAccessPoolUserPopup(int accesspoolId)
        {
            var model = new AccessPoolUserSearch { AccessPoolId = accesspoolId };
            return View(model);
        }

        [OutputCache(Duration = 0, Location = OutputCacheLocation.Client)]
        public ActionResult SetAccessPoolUserFromAccessPool(int userId, int accesspoolId)
        {
            try
            {
                var model = new AccessPoolContextModel { AccessPoolId = accesspoolId };
                model.AddUserToPool(userId);
                ShowSuccessMessage("User has been added to the Access Pool successfully.");
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }

            return RedirectToAction("Details", "AccessPool", new { accesspoolId });
        }

        [HttpPost]
        public ActionResult AddAccessPoolUser(AccessPoolUserSearch model)
        {
            model.Search();
            return PartialView("AddAccessPoolUser", model);
        }

        public ActionResult AccessPoolLookup(string returnRouteAction, string returnRouteController, int returnRouteId, string returnRouteIdName)
        {
            var model = new AccessPoolLookupModel();

            model.ReturnRouteAction = returnRouteAction;
            model.ReturnRouteController = returnRouteController;
            model.ReturnRouteId = returnRouteId;
            model.ReturnRouteIdName = returnRouteIdName;
            return PartialView("AccessPoolLookup", model);
        }

        [HttpPost]
        public ActionResult AccessPoolLookup(AccessPoolLookupModel searchModel)
        {
            searchModel.Search();
            return PartialView("AccessPoolLookup", searchModel);
        }


        public ActionResult PageAccessPoolLookup(int actionId)
        {
            var model = new PageAccessPoolLookupModel(actionIdBeingSearched: actionId);
            return PartialView("PageAccessPoolLookup", model);
        }

        [HttpPost]
        public ActionResult PageAccessPoolLookup(PageAccessPoolLookupModel searchModel)
        {
            searchModel.Search();
            return PartialView("PageAccessPoolLookup", searchModel);
        }

        [OutputCache(Duration = 0, Location = OutputCacheLocation.Client)]
        public ActionResult SetAccessPoolUserFromUser(int userId, int accessPoolId)
        {
            try
            {
                var model = new AccessPoolContextModel { AccessPoolId = accessPoolId };
                model.AddUserToPool(userId);
                ShowSuccessMessage("Access Pool has been successfully added for the user.");
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }

            return RedirectToAction("Details", "User", new { userId });
        }

        [HttpPost]
        public ActionResult AddPageToAccessGroup(int accessGroupId, int actionId)
        {
            var model = new PagesModel();
            model.AddPageToPool(accessGroupId);
            ShowSuccessMessage("Access Pool added to page successfully");
//            return RedirectToAction("Details", "Pages", new { actionId = model.ActionId });
            return Json(Url.Action("Details", "Pages", new { actionId = model.ActionId }));
        }

//        public ActionResult UserLookup()
//        {
//            var userSearchModel = new UserSearchModel();
//            return PartialView("UserLookup", userSearchModel);
//        }

        public ActionResult UserLookup(string idName, string valueName)
        {
            var userSearchModel = new UserSearchModel
            {
                LookupInputId = idName,
                LookupInputIdValue = valueName
            };
            return PartialView("UserLookup", userSearchModel);
        }

        [HttpPost]
        public ActionResult UserLookup(UserSearchModel userSearchModel)
        {
            userSearchModel.Search();
            return PartialView("UserLookup", userSearchModel);
        }

        public ActionResult ManagerLookup()
        {
            var userSearchModel = new UserSearchModel();
            return PartialView("ManagerLookup", userSearchModel);
        }

        [HttpPost]
        public ActionResult ManagerLookup(UserSearchModel userSearchModel)
        {
            userSearchModel.Search();
            return PartialView("ManagerLookup", userSearchModel);
        }

        public ActionResult FailedInstanceInfo(int instanceId)
        {
            return PartialView(new WorkListFailureReasonModel(instanceId));
        }

        public ActionResult ActivityLookup(int applicationId)
        {
            var model = new ActivityLookupModel();
            model.LoadActivities(applicationId);
            return PartialView("ActivityLookup", model);
        }

        [HttpPost]
        public ActionResult ActivityLookup(ActivityLookupModel searchModel)
        {
           // searchModel.Search();
            ShowErrorMessage("Not implemented");
//            return PartialView("ActivityLookup", searchModel);
            return View(searchModel);
        }

        [HttpPost]
        public ActionResult AddActivityToApplication(int activityId, int applicationId)
        {
            CloudCoreDB.Context.Cloudcore_ApplicationAllocationCreate(applicationId, activityId);

            ShowSuccessMessage("Activity allocated successfully to Application");

            return Json("Success");
        }


        [OutputCache(Duration = 0, Location = OutputCacheLocation.Client)]
        public ActionResult AddAccessPoolForActivity(int activityId, int accesspoolId)
        {
            try
            {
                CloudCoreDB.Context.Cloudcore_ActivityAllocationCreate(activityId, accesspoolId);
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }

            return RedirectToAction("AccessPoolAllocation", "Activity", new { activityId });
        }
    }
}
