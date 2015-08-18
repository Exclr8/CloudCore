using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell.Flavor;

namespace CloudCore.VSExtension
{
    [ComVisible(false)]
    [Guid(GuidList.guidWebModuleFactoryString)]
    public class WebModuleFactory : FlavoredProjectFactoryBase
    {
        private CloudCorePackage package;

        public WebModuleFactory(CloudCorePackage package)
            : base()
        {
            this.package = package;
        }

        protected override object PreCreateForOuter(IntPtr outerProjectIUnknown)
        {
            return new WebModule(this.package, this.package);
        }
    }
}
