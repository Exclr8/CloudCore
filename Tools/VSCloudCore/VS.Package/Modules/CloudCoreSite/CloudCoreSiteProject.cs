using System;
using System.Drawing;
using System.Runtime.InteropServices;
using CloudCore.VSExtension.SiteProperties;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Flavor;
using Microsoft.VisualStudio.Shell.Interop;

namespace CloudCore.VSExtension
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid(GuidList.guidCloudCoreSiteString)]
    public class CloudCoreSite : FlavoredProjectBase//, IVsProjectFlavorCfgProvider
    {
        // The IVsProjectFlavorCfgProvider of the inner project.
        // Because we are flavoring the base project directly, it is always null.
        protected IVsProjectFlavorCfgProvider innerVsProjectFlavorCfgProvider = null;

        private CloudCorePackage package;
        private static Icon projectIcon;



        static CloudCoreSite()
        {
            projectIcon = new Icon(typeof(ProcessModule).Assembly.GetManifestResourceStream("CloudCore.VSExtension.Resources.siteinstance.ico"));

        }

        public CloudCoreSite(CloudCorePackage package)
        {
            this.package = package;
         
        }


        protected override void SetInnerProject(IntPtr innerIUnknown)
        {
            object inner = null;

            inner = Marshal.GetObjectForIUnknown(innerIUnknown);

            if (base.serviceProvider == null)
            {
                base.serviceProvider = this.package;
            }

            base.SetInnerProject(innerIUnknown);

            this.innerVsProjectFlavorCfgProvider = inner as IVsProjectFlavorCfgProvider;
        }

        
        protected override void Close()
        {
            base.Close();
            if (innerVsProjectFlavorCfgProvider != null)
            {
                if (Marshal.IsComObject(innerVsProjectFlavorCfgProvider))
                {
                    Marshal.ReleaseComObject(innerVsProjectFlavorCfgProvider);
                }
                innerVsProjectFlavorCfgProvider = null;
            }
        }
       
        protected override int GetProperty(uint itemId, int propId, out object property)
        {
            switch (propId)
            {
                    
                case (int)__VSHPROPID2.VSHPROPID_CfgPropertyPagesCLSIDList:
                    {
                        // Get a semicolon-delimited list of clsids of the configuration-dependent
                        // property pages.
                        ErrorHandler.ThrowOnFailure(base.GetProperty(itemId, propId, out property));

                        // Add the ProcessPropertyPage property page.
                        property += ';' + typeof(ACSPropertyPage).GUID.ToString("B");

                        return VSConstants.S_OK;
                    } 
                case (int)__VSHPROPID.VSHPROPID_IconIndex:
                case (int)__VSHPROPID.VSHPROPID_OpenFolderIconIndex:
                    {
                        if (itemId == VSConstants.VSITEMID_ROOT)
                        {
                            property = null;
                            //Forward to __VSHPROPID.VSHPROPID_IconHandle and __VSHPROPID.VSHPROPID_OpenFolderIconHandle propIds
                            return VSConstants.E_NOTIMPL;
                        }
                       

                        break;
                    }
                case (int)__VSHPROPID.VSHPROPID_IconHandle:
                case (int)__VSHPROPID.VSHPROPID_OpenFolderIconHandle:
                    {
                        if (itemId == VSConstants.VSITEMID_ROOT && projectIcon != null)
                        {

                            property = projectIcon.Handle;
                            return VSConstants.S_OK;
                        }


                        break;
                    }
            }

            return base.GetProperty(itemId, propId, out property);
        }

        
        public int CreateProjectFlavorCfg(IVsCfg pBaseProjectCfg, out IVsProjectFlavorCfg ppFlavorCfg)
        {
            IVsProjectFlavorCfg cfg = null;

            if (innerVsProjectFlavorCfgProvider != null)
            {
                innerVsProjectFlavorCfgProvider.CreateProjectFlavorCfg(pBaseProjectCfg, out cfg);
            }

            ACSPropertyPageProjectFlavorCfg configuration = new ACSPropertyPageProjectFlavorCfg();

            configuration.Initialize(this, pBaseProjectCfg, cfg);
            ppFlavorCfg = (IVsProjectFlavorCfg)configuration;

            return VSConstants.S_OK;
        }
        
    }
}
