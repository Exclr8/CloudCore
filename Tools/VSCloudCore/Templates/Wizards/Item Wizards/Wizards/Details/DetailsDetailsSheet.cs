using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudCore.VSExtension.Controls.Wizard;

namespace CloudCore.VSExtension.Wizards
{
    public partial class DetailsDetailsSheet : CloudCore.VSExtension.Controls.Wizard.IntWizardPage
    {
        public DetailsDetailsSheet()
        {
            InitializeComponent();
        }

        public string ModuleNamespace { get { return txtModuleNamespace.Text; } set { txtModuleNamespace.Text = value; } }
        public string ContextName { get { return txtContextName.Text; } set { txtContextName.Text = value; } }


        public override void OnSetActive(CancelEventArgs e)
        {
            this.txtPageTitle.Text = T4DetailsFormWizard.TemplateData.PageTitle;
            base.OnSetActive(e);
        }

        public override void OnWizardFinish(WizardPageEventArgs e)
        {
            base.OnWizardFinish(e);
        }

        private void AddItemDetailsSheet_SetActive(object sender, CancelEventArgs e)
        {
            SetWizardButtons(WizardButtons.Finish);
        }

        

    }
}
