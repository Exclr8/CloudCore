using System.Web.Mvc;
using CloudCore.Web.Core.Helpers.FormLayout;

namespace CloudCore.Web.Core.BaseViews
{
    /// <summary>
    /// Let your popup views inherit this page to use built in cloud core helpers
    /// </summary>
    public abstract class CoreView<T> : WebViewPage<T>
    {
        public FormLayoutHelper<T> FormLayout;

        public override void InitHelpers()
        {
            base.InitHelpers();
            InitialiseFormLayoutHelper();
        }

        private void InitialiseFormLayoutHelper()
        {
            FormLayout = new FormLayoutHelper<T>(ViewContext, Html);
        }
    }
}
