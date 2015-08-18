using System;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using CloudCore.Core.Modules;
using CloudCore.Web.Core.Menu;

namespace CloudCore.Web.Core.BaseViews.Master
{
    public abstract class FrameworkMaster<T> : CoreMaster<T>
    {
        protected override void InitializePage()
        {
            base.InitializePage();
            InitialiseFramework();
        }

        public void InitialiseFramework()
        {
            DefineSection("Navigation", () => Write(GetNavigation()));
            //DefineSection("Footer", () => Write(GetFooter()));
            DefineSection("SubNavigation", () => Write(GetSubNavigation()));
            DefineSection("SubNavigationSearch", () => Write(GetSubNavigationSearch()));
        }

//        private MvcHtmlString GetFooter()
//        {
//            return Html.Partial("Footer/_Footer", String.Format("Version: {0} / Platform: {1}", WebApplication.Configuration.WebSettings.SiteVersion, CloudCore.Core.Modules.Environment.CoreVersion));
//        }

        protected virtual MvcHtmlString GetNavigation()
        {
            return Html.Partial("~/Areas/CUI/Views/Shared/Navbar/_NavbarHeader.cshtml", WebApplication.Configuration.WebSettings.SiteName);
        }

        protected virtual MvcHtmlString GetSubNavigation()
        {            
            return Html.Partial("Navbar/_NavbarSubMenu", new SubMenuModel());
        }

        protected virtual MvcHtmlString GetSubNavigationSearch()
        {
            return Html.Partial("Navbar/_NavbarSubMenuSearch");
        }
    }
}