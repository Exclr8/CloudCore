using System;
using System.ComponentModel;
using CloudCore.VSExtension.Controls.Wizard;

namespace CloudCore.VSExtension.Wizards
{
    public partial class PostageSettingsSheet : ProjectClasses.WizardSheet
    {
        public PostageSettingsSheet()
        {
            InitializeComponent();
        }

        public override void OnSetActive(CancelEventArgs e)
        {
            SetWizardButtons(WizardButtons.Finish | WizardButtons.Back);

            
            this.txtPostageUrl.Text = ICloudCoreSystemImplementation.CloudCoreSettings.PostageUrl;
            this.txtPostageAPIKey.Text = ICloudCoreSystemImplementation.CloudCoreSettings.PostageAPIKey;
            this.chkUseService.Checked = ICloudCoreSystemImplementation.CloudCoreSettings.PostageEnabled;
            chkUseService_CheckStateChanged(this, e);
            base.OnSetActive(e);
        }

        public override void OnWizardFinish(WizardPageEventArgs e)
        {
            ICloudCoreSystemImplementation.CloudCoreSettings.PostageUrl = this.txtPostageUrl.Text;
            ICloudCoreSystemImplementation.CloudCoreSettings.PostageAPIKey = this.txtPostageAPIKey.Text;
            ICloudCoreSystemImplementation.CloudCoreSettings.PostageEnabled = this.chkUseService.Checked;
            base.OnWizardFinish(e);
        }

        private void chkUseService_CheckStateChanged(object sender, EventArgs e)
        {
            txtPostageAPIKey.Enabled = this.chkUseService.Checked;
            txtPostageUrl.Enabled = this.chkUseService.Checked;
        }

    }
}
