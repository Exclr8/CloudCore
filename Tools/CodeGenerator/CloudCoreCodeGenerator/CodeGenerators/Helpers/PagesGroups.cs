using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Data;
using FrameworkOne.CloudCoreCodeGenerator.Forms.CRO;
using FrameworkOne.CloudCoreCodeGenerator.Forms.General;
using FrameworkOne.VS.Controls.Wizard;

namespace FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Helpers
{
    public abstract class WizardPageGroups
    {
        public static void AddDataContextWizard(List<WizardPage> pages)
        {
            if (!(WizardDataStore.Data is IQueryData))
                throw new Exception("Make sure your data is of type IQueryData");

            pages.Add(new DbContextPage());
        }

        public static void AddDataContextWizard(List<WizardPage> pages, WizardPage propertiesPage)
        {
            if (!(WizardDataStore.Data is IQueryData))
                throw new Exception("Make sure your data is of type IQueryData");

            pages.Add(new DbContextPage());
            pages.Add(propertiesPage);
        }

        public static void AddClassInfoWizard(List<WizardPage> pages)
        {
            if (!(WizardDataStore.Data is IClassData))
                throw new Exception("Make sure your data is of type IBaseData");

            pages.Add(new ClassInformation());
        }
    }
}
