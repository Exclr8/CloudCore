using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;
using CloudCore.Admin.Models.ScheduledTaskGroup;
using CloudCore.Data;
using CloudCore.Web.Core;
using CloudCore.Web.Core.BaseControllers;


namespace CloudCore.Admin.Controllers
{
    public class ScheduledTaskGroupController : InternalAuthenticatedController
    {
        public ActionResult Search()
        {
            ScheduledTaskGroupSearchModel model = new ScheduledTaskGroupSearchModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(ScheduledTaskGroupSearchModel model)
        {
            model.Search();
            return View(model);
        }

        public ActionResult Details(int scheduledTaskGroupId)
        {
            var model = new ScheduledTaskGroupModifyModel
            {
                ScheduledTaskGroupId = scheduledTaskGroupId
            };
            model.LoadModelDataFromActiveUserCache();

            model.LoadScheduledTaskGroupScheduledTasks(scheduledTaskGroupId);

            return View(model);
        }

        public JsonResult EnableDisable(int scheduledTaskId, bool isActive)
        {
            const int scheduled = 0;
            const int disabled = 100;

            try
            {
                ScheduledTaskGroupModifyModel.UpdateScheduledTask(scheduledTaskId, isActive ? scheduled : disabled);
                return Json(new { Successfull = true, Message = String.Format("Scheduled task is {0}", isActive ? "Enabled" : "Disabled") });
            }
            catch (Exception)
            {
                return Json(new { Successfull = false, Message = "An error occured while trying to update the scheduled task." });
            }
        }

        public ActionResult Modify(int scheduledTaskGroupId)
        {
            ScheduledTaskGroupModifyModel model = new ScheduledTaskGroupModifyModel();
            model.ScheduledTaskGroupId = scheduledTaskGroupId;
            model.LoadModelDataFromActiveUserCache();
            return View(model);
        }

        [HttpPost]
        public ActionResult Modify(ScheduledTaskGroupModifyModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UpdateScheduledGroupTask();
                    ShowSuccessMessage("Scheduled Task Group Updated Successfully.");
                }
                else
                {
                    ShowErrorMessage(Common.GetErrorListFromModelState(ModelState));
                }
            }
            catch (ArgumentException ex)
            {
                ShowErrorMessage(ex.Message);
            }
            catch (SqlException SqlError)
            {
                ShowErrorMessage(SqlError.Message);
            }

            return View(model);
        }
    }
}
