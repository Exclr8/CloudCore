using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudCore.VSExtension.Wizards.ProjectClasses
{
    public class WizardSheet : CloudCore.VSExtension.Controls.Wizard.IntWizardPage
    {
        public override void OnWizardCancel(System.ComponentModel.CancelEventArgs e)
        {
            base.OnWizardCancel(e);
            throw new Exception("You have cancelled. Nothing will be generated");
        }

        public override void OnSetActive(System.ComponentModel.CancelEventArgs e)
        {
            EnableCancelButton(true);
            base.OnSetActive(e);
            
        }
    }

   
}
