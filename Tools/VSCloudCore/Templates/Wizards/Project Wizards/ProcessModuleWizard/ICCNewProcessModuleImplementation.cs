using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace CloudCore.VSExtension.Wizards
{
    public class ICCNewProcessModuleImplementation : IWizard
    {
        //private ICCWebModuleForm inputForm;        

        // This method is called before opening any item that 
        // has the OpenInEditor attribute.
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {

        }

        

        // This method is only called for item templates,
        // not for project templates.
        public void ProjectItemFinishedGenerating(ProjectItem
            projectItem)
        {
            
        }

        // This method is called after the project is created.
        public void RunFinished()
        {
        }

        public void RunStarted(object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind, object[] customParams)
        {
            try
            {   
                ICCSIProcessModuleImplementation.InitDictionary();
                ICCSIProcessModuleImplementation.processModuleDictionary["$datalayer.safeprojectname$"] = "missingdatalayer";
                ICCSIProcessModuleImplementation.processModuleDictionary["$datalayer.guid$"] = "5A9BAAFE-658E-4E51-9E2A-DCDDDF724A81";
                // run the wizard here.

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //public static Dictionary<string, string> globalDictionary;

        // This method is only called for item templates,
        // not for project templates.
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}