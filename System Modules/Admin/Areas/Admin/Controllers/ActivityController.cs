using System.Web.Mvc;
using CloudCore.Admin.Models;
using CloudCore.Domain.Workflow;
using CloudCore.Web.Core.BaseControllers;

using CloudCore.Data;

namespace CloudCore.Admin.Controllers
{
    public class ActivityController : InternalAuthenticatedController
    {
        public ActionResult Search()
        {
            var model = new ActivitySearchModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(ActivitySearchModel model)
        {
            model.Search();
            return View(model);
        }

        public ActionResult Details(int activityId)
        {
            var model = new ActivityDetailsModel { ActivityId = activityId };
            return View(model);
        }

        public ActionResult AccessPoolAllocation(int activityId)
        {
            
            var model = new ActivityAccessPoolAllocationModel(activityId);
            model.LoadAccessPools();
            return View(model);
        }

        public ActionResult RemoveAccessPool(int activityId, int accessPoolId)
        {
            CloudCoreDB.Context.Cloudcore_ActivityAllocationDelete(activityId, accessPoolId);
            ShowSuccessMessage("Access Pool has been removed");
            return RedirectToAction("AccessPoolAllocation", new { activityId });
        }

        public ActionResult AutomatedRetries(int activityId)
        {
            var model = new ActivityAutomatedRetriesModel { ActivityId = activityId };
            model.GetRetryInformation();
            return View(model);
        }

        [HttpPost]
        public ActionResult AutomatedRetries(ActivityAutomatedRetriesModel model)
        {
            ValidateAndExecute(model.SaveRetryInformation, "Worker retry information saved successfully");
            return View(model);
        }

    }
}
