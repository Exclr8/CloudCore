using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameworkOne.VS.Controls.Wizard;

namespace FrameworkOne.CloudCoreCodeGenerator.Forms.Base
{
    public partial class BaseFinishWizardPage : ExtFinishPage
    {
        public BaseFinishWizardPage()
        {
            InitializeComponent();
        }

        private void CROFinish_SetActive(object sender, CancelEventArgs e)
        {
            this.SetWizardButtons(WizardButtons.Finish | WizardButtons.Back);
        }


    }
}
