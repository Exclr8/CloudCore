using System.Text;
using System.Web.Mvc.Html;
using CloudCore.Web.Core.BaseModels;

namespace CloudCore.Web.Core.BaseViews.Master
{
    public abstract class CROMaster<T> : FrameworkMaster<T>
    {
        protected override void InitializePage()
        {
            base.InitializePage();
            InitializeCachedReusableObjects();
        }

        protected void InitializeCachedReusableObjects()
        {
            var cachedObjectModel = Model as ICRORenderer;

            if (cachedObjectModel != null)
            {
                if (cachedObjectModel.CanDisplay())
                {
                    DefineSection("CachedReusableObjects", () => Write(Html.Partial("~/Areas/CUI/Views/Shared/PageContext/_PageContext.cshtml", cachedObjectModel.GetCROContent(Url))));
                }
            }
        }
    }
}