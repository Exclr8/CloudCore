using System;
using System.ComponentModel;
using CloudCore.VSExtension.Controls.Wizard;

namespace CloudCore.VSExtension.Wizards
{
    public partial class BaseContextDetailsSheet : CloudCore.VSExtension.Controls.Wizard.IntWizardPage
    {
        public BaseContextDetailsSheet()
        {
            InitializeComponent();
        }

        public override void OnSetActive(CancelEventArgs e)
        {
            txtContextName.Text = T4BaseContextWizard.TemplateData.ContextName;
            txtContextTitle.Text = T4BaseContextWizard.TemplateData.Title;
            cmbKeyField.Items.Clear();
            foreach (var item in T4BaseContextWizard.TemplateData.Columns)
            {
                if (item.ColumnType == typeof(int) || item.ColumnType == typeof(long) || item.ColumnType == typeof(Int64) || item.ColumnType == typeof(Int32))
                {
                    cmbKeyField.Items.Add(item.ColumnName);
                }
            }
            var oldKeyField = T4BaseContextWizard.TemplateData.Columns.Find(r => r.IsPrimary == true);
            if (oldKeyField != null)
            {
               cmbKeyField.SelectedIndex = cmbKeyField.FindStringExact(oldKeyField.ColumnName);
            } else
              cmbKeyField.SelectedIndex = 0;
            SetWizardButtons(WizardButtons.Back | WizardButtons.Finish);
            base.OnSetActive(e);
        }

        public override void OnWizardFinish(WizardPageEventArgs e)
        {
            T4BaseContextWizard.TemplateData.ContextName = txtContextName.Text;
            T4BaseContextWizard.TemplateData.Title = txtContextTitle.Text;
            var oldKeyField = T4BaseContextWizard.TemplateData.Columns.Find(r => r.IsPrimary == true);
            if (oldKeyField != null)
            {
                oldKeyField.IsPrimary = false;
            }
            var newKeyField = T4BaseContextWizard.TemplateData.Columns.Find(r => r.ColumnName == cmbKeyField.SelectedItem.ToString());
            if (newKeyField != null)
            {
                newKeyField.IsPrimary = true;
            }
            base.OnWizardFinish(e);
        }

    }
}
