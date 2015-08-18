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

namespace CloudCore.VSExtension.Wizards.WebProjectWizard
{
    public partial class ModuleInformation : CloudCore.VSExtension.Controls.Wizard.IntWizardPage
    {
        public ModuleInformation()
        {
            InitializeComponent();
        }

        public string ModuleNamespace { get { return txtModuleNamespace.Text; } set { txtModuleNamespace.Text = value; } }
        public string AreaName { get { return txtAreaName.Text; } set { txtAreaName.Text = value; } }


        private void ModuleInformation_SetActive(object sender, CancelEventArgs e)
        {
            SetWizardButtons(WizardButtons.Finish);
        }

    }
}
