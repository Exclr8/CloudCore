using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace CloudCore.VSExtension.Wizards
{
    public class ICCSIWebModuleImplementation : IWizard
    {

        public static Dictionary<string, string> webModuleDictionary;
        
        public static void InitDictionary()
        {
            if (webModuleDictionary == null)
            {
                webModuleDictionary = new Dictionary<string, string>();
                webModuleDictionary.Add("$webmodule.areaname$", "MyArea");
                webModuleDictionary.Add("$datalayer.safeprojectname$", "");
                webModuleDictionary.Add("$datalayer.guid$", "");
                webModuleDictionary.Add("$ProductDBName$", "base");
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
                // for site instances
                ICCSISiteImplementation.InitDictionary();
                ICCSISiteImplementation.siteDictionary["$webmodule.safeprojectname$"] = replacementsDictionary["$safeprojectname$"].ToString();
                ICCSISiteImplementation.siteDictionary["$webmodule.guid$"] = replacementsDictionary["$guid1$"].ToString();

                // Add custom parameters.
                InitDictionary();
                
                foreach (var item in webModuleDictionary)
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