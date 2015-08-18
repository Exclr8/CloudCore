using CloudCore.Web.Core.Helpers;

namespace CloudCore.Web.Core.BaseViews
{
    public abstract class WebView<T> : CoreView<T>
    {
        public PopUpHelper<T> PopUps;

        public override void InitHelpers()
        {
            base.InitHelpers();
            InitialisePopUpHelper();
            FormLayout.PopUpHelper = PopUps;
        }

        private void InitialisePopUpHelper()
        {
            PopUps = new PopUpHelper<T>();
            PopUps.Model = this.Model;
            PopUps.Context = this.Context;
            PopUps.Html = this.Html;
        }

        public override void ExecutePageHierarchy()
        {
            base.ExecutePageHierarchy();
            WriteLiteral(this.PopUps.Render(this.Context));
        }
    }
}
