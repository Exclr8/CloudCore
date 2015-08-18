using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using EnvDTE;
using FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Data;
using FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Helpers;
using FrameworkOne.VS.Controls.Wizard;
using Microsoft.CSharp;
using Microsoft.VisualStudio.Shell;

namespace FrameworkOne.CloudCoreCodeGenerator.Forms.General
{
    public partial class DbContextPage : WizardPage
    {
        private IQueryData data = null;

        private bool _doneTest = false;
        private Assembly _dbAssembly = null;
        private List<KeyValuePair<string, string>> _columns = new List<KeyValuePair<string, string>>();

        public List<KeyValuePair<string, string>> Columns { get { return _columns; } }

        public DbContextPage()
        {
            InitializeComponent();

            data = (IQueryData)WizardDataStore.Data;
        }

        private void dbContextPage_SetActive(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _doneTest = false;
            this.SetWizardButtons(WizardButtons.Next);

            Project p = getProject(((IBaseData)WizardDataStore.Data).FileLocation);

            if (p.Globals["Context"] != null) cmbContexts.Text = p.Globals["Context"].ToString();
            if (p.Globals["Command"] != null) txtCommand.Text = p.Globals["Command"].ToString();
            if (p.Globals["ConnectionString"] != null) txtConnectionString.Text = p.Globals["ConnectionString"].ToString();

            txtCommand.Text = data.Query ?? "from a in db.Cloudcore_User select a";
            txtConnectionString.Text = "Data Source=localhost;Initial Catalog=CloudcoreDb;Integrated Security=SSPI";
        }

        private void dbContextPage_WizardNext(object sender, WizardPageEventArgs e)
        {
            if (!IsFormValid())
            {
                e.Cancel = true;
                return;
            }

            if (_doneTest)
            {
                data.Columns.Clear();

                foreach (var column in Columns)
                {
                    data.Columns.Add(new CRO_DataColumn()
                    {
                        ColumnName = column.Key,
                        VariableType = column.Value,
                        DisplayName = column.Key,
                        IsPrimary = false,
                        IsSelected = true
                    });
                }

                data.ContextName = cmbContexts.Text;
                data.Query = txtCommand.Text;

                Project p = getProject(((IBaseData)WizardDataStore.Data).FileLocation);

                p.Globals["Context"] = cmbContexts.Text;
                p.Globals["Command"] = txtCommand.Text;
                p.Globals["ConnectionString"] = txtConnectionString.Text;

                p.Globals.set_VariablePersists("Context", true);
                p.Globals.set_VariablePersists("Command", true);
                p.Globals.set_VariablePersists("ConnectionString", true);
            }
            else
            {
                ValidationHelper.ShowErrorMessage("You need to run 'Test' before you process", "Please run 'Test'.");
                e.Cancel = true;
                return;
            }
        }
        
         private static Project getProject(string fileLocation)
        {
            DirectoryInfo dir = new DirectoryInfo(fileLocation);

            while (dir.GetFiles("*.csproj").Count() == 0)
            {
                dir = dir.Parent;
            }

            dir = dir.GetDirectories("Properties").FirstOrDefault();
            if (dir == null)
            {
                throw new Exception("Could not find AssemblyInfo.cs. Please ensure AssemblyInfo is located in the Properties folder, which is located in the root of the project where the .csproj file is.");
            }

            var dte = (DTE)Package.GetGlobalService(typeof(DTE));

            Project p = dte.Solution.FindProjectItem(dir.GetFiles("AssemblyInfo.cs").First().FullName).ProjectItems.ContainingProject;
            return p;
        }


