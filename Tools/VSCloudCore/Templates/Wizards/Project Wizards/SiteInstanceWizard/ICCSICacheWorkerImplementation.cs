using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace CloudCore.VSExtension.Wizards
{
    public class ICCSICacheWorkerImplementation : IWizard
    {
        private static Dictionary<string, string> _cacheWorkerDictionary;
        
        public static void InitDictionary()
        {
            if (_cacheWorkerDictionary == null)
            {
                _cacheWorkerDictionary = new Dictionary<string, string>();
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
                ICCSIAzureImplementation.InitDictionary();
                ICCSIAzureImplementation.azureDictionary["$cacherole.guid$"] = replacementsDictionary["$guid1$"];
                ICCSIAzureImplementation.azureDictionary["$cacherole.safeprojectname$"] = replacementsDictionary["$safeprojectname$"];
               
                InitDictionary();
                foreach (var item in _cacheWorkerDictionary)
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
