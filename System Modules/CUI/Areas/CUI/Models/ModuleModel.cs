using System.Web.Mvc;
using CloudCore.Web.Classes.CachedReusableObjects;
using CloudCore.Web.Core;
using CloudCore.Web.Core.BaseModels;

namespace CloudCore.Web.Models
{
    public class ModuleModel: BaseContextModel
    {
        public ModuleCachedReusableObject ModuleDetails = ModuleCachedReusableObject.LoadFromCache();

        public int ModuleIndex
        {
            set { Key = value; }
            get { return ModuleDetails.ModuleIndex; }
        }

        protected override void OnKeyChanged(long key)
        {
            AddKeyed(ModuleDetails, key);
            base.OnKeyChanged(key);
        }

        public override void InitializeSidebar(Sidebar sidebar, UrlHelper urlHelper)
        {
            sidebar.AddSidebarItem(SidebarObjectType.ViewDisplay, "Module Details", urlHelper.Action("ModuleDetails", "Tools", new { area = "CUI", moduleIndex = this.ModuleDetails.Key }));
     
            base.InitializeSidebar(sidebar, urlHelper);
        }
    }
}
