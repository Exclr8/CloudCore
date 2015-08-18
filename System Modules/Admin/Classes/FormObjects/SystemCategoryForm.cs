using System.Web.Mvc;
using CloudCore.Admin.CRO;
using CloudCore.Web.Core;
using CloudCore.Web.Core.BaseModels;

namespace CloudCore.Admin.Models
{
    public class SystemValueCategoryContext : BaseContextModel
    {
        public SystemValueCategoryCachedReusableObject SystemValueCategory = SystemValueCategoryCachedReusableObject.LoadFromCache();

        public int CategoryId
        {
            get
            {
                return SystemValueCategory.CategoryId;
            }
            set
            {
                this.Key = value;
            }
        }

        protected override void OnKeyChanged(long key)
        {
            AddKeyed(SystemValueCategory, key);
            base.OnKeyChanged(key);
        }

        public override void InitializeSidebar(Sidebar sidebar, UrlHelper urlHelper)
        {
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, "Search", urlHelper.Action("Search", "SystemValues", new { area = "Admin" }));
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, "Details", urlHelper.Action("Details", "SystemValues", new { area = "Admin", CategoryId = SystemValueCategory.CategoryId }));
        }
    }
}