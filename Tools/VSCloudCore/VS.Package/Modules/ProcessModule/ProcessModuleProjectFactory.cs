using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell.Flavor;

namespace CloudCore.VSExtension
{
    [ComVisible(false)]
    [Guid(GuidList.guidProcessModuleFactoryString)]
    public class ProcessModuleFactory : FlavoredProjectFactoryBase
    {
        private CloudCorePackage package;

        public ProcessModuleFactory(CloudCorePackage package)
            : base()
        {
            this.package = package;
        }

        protected override object PreCreateForOuter(IntPtr outerProjectIUnknown)
        {
            return new ProcessModule(this.package);
        }
    }
}
