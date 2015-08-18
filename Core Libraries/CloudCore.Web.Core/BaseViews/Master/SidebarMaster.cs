using System.Web.Mvc.Html;
using CloudCore.Web.Core.BaseModels;

namespace CloudCore.Web.Core.BaseViews.Master
{
    public abstract class SidebarMaster<T> : CROMaster<T>
    {
        protected override void InitializePage()
        {
            base.InitializePage();
            InitializeSidebar();
        }

        protected void InitializeSidebar()
        {
            var model = Model as ICRORenderer;
            if (model != null)
            {
                var sidebar = new Sidebar();
                model.InitializeSidebar(sidebar, Url);
                if (sidebar.CanDisplay)
                {
                    DefineSection("sidebar", () => Write(Html.Partial("~/Areas/CUI/Views/Shared/Sidebar/_SidebarContainer.cshtml", sidebar)));
                }
            }
        }
    }
}
