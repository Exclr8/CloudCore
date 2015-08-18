using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CloudCore.Admin.Classes.CachedReusableObjects;
using CloudCore.Web.Core;
using CloudCore.Web.Core.BaseModels;

namespace CloudCore.Admin.Classes.FormObjects
{
    public class ScheduledTaskForm : BaseContextModel 
    {
        public ScheduledCachedReusableObject ActiveScheduledTaskDetails = ScheduledCachedReusableObject.LoadFromCache();

        [Display(Name = "Scheduled Task Id")]
        public int ScheduledTaskId
        {
            get
            {
                return ActiveScheduledTaskDetails.ScheduledTaskId;
            }
            set
            {
                Key = value;
            }
        }

        protected override void OnKeyChanged(long key)
        {
            AddKeyed(ActiveScheduledTaskDetails, key);
            base.OnKeyChanged(key);
        }


        public override void InitializeSidebar(Sidebar sidebar, UrlHelper urlHelper)
        {
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, "Search", urlHelper.Action("Search", "ScheduledTask", new { area = "Admin" }));
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, "Details", urlHelper.Action("Details", "ScheduledTask", new { area = "Admin", scheduledTaskId = ActiveScheduledTaskDetails.ScheduledTaskId  }));
            sidebar.AddSidebarItem(SidebarObjectType.ManageConfigure, "Modify Details", urlHelper.Action("Modify", "ScheduledTask", new { area = "Admin", scheduledTaskId = ActiveScheduledTaskDetails.ScheduledTaskId }));
        }
    }
}