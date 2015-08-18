using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CloudCore.VSExtension.Controls.Wizard
{
    public class ExtFinishPage : ExtWizardPage
    {
        public override void OnSetActive(CancelEventArgs e)
        {
            SetWizardButtons(WizardButtons.Back | WizardButtons.Finish);
            base.OnSetActive(e);
        }
    }


}

