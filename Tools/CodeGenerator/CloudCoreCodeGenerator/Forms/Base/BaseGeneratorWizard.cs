using System;
using System.Collections.Generic;
using FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Data;
using FrameworkOne.VS.Controls.Wizard;

namespace FrameworkOne.CloudCoreCodeGenerator.Forms.Base
{
    public abstract partial class BaseGeneratorWizard : WizardForm
    {
        protected abstract void SetPages(List<WizardPage> pages);

        public BaseGeneratorWizard()
        {
            if (!(WizardDataStore.Data is IBaseData))
                throw new Exception("Make sure your data is of type IBaseData.");

            InitializeComponent();

            SetPages(Pages);

            this.Width = 761;
            this.Height = 444;
        }

        
    }
}
