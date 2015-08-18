using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CloudCore.VSExtension.Classes.Helpers;
using CloudCore.VSExtension.Controls.Wizard;
using Microsoft.CSharp;

namespace CloudCore.VSExtension.Wizards
{
    public partial class BaseContextQuerySheet : CloudCore.VSExtension.Controls.Wizard.IntWizardPage
    {

        private CompiledExecution executionEngine;

        public BaseContextQuerySheet()
        {
            InitializeComponent();
        }

        private void SelectDataContextSheet_SetActive(object sender, CancelEventArgs e)
        {
            txtQuery.Text = string.IsNullOrEmpty(T4BaseContextWizard.TemplateData.Query) ? "from a in db.Cloudcore_User select a" : T4BaseContextWizard.TemplateData.Query;
            this.NextButtonEnabled = false;
            lblError.Text = "";
            SetWizardButtons(WizardButtons.Back | WizardButtons.Next);
        }

        private void btnTest_Click(object sender, System.EventArgs e)
        {
            lblError.Text = "";
            btnTest.Enabled = false;
            gridQuery.DataSource = null;

            try
            {
                executionEngine = new CompiledExecution()
                  {
                      Query = txtQuery.Text,
                      ConnectionString = T4BaseContextWizard.TemplateData.ConnectionString,
                      DataAssemblyLocation = T4BaseContextWizard.TemplateData.ContextReference.FullPath,
                      DataContextClassName = T4BaseContextWizard.TemplateData.ContextReference.DBContextClass.FullName
                  };
                gridQuery.DataSource = executionEngine.Execute();
                this.GetColumns(executionEngine.MetaDataMembers);
                T4BaseContextWizard.TemplateData.ContextName = executionEngine.ContextName;
                T4BaseContextWizard.TemplateData.Query = executionEngine.Query;
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
            T4BaseContextWizard.TemplateData.Columns.Clear();

            foreach (var item in columnData)
            {
                T4BaseContextWizard.TemplateData.Columns.Add(new BaseContextDataColumn() { ColumnName = item.Name, DisplayName = Regex.Replace(item.Name, "([a-z])([A-Z])", "$1 $2"), ColumnType = item.PropertyType, IsPrimary = false });
            }
        }

        
    }
}
