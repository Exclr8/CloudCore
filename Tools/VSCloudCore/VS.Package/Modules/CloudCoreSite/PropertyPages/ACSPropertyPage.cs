using System;
using System.Runtime.InteropServices;
using CloudCore.VSExtension.PropertyPages.Base;

namespace CloudCore.VSExtension.SiteProperties
{
    [Guid(GuidList.guidCloudCoreSite_PP_ACSString)]
    class ACSPropertyPage : PropertyPage
    {
        public override string Title
        {
            get { return "CloudCore"; }
        }

        protected override string HelpKeyword
        {
            get { return string.Empty; }
        }

        protected override IPageView GetNewPageView()
        {
            return new ACSPropertyPageView(this);
        }

        protected override IPropertyStore GetNewPropertyStore()
        {
            return new ACSPropertyPagePropertyStore();
        }
    }
}
