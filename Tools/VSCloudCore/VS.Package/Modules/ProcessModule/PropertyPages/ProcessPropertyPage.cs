using System;
using System.Runtime.InteropServices;
using CloudCore.VSExtension.PropertyPages.Base;

namespace CloudCore.VSExtension.ProcessProperties
{
    [Guid(GuidList.guidProcessModule_PP_String)]
    class ProcessPropertyPage : PropertyPage
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
            return new ProcessPropertyPageView(this);
        }

        protected override IPropertyStore GetNewPropertyStore()
        {
            return new ProcessPropertyPagePropertyStore();
        }
    }
}
