using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameworkOne.CloudCoreCodeGenerator.CodeGenerators;
using FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Data;
using FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Helpers;
using FrameworkOne.CloudCoreCodeGenerator.Forms.CRO;

namespace FrameworkOne.CloudCoreCodeGenerator.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AddListItems();
        }

        private void AddListItems()
        {
            List<ListViewItem> items = new List<ListViewItem>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsFormValid()) return;

            if (lstViewTemplates.SelectedItems.Count > 0)
            {
                Form frm = getWizardForm(lstViewTemplates.SelectedItems[0].Text);

                if (frm == null) return;

                this.Hide();
                frm.ShowDialog();

                if (frm.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    this.Show();
                }
                else //if (frm.DialogResult != System.Windows.Forms.DialogResult.None)
                {
                    this.Close();
                }
            }
            else
            {
                ValidationHelper.ShowWarningMessage("Please select a FileType to generate", "Please Select Item");
            }
        }

        private bool IsFormValid()
        {
            if (!ValidationHelper.IsStringNotNullOrEmpty(txtTitle.Text, "Please enter a valid title", "Invalid Title"))
            {
                txtTitle.Focus();
                return false;
            }

            if (!ValidationHelper.IsStringNotNullOrEmpty(txtFileLocation.Text, "Please enter a valid file location", "Invalid File Location"))
            {
                txtFileLocation.Focus();
                return false;
            }

            if (!ValidationHelper.DoesDirectoryExist(txtFileLocation.Text, "Please enter a valid file location", "Invalid File Location"))
            {
                txtFileLocation.Focus();
                return false;
            }

            if (!ValidationHelper.IsStringNotNullOrEmpty(txtFileName.Text, "Please enter a valid file name", "Invalid File Name"))
            {
                txtFileName.Focus();
                return false;
            }

            return true;
        }

        private Form getWizardForm(string formType)
        {
            Form frm = null;

            WizardDataStore.Data = null;

            switch (formType)
            {
                case "CRO":

                    WizardDataStore.Data = new CRO_Data();

                    frm = new CROWizard();

                    ((IBaseData)WizardDataStore.Data).Title = txtTitle.Text;
                    ((IBaseData)WizardDataStore.Data).FileName = TransformCodeHelpers.AppendFileExtension(txtFileName.Text, ".cs");
                    ((IBaseData)WizardDataStore.Data).FileLocation = txtFileLocation.Text;
                    
                    break;
                default:
                    break;
            }
            return frm;
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            fldrFileLocation.ShowNewFolderButton = true;
            DialogResult selectFileLocation = fldrFileLocation.ShowDialog();

            if (selectFileLocation == System.Windows.Forms.DialogResult.OK)
            {
                var slash = @"\";

                if (fldrFileLocation.SelectedPath.Last().ToString() == @"\")
                    slash = string.Empty;

                txtFileLocation.Text = fldrFileLocation.SelectedPath + slash;

                txtFileName.Focus();
                
            }
        }
    }
}
