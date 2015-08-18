using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnvDTE;
using FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Data;
using Microsoft.VisualStudio.Shell;

namespace FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Helpers
{
    public class DteHelper
    {
        public static void AddFileToSolution()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(((IBaseData)WizardDataStore.Data).FileLocation);

                while (dir.GetFiles("*.csproj").Count() == 0)
                {
                    dir = dir.Parent;
                }

                if (dir == null)
                    throw new Exception("Oops could not find your project file.");

                    dir = dir.GetDirectories("Properties").FirstOrDefault();
                if (dir == null)
                {
                    throw new Exception("Could not find AssemblyInfo.cs. Please ensure AssemblyInfo is located in the Properties folder, which is located in the root of the project where the .csproj file is.");
                }

                var dte = (_DTE)Package.GetGlobalService(typeof(_DTE));

                Project p = dte.Solution.FindProjectItem(dir.GetFiles("AssemblyInfo.cs").First().FullName).ProjectItems.ContainingProject;

                ProjectItem file = p.ProjectItems.AddFromFile(((IBaseData)WizardDataStore.Data).FileLocation + ((IBaseData)WizardDataStore.Data).FileName);
            }
            catch (Exception ex)
            {
                
                ValidationHelper.ShowErrorMessage(ex.Message, "And error has occurred");
            }
           
        }
    }
}
