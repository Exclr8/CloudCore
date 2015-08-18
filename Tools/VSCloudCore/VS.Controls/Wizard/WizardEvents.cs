using System;
using System.ComponentModel;

namespace CloudCore.VSExtension.Controls.Wizard
{
    public class WizardPageEventArgs : CancelEventArgs
    {
        WizardPage _newPage = null;

        public WizardPage NewPage
        {
            get { return _newPage; }
            set { _newPage = value; }
        }
    }

    public delegate void WizardPageEventHandler(object sender, WizardPageEventArgs e);
}
