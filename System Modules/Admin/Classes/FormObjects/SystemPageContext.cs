using System.Linq;
using System.Web.Mvc;
using CloudCore.Admin.Classes.CachedReusableObjects;
using CloudCore.Domain;
using CloudCore.Web.Core;
using CloudCore.Web.Core.BaseModels;
using CloudCore.Web.Core.Security.Authorization;

using CloudCore.Data;

namespace CloudCore.Admin.Models
{
    public class SystemPageContext : BaseContextModel
    {
        public PagesCachedReusableObject ActiveSystemPage = PagesCachedReusableObject.LoadFromCache();

        public int ActionId
        {
            get
            {
                return ActiveSystemPage.ActionId;
            }
            set
            {
                Key = value;
            }
        }

        protected override void OnKeyChanged(long key)
        {
            AddKeyed(ActiveSystemPage, key);
 	        base.OnKeyChanged(key);
        }

        public override void InitializeSidebar(Sidebar sidebar, UrlHelper urlHelper)
        {
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, "Search", urlHelper.Action("Search", "Pages", new { area = "Admin" }));
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, "Details", urlHelper.Action("Details", "Pages", new { area = "Admin", ActionId = ActiveSystemPage.ActionId }));

            base.InitializeSidebar(sidebar, urlHelper);
        }


        public void AddPageToPool(int accessPoolId )
        {
            CloudCoreDB.Context.Cloudcore_SystemActionAllocationCreate(this.ActionId, accessPoolId);

            UserPermission.UpdateForChange();
        }

        public void RemovePageFromPool(int accessPoolId )
        {

            CloudCoreDB.Context.Cloudcore_ActionAllocationRemove(accessPoolId, this.ActionId);

            UserPermission.UpdateForChange();
        }
    }
}