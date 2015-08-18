using Microsoft.VisualStudio.Shell;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
using System;
using System.Collections.Generic;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using Microsoft.VisualStudio.TextTemplating.VSHost;
using Microsoft.VisualStudio.TextTemplating;
using System.IO;
using System.Text;
using CloudCore.VSExtension.Controls.Wizard;
using System.ComponentModel;
using System.Windows.Forms;
using EnvDTE100;

namespace CloudCore.VSExtension.Wizards
{

    /// <summary>
    /// Serves as a base class for project item template wizards. Provides empty 
    /// implementations for all methods except <see cref="ProjectItemFinishedGenerating"/>.
    /// </summary>
    public partial class T4BaseTransformationWizard : WizardForm, IWizard
    {
        private DTE _dte;
        private Solution4 _solution;

        public Dictionary<string, string> ItemTemplateParams { get; set; }

        protected DTE dte { get { return _dte; } }
        protected Solution4 solution { get { return _solution; } }

        public class T4Callback : ITextTemplatingCallback
        {
            public List<string> errorMessages = new List<string>();
            public string fileExtension = ".txt";
            public Encoding outputEncoding = Encoding.UTF8;

            public void ErrorCallback(bool warning, string message, int line, int column)
            { errorMessages.Add(message); }

            public void SetFileExtension(string extension)
            { fileExtension = extension; }

            public void SetOutputEncoding(Encoding encoding, bool fromOutputDirective)
            { outputEncoding = encoding; }
        }

        
        // IWizard methods - required to be implemented to complete interface
        public void BeforeOpeningFile(ProjectItem projectItem) {}
        public virtual void ProjectFinishedGenerating(Project project) {}
        public virtual void ProjectItemFinishedGenerating(ProjectItem projectItem) {}
        private bool _Cancelled = false;
        public bool ShouldAddProjectItem(string filePath) { return !_Cancelled; }
        public virtual void RunFinished() { }

        // Engine to generate the T4 item
        protected void GenerateT4Item(ProjectItem projectItem, object viewData, Type ParamType)
        {
            // csitem = projectItem.ContainingProject.
            IServiceProvider serviceProvider = new ServiceProvider(projectItem.DTE as Microsoft.VisualStudio.OLE.Interop.IServiceProvider);

            ITextTemplating t4 = serviceProvider.GetService(typeof(STextTemplating)) as ITextTemplating;
            ITextTemplatingSessionHost sessionHost = t4 as ITextTemplatingSessionHost;
            T4Callback cb = new T4Callback();
            // Create a Session in which to pass parameters:
            sessionHost.Session = sessionHost.CreateSession();
            sessionHost.Session["templateData"] = viewData;

            string fileName = projectItem.Properties.Item("FullPath").Value;
            string fileContent = string.Format("<#@parameter type=\"{0}\" name=\"templateData\"#>", ParamType.ToString()) + File.ReadAllText(fileName);
          
            string result = t4.ProcessTemplate("", fileContent, cb);
            File.WriteAllText(fileName, result, cb.outputEncoding);

            if (cb.errorMessages.Count > 0)
            {
                File.AppendAllLines(fileName, cb.errorMessages);
            }
        }

        

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            this.ItemTemplateParams = replacementsDictionary;
            _dte = (DTE)automationObject;
            _solution = (Solution4)dte.Solution;

            OnWizardStart(automationObject);
            WizardCancel += new CancelEventHandler(OnWizardCancel);

            if (this.Pages.Count > 0)
            {
                this.CenterToScreen();

                System.Windows.Forms.DialogResult dlgResult = this.ShowDialog();

                if (dlgResult == System.Windows.Forms.DialogResult.OK)
                {
                    OnWizardFinish();

                } else
                if (dlgResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    throw new WizardCancelledException();
                }
         
            }
           
        }

        protected virtual void OnWizardCancel(object sender, CancelEventArgs e)
        {
            _Cancelled = true;
        }

        protected virtual void OnWizardStart(object automationObject) { }
        protected virtual void OnWizardFinish() {
        }

    }
}
