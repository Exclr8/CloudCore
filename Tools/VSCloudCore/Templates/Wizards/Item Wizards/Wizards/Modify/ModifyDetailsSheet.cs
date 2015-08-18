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
    public partial class ModifyDetailsSheet : CloudCore.VSExtension.Controls.Wizard.IntWizardPage
    {
        public ModifyDetailsSheet()
        {
            InitializeComponent();
        }

        public string ModuleNamespace { get { return txtModuleNamespace.Text; } set { txtModuleNamespace.Text = value; } }
        public string ContextName { get { return txtContextName.Text; } set { txtContextName.Text = value; } }


        public override void OnSetActive(CancelEventArgs e)
        {
         //  this.txtPageTitle = T4DetailsFormWizard.TemplateData.
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
