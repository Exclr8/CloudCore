using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using EnvDTE100;

namespace CloudCore.VSExtension.Wizards
{
    public class ICCSISharedFilesImplementation : IWizard
    {
        //private ICCWebModuleForm inputForm;
        public static Dictionary<string, string> sharedDictionary;
        private Solution4 solution;

        public static void InitDictionary()
        {
            if (sharedDictionary == null)
            {
                sharedDictionary = new Dictionary<string, string>();
                sharedDictionary.Add("$CompanyName$", ICloudCoreSystemImplementation.CloudCoreSettings.CompanyName);
                sharedDictionary.Add("$ProductName$", ICloudCoreSystemImplementation.CloudCoreSettings.ProductName);
                sharedDictionary.Add("$ProductVersion$", ICloudCoreSystemImplementation.CloudCoreSettings.ProductVersion);
                sharedDictionary.Add("$GeneratedYear$", ICloudCoreSystemImplementation.CloudCoreSettings.GeneratedYear);
                sharedDictionary.Add("$GeneratedFileVersion$", ICloudCoreSystemImplementation.CloudCoreSettings.GeneratedFileVersion);
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
            solution = ((DTE)automationObject).Solution as Solution4;
            try
            {

                InitDictionary();

                foreach (var item in sharedDictionary)
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