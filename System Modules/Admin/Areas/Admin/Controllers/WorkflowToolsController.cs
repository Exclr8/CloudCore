using System;
using System.Data.SqlClient;
using System.Web.Mvc;
using CloudCore.Admin.Models;
using CloudCore.Domain.Workflow;
using CloudCore.Web.Core.BaseControllers;

using CloudCore.Data;

namespace CloudCore.Admin.Controllers
{
    public class WorkflowToolsController : InternalAuthenticatedController
    {
        public ActionResult FailedActivities()
        {
            var model = new FailedActivitiesModel();
            model.LoadFailedActivities();
            return View(model);
        }

        [HttpPost]
        public ActionResult FailedActivities(FailedActivitiesModel model)
        {
            if (model.GroupByActivity)
                model.LoadFailedActivities();
            else
                model.LoadFailedWorklistItems();

            return View(model);
        }

        public ActionResult RestartFailedInstance(int instanceId)
        {
            try
            {
                CloudCoreDB.Context.Cloudcore_RestartFailedWorklistItem(instanceId);

                ShowSuccessMessage("Worklist item has been restarted.");
            }
            catch (SqlException ex)
            {
                ShowErrorMessage(String.Format("Unable to restart the worklist item. Error: {0}", ex.Message));
            }

            return RedirectToAction("FailedActivities");
        }

        public ActionResult RestartFailedActivity(int activityId)
        {
            try
            {
                //var activity = new Activity(activityId);

                //activity.RestartFailedWorkItems();

                //ShowSuccessMessage("Activity has been restarted.");
                ShowErrorMessage("Not implemented");
            }
            catch (SqlException ex)
            {
                ShowErrorMessage(String.Format("Unable to restart the activity. Error: {0}", ex.Message));
            }

            return RedirectToAction("FailedActivities");
        }

        public ActionResult FindWorklistItem()
        {
            var model = new WorklistSearchModel();
            model.GetListStatusTypes();
            return View(model);
        }

        [HttpPost]
        public ActionResult FindWorklistItem(WorklistSearchModel model)
        {
          
            try
            {
                model.Search();
                model.GetListStatusTypes();
                
            }
            catch (Exception ex)
            {
                    
                ShowErrorMessage(ex.Message);
            }

            return View(model);

        }

        public ActionResult Details(int instanceId)
        {
            var model = new WorkListItemModel(instanceId);
            model.LoadInstanceHistory();
            model.LoadModelDataFromActiveUserCache();
            return View(model);
        }

        public ActionResult ChangeUser(int instanceId)
        {
            var model = new WorkListItemModel { InstanceId = instanceId };
            model.LoadModelDataFromActiveUserCache();
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeUser(WorkListItemModel model, int instanceId)
        {
            string updateMsg = model.UpdateUserforWorklistItem();
            var newmodel = new WorkListItemModel();

            if (updateMsg == "true")
            {
                ShowSuccessMessage("User Changed Successfully.");

            }
            else
            {
                ShowErrorMessage(updateMsg);
            }

            newmodel.InstanceId = instanceId;
            newmodel.ActiveWorkListItem.ForceRefresh();
            newmodel.LoadModelDataFromActiveUserCache();
            return View(newmodel);

        }

        public ActionResult ChangePriority(int instanceId)
        {
            var model = new WorkListItemModel { InstanceId = instanceId };
            model.LoadModelDataFromActiveUserCache();
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangePriority(WorkListItemModel model, int instanceId)
        {
            string updateMsg = model.UpdatePriorityforWorklistItem();
            var newmodel = new WorkListItemModel();

            if (updateMsg == "true")
            {
                ShowSuccessMessage("Priority Changed Successfully.");

            }
            else
            {
                ShowErrorMessage(updateMsg);
            }

            newmodel.InstanceId = instanceId;
            newmodel.ActiveWorkListItem.ForceRefresh();
            newmodel.LoadModelDataFromActiveUserCache();
            return View(newmodel);

        }

        public ActionResult CancelItem(int instanceId)
        {
            var model = new WorkListItemModel { InstanceId = instanceId };
            model.LoadModelDataFromActiveUserCache();
            return View(model);
        }

        [HttpPost]
        public ActionResult CancelItem(WorkListItemModel model, int instanceId)
        {
            string updateMsg = model.CancelWorklistItem();
            var newmodel = new WorkListItemModel();

            if (updateMsg == "true")
            {
                ShowSuccessMessage("The Worklist Item has successfully been cancelled.");
                return RedirectToAction("FindWorklistItem", "WorkflowTools");
            }

            ShowErrorMessage(updateMsg);

            newmodel.InstanceId = instanceId;
            newmodel.ActiveWorkListItem.ForceRefresh();
            newmodel.LoadModelDataFromActiveUserCache();
            return View(newmodel);
        }

        public ActionResult ReleaseItem(int instanceId)
        {
            var model = new WorkListItemModel { InstanceId = instanceId };
            model.LoadModelDataFromActiveUserCache();
            return View(model);
        }

        [HttpPost]
        public ActionResult ReleaseItem(WorkListItemModel model, int instanceId)
        {
            string updateMsg = model.ReleaseWorklistItem();

            if (updateMsg == "true")
            {
                ShowSuccessMessage("The Worklist Item has successfully been released.");
                return RedirectToAction("Details", "WorkflowTools", new { instanceId = model.InstanceId });
            }

            var newmodel = new WorkListItemModel();
            ShowErrorMessage(updateMsg);
            newmodel.InstanceId = instanceId;
            newmodel.ActiveWorkListItem.ForceRefresh();
            newmodel.LoadModelDataFromActiveUserCache();
            return View(newmodel);
        }

        public ActionResult ChangeDueDate(int instanceId)
        {
            var model = new WorkListItemModel {InstanceId = instanceId};
            model.LoadModelDataFromActiveUserCache();
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeDueDate(WorkListItemModel model, int instanceId)
        {
            string updateMsg = model.DelayWorklistItem();
            var newmodel = new WorkListItemModel();

            if (updateMsg == "true")
            {
                ShowSuccessMessage("Due Date Changed Successfully.");

            }
            else
            {
                ShowErrorMessage(updateMsg);
            }

            newmodel.InstanceId = instanceId;
            newmodel.ActiveWorkListItem.ForceRefresh();
            newmodel.LoadModelDataFromActiveUserCache();
            return View(newmodel);
        }
    }
}
