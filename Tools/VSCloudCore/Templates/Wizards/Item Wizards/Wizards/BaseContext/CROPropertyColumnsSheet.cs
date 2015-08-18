using System.ComponentModel;
using CloudCore.VSExtension.Controls.Wizard;

namespace CloudCore.VSExtension.Wizards
{
    public partial class CROPropertyColumnsSheet : CloudCore.VSExtension.Controls.Wizard.IntWizardPage
    {
        public CROPropertyColumnsSheet()
        {
            InitializeComponent();
        }

        public override void OnSetActive(CancelEventArgs e)
        {
            RefreshLists();
            SetWizardButtons(WizardButtons.Back | WizardButtons.Next);
            base.OnSetActive(e);
        }

        public override void OnWizardNext(WizardPageEventArgs e)
        {
 

            base.OnWizardNext(e);
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            foreach (var item in lboxAvailable.SelectedItems)
            {
                T4BaseContextWizard.TemplateData.Columns.Find(r => r.ColumnName == item.ToString()).AddAsProperty = true;
            }
            RefreshLists();
        }

        private void RefreshLists()
        {
            lboxAvailable.Items.Clear();
            lboxAsProperty.Items.Clear();
            foreach (var item in T4BaseContextWizard.TemplateData.Columns)
            {
                if (item.AddAsProperty)
                {
                    lboxAsProperty.Items.Add(item.ColumnName);
                }
                else
                {
                    lboxAvailable.Items.Add(item.ColumnName);
                }
            }

        }

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            foreach (var item in lboxAsProperty.SelectedItems)
            {
                T4BaseContextWizard.TemplateData.Columns.Find(r => r.ColumnName == item.ToString()).AddAsProperty = false;
            }
            RefreshLists();
        }

        private void lboxAvailable_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            btnAdd_Click(lboxAvailable, null);
        }

        private void lboxForDisplay_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            btnRemove_Click(lboxAsProperty, null);
        }

    }
}
