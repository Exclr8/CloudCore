using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Data.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CloudCore.VSExtension.Controls.Wizard;
using Microsoft.CSharp;
using System.Data.Linq.Mapping;
using CloudCore.VSExtension.Classes.Helpers;

namespace CloudCore.VSExtension.Wizards
{
    public partial class SearchQuerySheet : CloudCore.VSExtension.Controls.Wizard.IntWizardPage
    {

        public SearchQuerySheet()
        {
            InitializeComponent();
        }

        private void SelectDataContextSheet_SetActive(object sender, CancelEventArgs e)
        {
            txtQuery.Text = string.IsNullOrEmpty(T4SearchViewWizard.TemplateData.Query) ? "from a in db.Cloudcore_User select a" : T4SearchViewWizard.TemplateData.Query;
            this.NextButtonEnabled = false;
            lblError.Text = "";
            SetWizardButtons(WizardButtons.Back | WizardButtons.Next);
        }

        public override void OnWizardNext(WizardPageEventArgs e)
        {
            T4SearchViewWizard.TemplateData.Query = txtQuery.Text;
                base.OnWizardNext(e);

        }

        

        private void btnTest_Click(object sender, System.EventArgs e)
        {
            lblError.Text = "";
            btnTest.Enabled = false;
            gridQuery.DataSource = null;

            try
            {
                CompiledExecution executionEngine = new CompiledExecution()
                {
                    Query = txtQuery.Text,
                    ConnectionString = T4SearchViewWizard.TemplateData.ConnectionString,
                    DataAssemblyLocation = T4SearchViewWizard.TemplateData.ContextReference.FullPath,
                    DataContextClassName = T4SearchViewWizard.TemplateData.ContextReference.DBContextClass.FullName
                };

                gridQuery.DataSource = executionEngine.Execute();
                
                this.GetColumns(executionEngine.MetaDataMembers);
                T4SearchViewWizard.TemplateData.ContextName = executionEngine.ContextName;
                T4SearchViewWizard.TemplateData.Query = executionEngine.Query;
                this.NextButtonEnabled = gridQuery.ColumnCount > 0;

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                this.NextButtonEnabled = false;
                gridQuery.DataSource = null;
            }

            btnTest.Enabled = true;
        }

        private void GetColumns(List<PropertyInfo> columnData)
        {
            T4SearchViewWizard.TemplateData.Columns.Clear();
            if (columnData != null)
            {
                foreach (var item in columnData)
                {
                    T4SearchViewWizard.TemplateData.Columns.Add(new SearchDataColumn() { ColumnName = item.Name, DisplayName = Regex.Replace(item.Name, "([a-z])([A-Z])", "$1 $2"), ColumnType = item.PropertyType, IsPrimary = false });
                }
            }
        }

        
    }
}
