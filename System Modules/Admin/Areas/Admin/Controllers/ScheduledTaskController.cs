using System;
using System.Data.SqlClient;
using System.Web.Mvc;
using CloudCore.Admin.Models;
using CloudCore.Web.Core;
using CloudCore.Web.Core.BaseControllers;


namespace CloudCore.Admin.Controllers
{
    public class ScheduledTaskController : InternalAuthenticatedController
    {
        public ActionResult Search()
        {
            ScheduledTaskSearchModel model = new ScheduledTaskSearchModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(ScheduledTaskSearchModel model)
        {

            model.Search();
            return View(model);
        }

        public ActionResult Details(int scheduledTaskId)
        {
            ScheduledTaskModel model = new ScheduledTaskModel();
            model.ScheduledTaskId = scheduledTaskId;
            model.LoadModelDataFromActiveUserCache();
            return View(model);
        }

        public ActionResult Modify(int scheduledTaskId)
        {
            ScheduledTaskModel model = new ScheduledTaskModel();
            model.ScheduledTaskId = scheduledTaskId;
            model.LoadModelDataFromActiveUserCache();
            model.GetIntervalTypes();
            return View(model);
        }

        [HttpPost]
        public ActionResult Modify(ScheduledTaskModel model)
        {
            DateTime validDate;
            try
            {
                if (!(DateTime.TryParse(model.NextRunDate.ToString(), out validDate)) || model.NextRunDate <= new DateTime(1753, 1, 1))
                {
                    throw new ArgumentException(string.Format("Value '{0}' is invalid for Next Run Date", model.NextRunDate.ToString()));
                }

                if (ModelState.IsValid)
                {
                    model.UpdateScheduledTask();
                    ShowSuccessMessage("Scheduled Task Updated Successfully.");
                    return RedirectToAction("Details", new { scheduledTaskId = model.ScheduledTaskId });
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

            model.GetIntervalTypes();
            return View(model);
        }
    }
}
