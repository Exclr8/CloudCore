using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using CloudCore.VSExtension.Classes.Helpers;
using CloudCore.VSExtension.Controls.Wizard;

namespace CloudCore.VSExtension.Wizards.Create
{
    public partial class ListStoredProcsSheet : CloudCore.VSExtension.Controls.Wizard.IntWizardPage
    {
        private List<MethodInfo> MethodList;

        public ListStoredProcsSheet()
        {
            
            InitializeComponent();
        }

        public override void OnSetActive(CancelEventArgs e)
        {
            MethodList = DataContextHelper.getProcedures(T4CreateViewWizard.TemplateData.ContextReference.DBContextClass.BaseType);
            RefreshLists();
            SetWizardButtons(WizardButtons.Back | WizardButtons.Next);
            base.OnSetActive(e);
        }

        public override void OnWizardNext(WizardPageEventArgs e)
        {
            T4CreateViewWizard.TemplateData.SetStoredProcedureInfo(MethodList.Find(r => r.Name.Equals(lboxAvailable.SelectedItem.ToString())));
            base.OnWizardNext(e);
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            RefreshLists();
        }

        private void RefreshLists()
        {
            lboxAvailable.Items.Clear();

            foreach (var item in MethodList)
            {
                if (item.Name.IndexOf(textBox1.Text, System.StringComparison.CurrentCultureIgnoreCase)>=0 || textBox1.Text == "")
                {
                    lboxAvailable.Items.Add(item.Name);
                }
            }

        }

        /*
        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            foreach (var item in lboxAvailable.SelectedItems)
            {
                T4CreateViewWizard.TemplateData.Fields.Find(r => r.ColumnName == item.ToString()).AddToGrid = true;
            }
            RefreshLists();
        }

        

        private void btnRemove_Click(object sender, System.EventArgs e)
        {
            foreach (var item in lboxForDisplay.SelectedItems)
            {
                T4SearchViewWizard.TemplateData.Columns.Find(r => r.ColumnName == item.ToString()).AddToGrid = false;
            }
            RefreshLists();
        }

        private void lboxAvailable_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            btnAdd_Click(lboxAvailable, null);
        }

        private void lboxForDisplay_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            btnRemove_Click(lboxForDisplay, null);
        }
        */
    }
}
