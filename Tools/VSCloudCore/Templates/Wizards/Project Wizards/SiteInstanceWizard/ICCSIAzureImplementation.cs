using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace CloudCore.VSExtension.Wizards
{
    public class ICCSIAzureImplementation : IWizard
    {
        public static Dictionary<string, string> azureDictionary;

        public static void InitDictionary()
        {
            if (azureDictionary == null)
            {
                azureDictionary = new Dictionary<string, string>();
                azureDictionary.Add("$sitemodule.guid$", "");
                azureDictionary.Add("$sitemodule.safeprojectname$", "");
                azureDictionary.Add("$virtualworker.guid$", "");
                azureDictionary.Add("$virtualworker.safeprojectname$", "");
                azureDictionary.Add("$cacherole.guid$", "");
                azureDictionary.Add("$cacherole.safeprojectname$", "");
            }

        }


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
                InitDictionary();
                foreach (var item in azureDictionary)
                {
                    replacementsDictionary.Add(item.Key, item.Value);
                }
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