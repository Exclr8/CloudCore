using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CloudCore.VSExtension.Controls.Wizard;
using CloudCore.VSExtension.Wizards.WebProjectWizard;

namespace CloudCore.VSExtension.Wizards
{
    public partial class ICCWebModuleForm : WizardForm
    {
        public ModuleInformation tstPage;
        private Dictionary<string, string> usedDictionary;

        public ICCWebModuleForm()
        {

            tstPage = new ModuleInformation();
            this.Pages.Add(tstPage);
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ICCWebModuleForm
            // 
            this.Name = "ICCWebModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New CloudCore Web Module";
            this.WizardFinish += new CloudCore.VSExtension.Controls.Wizard.WizardPageEventHandler(this.ICCWebModuleForm_WizardFinish);
            this.ResumeLayout(false);

        }


        public DialogResult ShowWizard(ref Dictionary<string, string> replacementsDictionary )
        {
            this.usedDictionary = replacementsDictionary;
            this.tstPage.ModuleNamespace = replacementsDictionary["$ProductName$"].Replace(" ", ".");
            this.tstPage.AreaName = this.tstPage.ModuleNamespace.Contains(".") ? this.tstPage.ModuleNamespace.Substring(0, this.tstPage.ModuleNamespace.IndexOf(".")) : this.tstPage.ModuleNamespace;
            
            return this.ShowDialog();
        }

        private void ICCWebModuleForm_WizardFinish(object sender, WizardPageEventArgs e)
        {
            usedDictionary.Add("$modulenamespace$", tstPage.ModuleNamespace);
            usedDictionary.Add("$registeredareaname$", tstPage.AreaName);
        }

    }
}