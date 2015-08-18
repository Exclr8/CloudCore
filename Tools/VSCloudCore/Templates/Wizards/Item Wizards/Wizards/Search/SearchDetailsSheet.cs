using System;
using System.ComponentModel;
using CloudCore.VSExtension.Controls.Wizard;

namespace CloudCore.VSExtension.Wizards
{
    public partial class SearchDetailsSheet : CloudCore.VSExtension.Controls.Wizard.IntWizardPage
    {
        public SearchDetailsSheet()
        {
            InitializeComponent();
        }

        public override void OnSetActive(CancelEventArgs e)
        {
            txtContextName.Text = T4SearchViewWizard.TemplateData.ContextName;
            txtContextTitle.Text = T4SearchViewWizard.TemplateData.Title;
            txtPageTitle.Text = T4SearchViewWizard.TemplateData.PageTitle;
            cmbKeyField.Items.Clear();
            foreach (var item in T4SearchViewWizard.TemplateData.Columns)
            {
                if (item.ColumnType == typeof(int) || item.ColumnType == typeof(long) || item.ColumnType == typeof(Int64) || item.ColumnType == typeof(Int32))
                {
                    cmbKeyField.Items.Add(item.ColumnName);
                }
            }
            var oldKeyField = T4SearchViewWizard.TemplateData.PrimaryKey;
            if (oldKeyField != null)
            {
               cmbKeyField.SelectedIndex = cmbKeyField.FindStringExact(oldKeyField.ColumnName);
            } else
              cmbKeyField.SelectedIndex = 0;

            cmbKeyDisplay.Items.Clear();
            foreach (var item in T4SearchViewWizard.TemplateData.Columns)
            {
                if (item.AddToGrid)
                {
                    cmbKeyDisplay.Items.Add(item.ColumnName);
                }
            }
            var oldKeyDisplay = T4SearchViewWizard.TemplateData.PrimaryDisplay;
            if (oldKeyDisplay != null)
            {
                cmbKeyDisplay.SelectedIndex = cmbKeyDisplay.FindStringExact(oldKeyDisplay.ColumnName);
            }
            else
                cmbKeyDisplay.SelectedIndex = 0;

            SetWizardButtons(WizardButtons.Back | WizardButtons.Finish);
            base.OnSetActive(e);
        }

        public override void OnWizardFinish(WizardPageEventArgs e)
        {
            T4SearchViewWizard.TemplateData.ContextName = txtContextName.Text;
            T4SearchViewWizard.TemplateData.Title = txtContextTitle.Text;
            T4SearchViewWizard.TemplateData.PageTitle = txtPageTitle.Text;
            var oldKeyField = T4SearchViewWizard.TemplateData.PrimaryKey;
            if (oldKeyField != null)
            {
                oldKeyField.IsPrimary = false;
            }
            var newKeyField = T4SearchViewWizard.TemplateData.Columns.Find(r => r.ColumnName == cmbKeyField.SelectedItem.ToString());
            if (newKeyField != null)
            {
                newKeyField.IsPrimary = true;
            }

            var oldKeyDisplay = T4SearchViewWizard.TemplateData.PrimaryDisplay;
            if (oldKeyDisplay != null)
            {
                oldKeyDisplay.IsPrimaryDisplay = false;
            }
            var newKeyDisplay = T4SearchViewWizard.TemplateData.Columns.Find(r => r.ColumnName == cmbKeyDisplay.SelectedItem.ToString());
            if (newKeyDisplay != null)
            {
                newKeyDisplay.IsPrimaryDisplay = true;
            }
            base.OnWizardFinish(e);
        }

    }
}
