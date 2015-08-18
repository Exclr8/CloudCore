using System;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using CloudCore.VSExtension.ProcessProperties;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Flavor;
using Microsoft.VisualStudio.Shell.Interop;
using VsCommands = Microsoft.VisualStudio.VSConstants.VSStd97CmdID;

namespace CloudCore.VSExtension
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid(GuidList.guidProcessModuleString)]
    public class ProcessModule : FlavoredProjectBase, IVsProjectFlavorCfgProvider
    {
        // The IVsProjectFlavorCfgProvider of the inner project.
        // Because we are flavoring the base project directly, it is always null.
        protected IVsProjectFlavorCfgProvider innerVsProjectFlavorCfgProvider = null;

        #region Fields
        private CloudCorePackage package;
        private static Icon projectIcon;

        System.Drawing.Icon icoProcessesOpen = Resources.processes_open;
        System.Drawing.Icon icoProcessesClose = Resources.processes_close;
        System.Drawing.Icon icoActivitiesOpen = Resources.activities_open;
        System.Drawing.Icon icoActivitiesClose = Resources.activities_close;
        System.Drawing.Icon icoScheduledTasksOpen = Resources.scheduledtasks_open;
        System.Drawing.Icon icoScheduledTasksClose = Resources.scheduledtasks_close;
        #endregion

        #region Constructors
        static ProcessModule()
        {
            projectIcon = new Icon(typeof(ProcessModule).Assembly.GetManifestResourceStream("CloudCore.VSExtension.Resources.processmodule.ico"));

        }

        public ProcessModule(CloudCorePackage package)
        {
            this.package = package;
           
        }
        #endregion

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

        protected override void InitializeForOuter(string fileName, string location, string name, uint flags, ref Guid guidProject, out bool cancel)
        {
            base.InitializeForOuter(fileName, location, name, flags, ref guidProject, out cancel);
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
                        property += ';' + typeof(ProcessPropertyPage).GUID.ToString("B");

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
                        else
                        {
                            object objCaption;
                            base.GetProperty(itemId, (int)__VSHPROPID.VSHPROPID_Caption, out objCaption);

                            if (objCaption.ToString().Equals("Processes", StringComparison.CurrentCultureIgnoreCase))
                            {
                                property = null;
                                return VSConstants.E_NOTIMPL;
                            }
                            if (objCaption.ToString().Equals("Activities", StringComparison.CurrentCultureIgnoreCase))
                            {
                                property = null;
                                return VSConstants.E_NOTIMPL;
                            }
                            if (objCaption.ToString().Equals("Scheduled Tasks", StringComparison.CurrentCultureIgnoreCase))
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

                            if (objCaption.ToString().Equals("Processes", StringComparison.CurrentCultureIgnoreCase))
                            {
                                if ((int)__VSHPROPID.VSHPROPID_OpenFolderIconHandle == propId)
                                {
                                    property = icoProcessesOpen.Handle;
                                }
                                else
                                    property = icoProcessesClose.Handle;
                                return VSConstants.S_OK;
                            } else
                                if (objCaption.ToString().Equals("Activities", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    if ((int)__VSHPROPID.VSHPROPID_OpenFolderIconHandle == propId)
                                    {
                                        property = icoActivitiesOpen.Handle;
                                    }
                                    else
                                        property = icoActivitiesClose.Handle;
                                    return VSConstants.S_OK;
                                } else
                                    if (objCaption.ToString().Equals("Scheduled Tasks", StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        if ((int)__VSHPROPID.VSHPROPID_OpenFolderIconHandle == propId)
                                        {
                                            property = icoScheduledTasksOpen.Handle;
                                        }
                                        else
                                            property = icoScheduledTasksClose.Handle;
                                        return VSConstants.S_OK;
                                    }
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

            ProcessPropertyPageProjectFlavorCfg configuration = new ProcessPropertyPageProjectFlavorCfg();

            configuration.Initialize(this, pBaseProjectCfg, cfg);
            ppFlavorCfg = (IVsProjectFlavorCfg)configuration;

            return VSConstants.S_OK;
        }

        
    }
}
