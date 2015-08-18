using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace CloudCore.VSExtension.Wizards
{
    public class ICCSIVirtualWorkerImplementation : IWizard
    {
        public static Dictionary<string, string> virtualWorkerDictionary;
        
        public static void InitDictionary()
        {
            if (virtualWorkerDictionary == null)
            {
                virtualWorkerDictionary = new Dictionary<string, string>();
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
                ICCSIAzureImplementation.azureDictionary["$virtualworker.guid$"] = replacementsDictionary["$guid1$"].ToString();
                ICCSIAzureImplementation.azureDictionary["$virtualworker.safeprojectname$"] = replacementsDictionary["$safeprojectname$"].ToString();
               
                InitDictionary();
                foreach (var item in virtualWorkerDictionary)
                {
                    replacementsDictionary.Add(item.Key, item.Value);
                }
                replacementsDictionary.Add("$siteconnectionstring$", ICloudCoreSystemImplementation.CloudCoreSettings.ConnectionString);
                replacementsDictionary.Add("$siteservices$", ICloudCoreSystemImplementation.CloudCoreSettings.Services());
                replacementsDictionary.Add("$sitesmtpsettings$", ICloudCoreSystemImplementation.CloudCoreSettings.SmptSettings());
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