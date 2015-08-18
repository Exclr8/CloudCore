using CloudCore.VSExtension.Wizards.ProjectClasses;
using EnvDTE;
using System.Collections.Generic;

namespace CloudCore.VSExtension.Wizards
{
    public class ICloudCoreSystemImplementation : T4BaseTransformationWizard
    {
        public static string CloudCoreVersion = "2015.5.14.1814";
        public static CloudCoreSystemSettings CloudCoreSettings = new CloudCoreSystemSettings();
        public static Dictionary<string, string> GlobalDictionary { get; private set; }

        private static void InitDictionary()
        {
            if (GlobalDictionary == null)
            {
                GlobalDictionary = new Dictionary<string, string>();
            }
        }

        public static void UpdateGlobalKey(string Key, string Value)
        {
            InitDictionary();
            if (!GlobalDictionary.ContainsKey(Key))
            {
                GlobalDictionary.Add(Key, Value);
            }
            else
            {
                GlobalDictionary[Key] = Value;
            }
        }

        public static void GetGlobalKeys(Dictionary<string, string> replacementVars)
        {
            foreach (var item in GlobalDictionary)
            {
                replacementVars.Add(item.Key, item.Value);
            }
        }   


        public ICloudCoreSystemImplementation()
        {
            InitDictionary();
            this.Pages.Add(new SiteDetailsSheet());
            this.Pages.Add(new ConnectionSheet());
            this.Pages.Add(new SMTPSettingsSheet());
            this.Pages.Add(new ClickatellSettingsSheet());
            this.Pages.Add(new PostageSettingsSheet());
        }


        public override void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            GenerateT4Item(projectItem, ICloudCoreSystemImplementation.CloudCoreSettings, typeof(CloudCoreSystemSettings));
        }

        public override void RunFinished()
        {
          //  var solproj = solution.AddSolutionFolder("Shared Files");
          //  solproj.Properties.
            base.RunFinished();
        }


        protected override void OnWizardStart(object automationObject)
        {
            CloudCoreSettings.ProductName = ItemTemplateParams["$safeprojectname$"];
            ICCSIWebModuleImplementation.InitDictionary();
            ICCSIProcessModuleImplementation.InitDictionary();
            ICCSISiteImplementation.InitDictionary();
            ICCSICacheWorkerImplementation.InitDictionary();
            ICCSIVirtualWorkerImplementation.InitDictionary();
            ICCSIAzureImplementation.InitDictionary();
            base.OnWizardStart(automationObject);
        }

        protected override void OnWizardFinish()
        {
            UpdateGlobalKey("$CompanyName$", ICloudCoreSystemImplementation.CloudCoreSettings.CompanyName);
            UpdateGlobalKey("$ProductName$", ICloudCoreSystemImplementation.CloudCoreSettings.ProductName);
            UpdateGlobalKey("$ProductVersion$", ICloudCoreSystemImplementation.CloudCoreSettings.ProductVersion);
            UpdateGlobalKey("$GeneratedYear$", ICloudCoreSystemImplementation.CloudCoreSettings.GeneratedYear);
            UpdateGlobalKey("$GeneratedFileVersion$", ICloudCoreSystemImplementation.CloudCoreSettings.GeneratedFileVersion);
            UpdateGlobalKey("$EncryptionKey$", ICloudCoreSystemImplementation.CloudCoreSettings.EncryptionKey);
            UpdateGlobalKey("$ApplicationKey$", ICloudCoreSystemImplementation.CloudCoreSettings.ApplicationKey);
            UpdateGlobalKey("$ProductDBName$", ICloudCoreSystemImplementation.CloudCoreSettings.GetProductDBName());
            UpdateGlobalKey("$CloudCoreVersion$", ICloudCoreSystemImplementation.CloudCoreVersion);
            UpdateGlobalKey("$Product.Shared$", string.Format("{0}.Shared", ICloudCoreSystemImplementation.CloudCoreSettings.ProductName));
            UpdateGlobalKey("$Product.Lib.Cache$", string.Format("{0}.Cache", ICloudCoreSystemImplementation.CloudCoreSettings.ProductName));
            UpdateGlobalKey("$Product.Lib.Azure$", string.Format("{0}.Azure", ICloudCoreSystemImplementation.CloudCoreSettings.ProductName));
            UpdateGlobalKey("$Product.Lib.Site$", string.Format("{0}.Site", ICloudCoreSystemImplementation.CloudCoreSettings.ProductName));
            UpdateGlobalKey("$Product.Lib.VWorker$", string.Format("{0}.VWorker", ICloudCoreSystemImplementation.CloudCoreSettings.ProductName));
            UpdateGlobalKey("$Product.Lib.Assets$", string.Format("{0}.Assets", ICloudCoreSystemImplementation.CloudCoreSettings.ProductName));
            UpdateGlobalKey("$Product.Lib.Web$", string.Format("{0}.Web", ICloudCoreSystemImplementation.CloudCoreSettings.ProductName));
            UpdateGlobalKey("$Product.Lib.Process$", string.Format("{0}.Process", ICloudCoreSystemImplementation.CloudCoreSettings.ProductName));
            UpdateGlobalKey("$Product.Lib.Data$", string.Format("{0}.Data", ICloudCoreSystemImplementation.CloudCoreSettings.ProductName));
            GetGlobalKeys(ItemTemplateParams);
            base.OnWizardFinish();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ICCSiteInstanceImplementation
            // 
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Name = "ICloudCoreSystemImplementation";
            this.Text = "Configure CloudCore-based System";
            this.ResumeLayout(false);

        }
    }
}