using System.ComponentModel;
using FrameworkOne.CloudCoreCodeGenerator.CodeGenerators;
using FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Data;
using FrameworkOne.CloudCoreCodeGenerator.Forms.Base;
using FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Helpers;
using System;

namespace FrameworkOne.CloudCoreCodeGenerator.Forms.CRO
{
    public partial class CROFinish : BaseFinishWizardPage
    {
        public CROFinish()
        {
            InitializeComponent();
        }

        private void CROFinish_WizardFinish(object sender, CancelEventArgs e)
        {
            txtResult.Text = TransformCodeHelpers.TransformTemplates<CRO_Data>(new CROGenerator());
            DteHelper.AddFileToSolution();
        }

    }
}
