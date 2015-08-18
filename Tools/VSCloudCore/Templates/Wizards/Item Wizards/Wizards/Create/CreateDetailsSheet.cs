using System;
using System.ComponentModel;
using CloudCore.VSExtension.Controls.Wizard;

namespace CloudCore.VSExtension.Wizards.Create
{
    public partial class CreateDetailsSheet : CloudCore.VSExtension.Controls.Wizard.IntWizardPage
    {
        public CreateDetailsSheet()
        {
            InitializeComponent();
        }

        public override void OnSetActive(CancelEventArgs e)
        {
            txtContextName.Text = T4CreateViewWizard.TemplateData.ContextName;
            txtPageTitle.Text = T4CreateViewWizard.TemplateData.PageTitle;
            cmbKeyField.Items.Clear();
            foreach (var item in T4CreateViewWizard.TemplateData.Fields)
            {
                if (item.IsByReference)
                {
                    cmbKeyField.Items.Add(item.ColumnName);
                }
            }
            var oldKeyField = T4SearchViewWizard.TemplateData.PrimaryKey;
            if (oldKeyField != null)
            {
               cmbKeyField.SelectedIndex = cmbKeyField.FindStringExact(oldKeyField.ColumnName);
            } else
              cmbKeyField.SelectedIndex = -1;

           

            SetWizardButtons(WizardButtons.Back | WizardButtons.Finish);
            base.OnSetActive(e);
        }

        public override void OnWizardFinish(WizardPageEventArgs e)
        {
            T4CreateViewWizard.TemplateData.ContextName = txtContextName.Text;
            T4CreateViewWizard.TemplateData.PageTitle = txtPageTitle.Text;
            var oldKeyField = T4CreateViewWizard.TemplateData.PrimaryKey;
            if (oldKeyField != null)
            {
                oldKeyField.IsPrimary = false;
            }

            if (cmbKeyField.SelectedItem != null)
            {
                var newKeyField = T4CreateViewWizard.TemplateData.Fields.Find(r => r.ColumnName == cmbKeyField.SelectedItem.ToString());
                if (newKeyField != null)
                {
                    newKeyField.IsPrimary = true;
                }
            }
            
            base.OnWizardFinish(e);
        }

    }
}
