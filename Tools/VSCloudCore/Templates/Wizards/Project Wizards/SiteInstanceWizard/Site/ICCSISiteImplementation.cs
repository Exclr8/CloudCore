using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using EnvDTE;
using CloudCore.VSExtension.Wizards.ProjectClasses;
using Microsoft.VisualStudio.TemplateWizard;

namespace CloudCore.VSExtension.Wizards
{
    public class ICCSISiteImplementation : T4BaseTransformationWizard
    {
        public static Dictionary<string, string> siteDictionary;
        

        public ICCSISiteImplementation()
        {
        }

        public static void InitDictionary()
        {
            if (siteDictionary == null)
            {
                siteDictionary = new Dictionary<string, string>();
                siteDictionary.Add("$webmodule.safeprojectname$", "");
                siteDictionary.Add("$webmodule.guid$", "");
                siteDictionary.Add("$datalayer.safeprojectname$", "");
                siteDictionary.Add("$datalayer.guid$", "");
            }
        }
    

        // This method is only called for item templates,
        // not for project templates.
        public override void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            GenerateT4Item(projectItem, ICloudCoreSystemImplementation.CloudCoreSettings, typeof(CloudCoreSystemSettings));
        }



        protected override void OnWizardStart(object automationObject)
        {
            base.OnWizardStart(automationObject);
            ICCSIAzureImplementation.InitDictionary();
            ICCSIAzureImplementation.azureDictionary["$sitemodule.guid$"] = ItemTemplateParams["$guid1$"].ToString();
            ICCSIAzureImplementation.azureDictionary["$sitemodule.safeprojectname$"] = ItemTemplateParams["$safeprojectname$"].ToString();

            InitDictionary();
            foreach (var item in siteDictionary)
            {
                ItemTemplateParams.Add(item.Key, item.Value);
            }

            ICloudCoreSystemImplementation.GetGlobalKeys(ItemTemplateParams);

            ItemTemplateParams.Add("$siteconnectionstring$", ICloudCoreSystemImplementation.CloudCoreSettings.ConnectionString);
            ItemTemplateParams.Add("$siteservices$", ICloudCoreSystemImplementation.CloudCoreSettings.Services());
            ItemTemplateParams.Add("$sitesmtpsettings$", ICloudCoreSystemImplementation.CloudCoreSettings.SmptSettings());
        }

        protected override void OnWizardFinish()
        {


            base.OnWizardFinish();
        }

        
    }
}