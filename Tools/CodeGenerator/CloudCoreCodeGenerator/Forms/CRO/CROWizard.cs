using System;
using System.Collections.Generic;
using FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Data;
using FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Helpers;
using FrameworkOne.CloudCoreCodeGenerator.Forms.Base;
using FrameworkOne.CloudCoreCodeGenerator.Forms.CRO;
using FrameworkOne.VS.Controls.Wizard;

namespace FrameworkOne.CloudCoreCodeGenerator.Forms.CRO
{
    public partial class CROWizard : BaseGeneratorWizard
    {
        public CROWizard()
        {
            if (!(WizardDataStore.Data is CRO_Data))
                throw new Exception("Make sure your data is of type IBaseData.");
        }

        protected override void SetPages(List<WizardPage> pages)
        {
            WizardPageGroups.AddDataContextWizard(pages, new CROPropertiesPageView());
            WizardPageGroups.AddClassInfoWizard(pages);

            pages.Add(new CROFinish());
        }
    }

    
}
