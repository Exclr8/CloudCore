using System.ComponentModel;
using CloudCore.VSExtension.Controls.Wizard;

namespace CloudCore.VSExtension.Wizards
{
    public partial class SiteDetailsSheet : ProjectClasses.WizardSheet
    {
        public SiteDetailsSheet()
        {
            InitializeComponent();
        }

        public override void OnSetActive(CancelEventArgs e)
        {
            SetWizardButtons(WizardButtons.Next);

            this.txtCompanyName.Text = ICloudCoreSystemImplementation.CloudCoreSettings.CompanyName;
            this.txtSiteName.Text = ICloudCoreSystemImplementation.CloudCoreSettings.ProductName;
            this.txtSiteVersion.Text = ICloudCoreSystemImplementation.CloudCoreSettings.ProductVersion;
            this.txtEncryptionKey.Text = ICloudCoreSystemImplementation.CloudCoreSettings.EncryptionKey;
            this.txtWebApplicationKey.Text = ICloudCoreSystemImplementation.CloudCoreSettings.ApplicationKey;
            base.OnSetActive(e);
        }

        public override void OnWizardNext(WizardPageEventArgs e)
        {
            ICloudCoreSystemImplementation.CloudCoreSettings.CompanyName = this.txtCompanyName.Text;
            ICloudCoreSystemImplementation.CloudCoreSettings.ProductName = this.txtSiteName.Text;
            ICloudCoreSystemImplementation.CloudCoreSettings.ProductVersion = this.txtSiteVersion.Text;
            ICloudCoreSystemImplementation.CloudCoreSettings.EncryptionKey = this.txtEncryptionKey.Text;
            ICloudCoreSystemImplementation.CloudCoreSettings.ApplicationKey = this.txtWebApplicationKey.Text;
            base.OnWizardNext(e);
        }



    }
}
