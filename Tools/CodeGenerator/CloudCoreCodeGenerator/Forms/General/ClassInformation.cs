using System.ComponentModel;
using FrameworkOne.VS.Controls.Wizard;
using FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Data;
using FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Helpers;

namespace FrameworkOne.CloudCoreCodeGenerator.Forms.General
{
    public partial class ClassInformation : WizardPage
    {
        private IClassData data = null;

        public ClassInformation()
        {
            InitializeComponent();

            data = ((IClassData)WizardDataStore.Data);

            txtClassName.Focus();
        }

        private void ClassInformation_SetActive(object sender, CancelEventArgs e)
        {
            this.SetWizardButtons(WizardButtons.Next | WizardButtons.Back);

            var fileName = ((IBaseData)data).FileName;

            if (fileName != string.Empty)
                txtClassName.Text = TransformCodeHelpers.CleanClassName(fileName.Substring(0, fileName.IndexOf(".")));
        }

        private void ClassInformation_WizardBack(object sender, WizardPageEventArgs e)
        {
            Save();
        }

        private void Save()
        {
            data.ClassName = txtClassName.Text;
            data.NameSpace = txtNameSpace.Text;
        }

        private void ClassInformation_WizardNext(object sender, WizardPageEventArgs e)
        {
            if (!FormValid())
            {
                e.Cancel = true;
                return;
            }

            Save();
        }

        private bool FormValid()
        {
            if (!ValidationHelper.IsStringNotNullOrEmpty(txtClassName.Text, "Please enter a valid class name", "Invalid Class Name"))
            {
                txtClassName.Focus();
                return false;
            }

            if (!ValidationHelper.IsStringNotNullOrEmpty(txtNameSpace.Text, "Please enter a valid namespace", "Invalid Namespace"))
            {
                txtNameSpace.Focus();
                return false;
            }

            return true;
        }
    }
}
