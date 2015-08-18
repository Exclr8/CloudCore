using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell.Flavor;

namespace CloudCore.VSExtension
{
    [ComVisible(false)]
    [Guid(GuidList.guidCloudCoreSiteFactoryString)]
    public class SiteFactory : FlavoredProjectFactoryBase
    {
        private CloudCorePackage package;

        public SiteFactory(CloudCorePackage package)
            : base()
        {
            this.package = package;
        }

        protected override object PreCreateForOuter(IntPtr outerProjectIUnknown)
        {
            return new CloudCoreSite(this.package);
        }
    }
}
