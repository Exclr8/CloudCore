using System;
using System.ComponentModel;
using CloudCore.VSExtension.Controls.Wizard;

namespace CloudCore.VSExtension.Wizards
{
    public partial class SMTPSettingsSheet : ProjectClasses.WizardSheet
    {
        public SMTPSettingsSheet()
        {
            InitializeComponent();
        }

        public override void OnSetActive(CancelEventArgs e)
        {
            SetWizardButtons(WizardButtons.Next | WizardButtons.Back);

            
            this.txtHostname.Text = ICloudCoreSystemImplementation.CloudCoreSettings.SmtpHost;
            this.txtPort.Text = ICloudCoreSystemImplementation.CloudCoreSettings.SmtpPort;
            this.chkUseService.Checked = ICloudCoreSystemImplementation.CloudCoreSettings.SmtpEnabled;
            this.chkUseSSL.Checked = ICloudCoreSystemImplementation.CloudCoreSettings.SmtpSSLEnabled;
            this.txtUsername.Text = ICloudCoreSystemImplementation.CloudCoreSettings.SmtpUser;
            this.txtPassword.Text = ICloudCoreSystemImplementation.CloudCoreSettings.SmtpPass;
            chkUseService_CheckStateChanged(this, e);
            base.OnSetActive(e);
        }

        public override void OnWizardNext(WizardPageEventArgs e)
        {
            ICloudCoreSystemImplementation.CloudCoreSettings.SmtpHost = this.txtHostname.Text;
            ICloudCoreSystemImplementation.CloudCoreSettings.SmtpPort = this.txtPort.Text;
            ICloudCoreSystemImplementation.CloudCoreSettings.SmtpEnabled = this.chkUseService.Checked;
            ICloudCoreSystemImplementation.CloudCoreSettings.SmtpSSLEnabled = this.chkUseSSL.Checked;
            ICloudCoreSystemImplementation.CloudCoreSettings.SmtpUser = this.txtUsername.Text;
            ICloudCoreSystemImplementation.CloudCoreSettings.SmtpPass = this.txtPassword.Text;
            base.OnWizardNext(e);
        }

        private void chkUseService_CheckStateChanged(object sender, EventArgs e)
        {
            txtPort.Enabled = this.chkUseService.Checked;
            txtHostname.Enabled = this.chkUseService.Checked;
            txtUsername.Enabled = this.chkUseService.Checked;
            txtPassword.Enabled = this.chkUseService.Checked;
            chkUseSSL.Enabled = this.chkUseService.Checked;
        }

    }
}
