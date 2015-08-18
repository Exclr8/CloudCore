using System;
using System.ComponentModel;
using CloudCore.VSExtension.Controls.Wizard;

namespace CloudCore.VSExtension.Wizards
{
    public partial class ClickatellSettingsSheet : ProjectClasses.WizardSheet
    {
        public ClickatellSettingsSheet()
        {
            InitializeComponent();
        }

        public override void OnSetActive(CancelEventArgs e)
        {
            SetWizardButtons(WizardButtons.Next | WizardButtons.Back);

            
            this.txtClickatellUrl.Text = ICloudCoreSystemImplementation.CloudCoreSettings.ClickatellUrl;
            this.txtClickatellAPIKey.Text = ICloudCoreSystemImplementation.CloudCoreSettings.ClickatellAPIKey;
            this.txtPassword.Text = ICloudCoreSystemImplementation.CloudCoreSettings.ClickatellPass;
            this.txtUsername.Text = ICloudCoreSystemImplementation.CloudCoreSettings.ClickatellUser;
            this.chkUseService.Checked = ICloudCoreSystemImplementation.CloudCoreSettings.PostageEnabled;
            base.OnSetActive(e);
        }

        public override void OnWizardNext(WizardPageEventArgs e)
        {
           
            ICloudCoreSystemImplementation.CloudCoreSettings.ClickatellUrl = this.txtClickatellUrl.Text;
            ICloudCoreSystemImplementation.CloudCoreSettings.ClickatellAPIKey = this.txtClickatellAPIKey.Text;
            ICloudCoreSystemImplementation.CloudCoreSettings.ClickatellEnabled = this.chkUseService.Checked;
            ICloudCoreSystemImplementation.CloudCoreSettings.ClickatellUser = this.txtUsername.Text;
            ICloudCoreSystemImplementation.CloudCoreSettings.ClickatellPass = this.txtPassword.Text;
            base.OnWizardNext(e);
        }

        private void chkUseService_CheckStateChanged(object sender, EventArgs e)
        {
            txtClickatellAPIKey.Enabled = this.chkUseService.Checked;
            txtClickatellUrl.Enabled = this.chkUseService.Checked;
            txtPassword.Enabled = this.chkUseService.Checked;
            txtUsername.Enabled = this.chkUseService.Checked;
           
        }

    }
}
