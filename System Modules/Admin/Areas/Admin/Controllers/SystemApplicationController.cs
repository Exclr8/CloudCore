using System.Data.SqlClient;
using System.Web.Mvc;
using CloudCore.Admin.Models;
using CloudCore.Domain;
using CloudCore.Web.Core;
using CloudCore.Web.Core.BaseControllers;
using CloudCore.Web.Core.Security.Authorization.Attributes;

using CloudCore.Data;

namespace CloudCore.Admin.Controllers
{
    [CloudCoreAuthorized]
    public class SystemApplicationController : InternalAuthenticatedController
    {
        public ActionResult Index()
        {
            return FindApplication();
        }

        public ActionResult FindApplication()
        {
            SystemApplicationSearchModel model = new SystemApplicationSearchModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult FindApplication(SystemApplicationSearchModel model)
        {
            model.Search();
            return View(model);
        }

        public ActionResult CreateApplication()
        {
            SystemApplicationContext model = new SystemApplicationContext();
            model.New();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateApplication(SystemApplicationContext model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                    return RedirectToAction("Details", "SystemApplication", new {ApplicationId = model.ApplicationId });
                }
                catch (SqlException sqlError)
                {
                    ShowErrorMessage(sqlError.Message);
                }
            }
            return View(model);
        }

        public ActionResult Details(int applicationId)
        {
            try
            {
                var model = new SystemApplicationActivitiesModel();
                model.ApplicationId = applicationId;
                model.GetApplicationActivities();
                return View(model);
            }
            catch (SqlException sqlError)
            {
                ShowErrorMessage(sqlError.Message);
            }
            return View();
        }

        //TODO : This is not used
        //public ActionResult DeleteActivityFromApplication(int applicationId, int activityId)
        //{
        //    var model = new SystemApplicationActivitiesModel();
            
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            CloudCoreDB.Context.Cloudcore_ApplicationAllocationDelete(applicationId, activityId);
        //            ShowSuccessMessage("Activity has been successfully removed.");

        //            return RedirectToAction("Details", new {ApplicationId = applicationId});
        //        }
        //        else
        //        {
        //            ShowErrorMessage(Common.GetErrorListFromModelState(ModelState));
        //        }
        //    }
        //    catch (SqlException sqlError)
        //    {
        //        ShowErrorMessage(sqlError.Message);
        //    }
        //    return View();
        //}

        public ActionResult ModifyApplication(int applicationId)
        {
            SystemApplicationContext model = new SystemApplicationContext();
            model.ApplicationId = applicationId;
            return View(model);
        }

        [HttpPost]
        public ActionResult ModifyApplication(SystemApplicationContext model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Update();
                    ShowSuccessMessage("Application updated successfully.");
                    return RedirectToAction("Details", "SystemApplication", new { applicationId = model.ApplicationId });
                }
                catch (SqlException sqlError)
                {
                    ShowErrorMessage(sqlError.Message);
                }
            }
            return View(model);
        }

        public ActionResult DeleteApplication(int ApplicationId)
        {
            SystemApplicationContext model = new SystemApplicationContext();
            model.ApplicationId = ApplicationId;
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteApplication(SystemApplicationContext model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Delete();
                    ShowSuccessMessage("Application deleted successfully.");
                    return RedirectToAction("FindApplication", "SystemApplication");
                }
                catch (SqlException sqlError)
                {
                    ShowErrorMessage(sqlError.Message);
                }
            }
            return View(model);
        }
    }
}
