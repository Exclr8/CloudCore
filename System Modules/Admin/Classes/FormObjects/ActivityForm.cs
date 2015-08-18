using CloudCore.Admin.Classes.CachedReusableObjects;
using CloudCore.Web.Core;
using CloudCore.Web.Core.BaseModels;

namespace CloudCore.Admin.Classes.FormObjects
{
    public class ActivityForm : BaseContextModel
    {
        public ActivityCachedReusableObject ActiveActivityDetails = ActivityCachedReusableObject.LoadFromCache();

        public int ActivityId
        {
            get
            {
                return ActiveActivityDetails.ActivityId;
            }
            set
            {
                Key = value;
            }
        }

        protected override void OnKeyChanged(long key)
        {
            AddKeyed(ActiveActivityDetails, key);
            base.OnKeyChanged(key);
        }

        public override void InitializeSidebar(Sidebar sidebar, System.Web.Mvc.UrlHelper urlHelper)
        {
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, "Search", urlHelper.Action("Search", "Activity", new { area = "Admin" }));
            sidebar.AddSidebarItem(SidebarObjectType.ManageConfigure, "Access Pools", urlHelper.Action("AccessPoolAllocation", "Activity", new { area = "Admin", activityId = ActiveActivityDetails.ActivityId }));
            sidebar.AddSidebarItem(SidebarObjectType.ManageConfigure, "Automated Retries", urlHelper.Action("AutomatedRetries", "Activity", new { area = "Admin", activityId = ActiveActivityDetails.ActivityId }));
        }

        
    }
}