using System.Web.Mvc;
using CloudCore.Admin.Classes.CachedReusableObjects;
using CloudCore.Web.Core;
using CloudCore.Web.Core.BaseModels;

namespace CloudCore.Admin.Classes.FormObjects
{
    public class ScheduledTaskGroupForm : BaseContextModel 
    {
        public ScheduledGroupCachedReusableObject ActiveScheduledTaskGroupDetails = ScheduledGroupCachedReusableObject.LoadFromCache();

        public int ScheduledTaskGroupId
        {
            get
            {
                return ActiveScheduledTaskGroupDetails.ScheduledTaskGroupId;
            }
            set
            {
                Key = value;
            }
        }

        protected override void OnKeyChanged(long key)
        {
            AddKeyed(ActiveScheduledTaskGroupDetails, key);
            base.OnKeyChanged(key);
        }


        public override void InitializeSidebar(Sidebar sidebar, UrlHelper urlHelper)
        {
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, "Search", urlHelper.Action("Search", "ScheduledTaskGroup", new { area = "Admin" }));
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, "Details", urlHelper.Action("Details", "ScheduledTaskGroup", new { area = "Admin", scheduledTaskGroupId = ActiveScheduledTaskGroupDetails.ScheduledTaskGroupId }));
            sidebar.AddSidebarItem(SidebarObjectType.ManageConfigure, "Modify Details", urlHelper.Action("Modify", "ScheduledTaskGroup", new { area = "Admin", scheduledTaskGroupId = ActiveScheduledTaskGroupDetails.ScheduledTaskGroupId }));
        }
    }
}