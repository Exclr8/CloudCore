using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Flavor;
using Microsoft.VisualStudio.Shell.Interop;
using System.Linq;
using ShellConstants = Microsoft.VisualStudio.Shell.Interop.Constants;
using VsCommands = Microsoft.VisualStudio.VSConstants.VSStd97CmdID;

namespace CloudCore.VSExtension
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid(GuidList.guidWebModuleString)]
    public class WebModule : FlavoredProjectBase
    {
        private CloudCorePackage package;
        private static Icon projectIcon;
        private static Icon icoActivitiesOpen;
        private static Icon icoActivitiesClose;
        private static Icon icoCROOpen;
        private static Icon icoCROClose;


        static WebModule()
        {
            projectIcon = new Icon(typeof(WebModule).Assembly.GetManifestResourceStream("CloudCore.VSExtension.Resources.webmodule.ico"));
            icoActivitiesOpen = new Icon(typeof(WebModule).Assembly.GetManifestResourceStream("CloudCore.VSExtension.Resources.activities_open.ico"));
            icoActivitiesClose = new Icon(typeof(WebModule).Assembly.GetManifestResourceStream("CloudCore.VSExtension.Resources.activities_close.ico"));
            icoCROOpen = new Icon(typeof(WebModule).Assembly.GetManifestResourceStream("CloudCore.VSExtension.Resources.CRO_open.ico"));
            icoCROClose = new Icon(typeof(WebModule).Assembly.GetManifestResourceStream("CloudCore.VSExtension.Resources.CRO_close.ico"));
        }

        public WebModule(CloudCorePackage package, System.IServiceProvider site)
        {
            this.package = package;
            this.serviceProvider = site;
           
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
        }

        protected override void InitializeForOuter(string fileName, string location, string name, uint flags, ref Guid guidProject, out bool cancel)
        {
            base.InitializeForOuter(fileName, location, name, flags, ref guidProject, out cancel);
        }

        /*
        protected override Guid GetGuidProperty(uint itemId, int propId)
        {
            try
            {
                if (propId == (int)__VSHPROPID2.VSHPROPID_AddItemTemplatesGuid)
                {
                    return typeof(WebModuleFactory).GUID;
                }
                return base.GetGuidProperty(itemId, propId);
            }
            catch { // we leave this empty ... for some reason MS doesnt care 
                return Guid.Empty;
            }

        }
        */

        protected override int GetProperty(uint itemId, int propId, out object property)
        {
            switch (propId)
            {
                case (int)__VSHPROPID.VSHPROPID_IconIndex:
                case (int)__VSHPROPID.VSHPROPID_OpenFolderIconIndex:
                    {
                        if (itemId == VSConstants.VSITEMID_ROOT)
                        {
                            property = null;
                            //Forward to __VSHPROPID.VSHPROPID_IconHandle and __VSHPROPID.VSHPROPID_OpenFolderIconHandle propIds
                            return VSConstants.E_NOTIMPL;
                        }
                        else
                        {
                            object objCaption;
                            base.GetProperty(itemId, (int)__VSHPROPID.VSHPROPID_Caption, out objCaption);

                          
                            if (objCaption.ToString().Equals("Activities", StringComparison.CurrentCultureIgnoreCase))
                            {
                                property = null;
                                return VSConstants.E_NOTIMPL;
                            }
                            if (objCaption.ToString().Equals("CRO", StringComparison.CurrentCultureIgnoreCase))
                            {
                                property = null;
                                return VSConstants.E_NOTIMPL;
                            }
   
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
                        else
                        {
                            object objCaption;
                            base.GetProperty(itemId, (int)__VSHPROPID.VSHPROPID_Caption, out objCaption);

                            
                                if (objCaption.ToString().Equals("Activities", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    if ((int)__VSHPROPID.VSHPROPID_OpenFolderIconHandle == propId)
                                    {
                                        property = icoActivitiesOpen.Handle;
                                    }
                                    else
                                        property = icoActivitiesClose.Handle;
                                    return VSConstants.S_OK;
                                }

                                if (objCaption.ToString().Equals("CRO", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    if ((int)__VSHPROPID.VSHPROPID_OpenFolderIconHandle == propId)
                                    {
                                        property = icoCROOpen.Handle;
                                    }
                                    else
                                        property = icoCROClose.Handle;
                                    return VSConstants.S_OK;
                                }
                        }


                        break;
                    }
            }

            return base.GetProperty(itemId, propId, out property);
        }

       
    }
}
