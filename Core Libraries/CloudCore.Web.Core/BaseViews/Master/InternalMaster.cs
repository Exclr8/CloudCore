using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using CloudCore.Web.Core.Security.Authentication;
using System.Web.Optimization;

namespace CloudCore.Web.Core.BaseViews.Master
{
    /// <summary>
    /// Base Internal View should not be used for any internal cloud core page.
    /// </summary>
    public abstract class InternalMaster<T> : SidebarMaster<T>
    {
        protected override MvcHtmlString GetNavigation()
        {
            var navbarBuilder = new StringBuilder();
            navbarBuilder.Append(base.GetNavigation());
            navbarBuilder.Append(Html.Partial("~/Areas/CUI/Views/Shared/Navbar/_NavbarMenu.cshtml"));
            return new MvcHtmlString(navbarBuilder.ToString());
        }
    }
}