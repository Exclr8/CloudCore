using System.Web.Mvc;
using CloudCore.Admin.Classes.CachedReusableObjects;
using CloudCore.Web.Core;
using CloudCore.Web.Core.BaseModels;

namespace CloudCore.Admin.Classes.FormObjects
{
    public class WorkListItemForm : BaseContextModel
    {
        public WorkListItemCachedReusableObject ActiveWorkListItem = WorkListItemCachedReusableObject.LoadFromCache();

        public int InstanceId
        {
            get
            {
                return ActiveWorkListItem.InstanceId;
            }
            set
            {
                Key = value;
            }
        }

        protected override void OnKeyChanged(long key)
        {
            AddKeyed(ActiveWorkListItem, key);
            base.OnKeyChanged(key);
        }

        public override void InitializeSidebar(Sidebar sidebar, UrlHelper urlHelper)
        {
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, "Details", urlHelper.Action("Details", "WorkflowTools", new { area = "Admin", InstanceId = ActiveWorkListItem.InstanceId }));
            sidebar.AddSidebarItem(SidebarObjectType.ManageConfigure, "Change User", urlHelper.Action("ChangeUser", "WorkflowTools", new { area = "Admin", InstanceId = ActiveWorkListItem.InstanceId }));
            sidebar.AddSidebarItem(SidebarObjectType.ManageConfigure, "Change Priority", urlHelper.Action("ChangePriority", "WorkflowTools", new { area = "Admin", InstanceId = ActiveWorkListItem.InstanceId }));
            sidebar.AddSidebarItem(SidebarObjectType.ManageConfigure, "Change Activate Date", urlHelper.Action("ChangeDueDate", "WorkflowTools", new { area = "Admin", InstanceId = ActiveWorkListItem.InstanceId }));
            sidebar.AddSidebarItem(SidebarObjectType.ManageConfigure, "Cancel Item", urlHelper.Action("CancelItem", "WorkflowTools", new { area = "Admin", InstanceId = ActiveWorkListItem.InstanceId }));
            sidebar.AddSidebarItem(SidebarObjectType.ManageConfigure, "Release Item", urlHelper.Action("ReleaseItem", "WorkflowTools", new { area = "Admin", InstanceId = ActiveWorkListItem.InstanceId }));
        }
    }
}