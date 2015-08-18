using System;
using System.Web.Mvc;
using System.Web.UI;
using CloudCore.Domain.Workflow.Exceptions;
using CloudCore.Web.Areas.CUI.Models.TaskList;
using CloudCore.Web.Models;
using CloudCore.Web.Core.BaseControllers;
using CloudCore.Web.Core.Security.Authentication;
using CloudCore.Core.TaskList;
using CloudCore.Configuration.ConfigFile;
using CloudCore.Domain;
using System.Linq;
using System.Collections.Generic;


// ReSharper disable once CheckNamespace
namespace CloudCore.Web.Controllers
{
    public class TasklistController : InternalAuthenticatedController
    {
        protected int ApplicationId { get; set; }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            SessionInfo.ActiveTab = 2;
            ApplicationId = CloudCore.Core.Modules.Environment.ApplicationId;
        }

        public ActionResult Standard()
        {
            var model = new TaskListModel
            {
                ActiveSidebarTab = SessionInfo.TaskListActiveTab
            };
            ViewBag.Title = "Tasks";
            return View(model);
        }

        public ActionResult OpenWorkItemByInstance(Int64 instanceId)
        {
            var model = new TaskListModel();

            try
            {
                var openItem = model.OpenWorkItemByInstance( instanceId);
                // ReSharper disable once Mvc.AreaNotResolved TODO: Investigate why area cannot be resolved.
                return RedirectToAction(openItem.Action, openItem.Controller, new { area = "Activities", openItem.InstanceId, openItem.KeyValue });
            }
            catch (WorkItemAlreadyOpenException ex)
            {
                ShowErrorMessage(ex.Message);
                return RedirectToAction("Standard");
            }
        }

        [OutputCache(Duration = 3600)]
        public PartialViewResult RenderTaskListSidebar()
        {
            return PartialView("Sidebar/_SidebarContainer", TaskListPageSidebar.PopuateTasklistSidebar(Url));
        }

        [OutputCache(Duration = 3600, Location=OutputCacheLocation.Client)]
        public PartialViewResult RenderTaskListSearchBar()
        {
            return PartialView("TaskList/_TaskListSearchBar", TaskListSearchReferencesModel.GetReferenceTypes());
        }

        public PartialViewResult GetTasks(int listType, string activeTab, bool isStandard, int? referenceType, string referenceValue)
        {
            SessionInfo.TaskListActiveTab = activeTab;
            
            var taskListItems = 
                isStandard
                ? TaskListQueryList.GetStandardTasklist( listType, referenceType.GetValueOrDefault(), referenceValue, CloudCoreIdentity.UserId, ApplicationId)
                : TaskListQueryList.GetCustomTasklist( listType, referenceType.GetValueOrDefault(), referenceValue, CloudCoreIdentity.UserId, ApplicationId);

            return PartialView("TaskList/_TaskListSearchResults", taskListItems);
        }
    }
}
