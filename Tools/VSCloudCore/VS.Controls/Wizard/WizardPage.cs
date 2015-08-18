using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CloudCore.VSExtension.Controls.Wizard
{
    [DefaultEvent("SetActive")]
    public class WizardPage : System.Windows.Forms.UserControl
    {

        public WizardPage()
        {

        }

        protected WizardForm Wizard
        {
            get
            {
                return (WizardForm)this.ParentForm;
            }
        }

        protected bool NextButtonEnabled { get { return Wizard.NextButtonEnabled; } set { Wizard.NextButtonEnabled = value; } }

        protected void SetWizardButtons(WizardButtons buttons)
        {
            Wizard.SetWizardButtons(buttons);
        }

        protected void EnableCancelButton(bool enableCancelButton)
        {
            Wizard.EnableCancelButton(enableCancelButton);
        }

        protected void PressButton(WizardButtons buttons)
        {
            Wizard.PressButton(buttons);
        }

        [Category("Wizard")]
        public event CancelEventHandler SetActive;

        public virtual void OnSetActive(CancelEventArgs e)
        {
            if (SetActive != null)
                SetActive(this, e);
        }

        [Category("Wizard")]
        public event WizardPageEventHandler WizardNext;

        public virtual void OnWizardNext(WizardPageEventArgs e)
        {
            if (WizardNext != null)
                WizardNext(this, e);
        }

        public virtual void OnWizardPreNext() {}

        [Category("Wizard")]
        public event WizardPageEventHandler WizardBack;

        public virtual void OnWizardBack(WizardPageEventArgs e)
        {
            if (WizardBack != null)
                WizardBack(this, e);
        }

        [Category("Wizard")]
        public event WizardPageEventHandler WizardFinish;

        public virtual void OnWizardFinish(WizardPageEventArgs e)
        {
            if (WizardFinish != null)
                WizardFinish(this, e);
        }

        [Category("Wizard")]
        public event CancelEventHandler WizardCancel;

        public virtual void OnWizardCancel(CancelEventArgs e)
        {
            if (WizardCancel != null)
                WizardCancel(this, e);
        }
    }
}