        private bool IsFormValid()
        {
            if (!ValidationHelper.IsStringNotNullOrEmpty(txtDLL.Text, "Please select a valid data context DLL", "Invalid Data Context DLL."))
            {
                txtDLL.Focus();
                return false;
            }

            if (!ValidationHelper.IsStringNotNullOrEmpty(txtConnectionString.Text, "Please enter a valid connection string", "Invalid Connection String"))
            {
                txtConnectionString.Focus();
                return false;
            }

            if (!ValidationHelper.IsStringNotNullOrEmpty(cmbContexts.SelectedItem.ToString(), "Please select a data context", "Invalid Data Context"))
            {
                cmbContexts.Focus();
                return false;
            }

            return true;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
           ((IBaseData)data).ResetAllData();

            btnTest.Enabled = false;
            gridTestResults.DataSource = null;

            try
            {
                lblError.Text = "";
                var selectedContext = cmbContexts.SelectedItem.ToString();

                dynamic contextAssembly = getDBContextInstance(
                    dbAssembly: _dbAssembly,
                    connectionString: txtConnectionString.Text,
                    typeName: selectedContext);

                Assembly execAssembly = compileExecuteAssembly(
                    fileName: txtDLL.Text,
                    typeName: selectedContext,
                    queryText: txtCommand.Text
                );

                Type t = execAssembly.GetType("CloudCore.Data.Execute");
                dynamic result = Activator.CreateInstance(t);
                var output = result.ExecuteQuery(contextAssembly);

                gridTestResults.DataSource = output;

                GetColumns(gridTestResults);

                _doneTest = true;
            }
            catch (Exception ex)
            {
                _doneTest = false;
                lblError.Text = "Compile Error: " + ex.Message;
                gridTestResults.DataSource = null;
            }

            btnTest.Enabled = true;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            var result = opnDll.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtDLL.Text = opnDll.FileName;

                _dbAssembly = Assembly.UnsafeLoadFrom(opnDll.FileName);

                AddContextsToCombo(_dbAssembly);
            }
        }

        private void cmbContexts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = sender as ComboBox;
            btnTest.Enabled = !(s.SelectedItem.ToString() == "Please Select");
        }


        private void GetColumns(DataGridView grid)
        {
            _columns.Clear();

            foreach (DataGridViewColumn clm in grid.Columns)
            {
                var clmName = clm.HeaderText;
                var clmType = grid.Rows[0].Cells[clm.Index].ValueType.Name;

                _columns.Add(new KeyValuePair<string, string>(clmName, clmType));
            }
        }

        private Assembly compileExecuteAssembly(string queryText, string typeName, string fileName)
        {
            if (queryText == null)
            {
                throw new ArgumentNullException("queryText");
            }

            CodeDomProvider codeDomProvider = new CSharpCodeProvider();
            CompilerParameters compilerParameters = new CompilerParameters();
            compilerParameters.GenerateExecutable = false;
            compilerParameters.GenerateInMemory = false;
            compilerParameters.IncludeDebugInformation = false;
            compilerParameters.WarningLevel = 3;
            compilerParameters.TreatWarningsAsErrors = false;
            compilerParameters.CompilerOptions = "/optimize";

            List<string> list = new List<string>
			{
				"mscorlib.dll",
				"System.dll",
				"System.Core.dll",
                "System.Data.dll",
                "System.Data.Linq.dll",
                "System.Data.DataSetExtensions.dll",
                "System.Xml.dll",
                "Microsoft.CSharp.dll",
                "System.Xml.Linq.dll",
                fileName
			};

            list.ForEach(i => compilerParameters.ReferencedAssemblies.Add(i));

            string text = string.Format(Resources.ExecuteDBQuery, typeName, queryText);

            try
            {
                CompilerResults compilerResults = codeDomProvider.CompileAssemblyFromSource(
                    compilerParameters,
                    new string[] { text }
                );

                if (compilerResults.Errors.Count > 0)
                {
                    throw new Exception(compilerResults.Errors[0].ErrorText);
                }

                return compilerResults.CompiledAssembly;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private dynamic getDBContextInstance(Assembly dbAssembly, string connectionString, string typeName)
        {
            try
            {
                var type = dbAssembly.GetType(typeName);
                dynamic db = Activator.CreateInstance(type, new string[] { connectionString });

                return db;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddContextsToCombo(Assembly dbAssembly)
        {
            cmbContexts.Items.Clear();
            cmbContexts.Items.Add("Please Select");

            var types = dbAssembly.GetTypes();

            types.Where(f => f.BaseType == typeof(DataContext)).ToList().ForEach(t => cmbContexts.Items.Add(t.FullName));

            cmbContexts.SelectedIndex = 0;
        }

        private void txtCommand_TextChanged(object sender, EventArgs e)
        {
            _doneTest = false;
        }


    }
}
