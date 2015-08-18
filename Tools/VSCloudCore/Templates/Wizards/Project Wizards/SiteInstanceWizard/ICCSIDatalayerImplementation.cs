using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace CloudCore.VSExtension.Wizards
{
    public class ICCSIDatalayerImplementation : IWizard
    {


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
                ICCSISiteImplementation.InitDictionary();
                ICCSISiteImplementation.siteDictionary["$datalayer.safeprojectname$"] = replacementsDictionary["$safeprojectname$"].ToString();
                ICCSISiteImplementation.siteDictionary["$datalayer.guid$"] = replacementsDictionary["$guid1$"].ToString();

                ICCSIWebModuleImplementation.InitDictionary();
                ICCSIWebModuleImplementation.webModuleDictionary["$datalayer.safeprojectname$"] = replacementsDictionary["$safeprojectname$"].ToString();
                ICCSIWebModuleImplementation.webModuleDictionary["$datalayer.guid$"] = replacementsDictionary["$guid1$"].ToString();

                ICCSIProcessModuleImplementation.InitDictionary();
                ICCSIProcessModuleImplementation.processModuleDictionary["$datalayer.safeprojectname$"] = replacementsDictionary["$safeprojectname$"].ToString();
                ICCSIProcessModuleImplementation.processModuleDictionary["$datalayer.guid$"] = replacementsDictionary["$guid1$"].ToString();
                ICloudCoreSystemImplementation.GetGlobalKeys(replacementsDictionary);
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