using CloudCore.VSExtension.ProcessProperties;
using CloudCore.VSExtension.SiteProperties;
using CloudCore.VSExtension.Wizards;
using Microsoft.VisualStudio.Shell;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace CloudCore.VSExtension
{
    [ProvideProjectFactory(typeof(CloudCore.VSExtension.WebModuleFactory), "CloudCore Web Module", "CloudCore Module Files (*.csproj);*.csproj", null, null, null,
    LanguageVsTemplate = "CSharp",
    NewProjectRequireNewFolderVsTemplate = true,
    TemplateGroupIDsVsTemplate = "CloudCore",
    ShowOnlySpecifiedTemplatesVsTemplate = false,
    TemplateIDsVsTemplate = "CloudCore")]

    [ProvideProjectFactory(typeof(CloudCore.VSExtension.SiteFactory), "CloudCore Site", "CloudCore Sites (*.csproj);*.csproj", null, null, null,
    LanguageVsTemplate = "CSharp",
    NewProjectRequireNewFolderVsTemplate = true,
    TemplateGroupIDsVsTemplate = "CloudCore",
    ShowOnlySpecifiedTemplatesVsTemplate = false,
    TemplateIDsVsTemplate = "CloudCore")]

    [ProvideObject(typeof(ACSPropertyPage), RegisterUsing = RegistrationMethod.CodeBase)]

    //Process Module Properties Page
    [ProvideObject(typeof(ProcessPropertyPage), RegisterUsing = RegistrationMethod.CodeBase)]

    [ProvideProjectFactory(typeof(CloudCore.VSExtension.ProcessModuleFactory), "CloudCore Process Module", "CloudCore Module Files (*.csproj);*.csproj", null, null, null,
    LanguageVsTemplate = "CSharp",
    NewProjectRequireNewFolderVsTemplate = true,
    TemplateGroupIDsVsTemplate = "CloudCore",
    ShowOnlySpecifiedTemplatesVsTemplate = false,
    TemplateIDsVsTemplate = "CloudCore")]   

    [PackageRegistration(UseManagedResourcesOnly = true, RegisterUsing = RegistrationMethod.CodeBase )]
    [DefaultRegistryRoot("Software\\Microsoft\\VisualStudio\\11.0Exp")]

    /* Below used to generate load key:
    CDPDZMCDD1MAK9IAIQKDP3ZEAQMAKIQ3ZDCQK8R0EMRTMQEDADAIATM2ECIJQMH1RDQTMIJ2CMPRR0C0CTPKADM2CJKCK3DZICQ1Q3Q3ZIPMQ2KQJKR8KMD1QKI1CART
     */
    [ProvideLoadKey("Standard", "1.0", "VSCloudCore", "Exclr8 Business Automation", 1)]
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.

    // This attribute is used to register the information needed to show this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [Guid(GuidList.guidVSCloudCorePkgString)]
    public sealed class CloudCorePackage : Package
    {
        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public CloudCorePackage()
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }

        /////////////////////////////////////////////////////////////////////////////
        // Overridden Package Implementation
        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            Debug.WriteLine (string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
          
            this.RegisterProjectFactory(new ProcessModuleFactory(this));
            this.RegisterProjectFactory(new WebModuleFactory(this));
            this.RegisterProjectFactory(new SiteFactory(this));
            
            base.Initialize();

        }
        #endregion
    }
}
