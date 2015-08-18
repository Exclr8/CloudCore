using System;
using System.ComponentModel;
using CloudCore.VSExtension.Controls.Wizard;

namespace CloudCore.VSExtension.Wizards
{
    public partial class ConnectionSheet : ProjectClasses.WizardSheet
    {
        public ConnectionSheet()
        {
            InitializeComponent();
        }

        public override void OnSetActive(CancelEventArgs e)
        {
            SetWizardButtons(WizardButtons.Next | WizardButtons.Back);


            this.txtConnectionString.Text = ICloudCoreSystemImplementation.CloudCoreSettings.ConnectionString;
            base.OnSetActive(e);
        }

        public override void OnWizardNext(WizardPageEventArgs e)
        {
            ICloudCoreSystemImplementation.CloudCoreSettings.ConnectionString = this.txtConnectionString.Text;
            base.OnWizardNext(e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSiteVersion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}
