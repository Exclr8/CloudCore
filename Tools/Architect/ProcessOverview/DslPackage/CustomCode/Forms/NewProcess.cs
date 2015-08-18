using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Architect.CustomCode.Helpers;
using Architect.ProcessOverview.CustomCode.Forms;
using Architect.ProcessOverview.CustomCode.Helpers;
using EnvDTE;
using Microsoft.VisualStudio.Modeling.Integration;
using Microsoft.VisualStudio.TemplateWizard;

namespace Architect.CustomCode.Forms
{
    public partial class NewProcess : IWizard
    {
        public List<ProjectItem> projectItems = new List<ProjectItem>();
        private string ProcessName = string.Empty;
        private bool runWizard = true;

        // IWizard methods - required to be implemented to complete interface
        public void BeforeOpeningFile(ProjectItem projectItem) { }
        public virtual void ProjectFinishedGenerating(Project project) { }
        public virtual void RunFinished() { }
        protected virtual void OnWizardStart() { }
        protected virtual void OnWizardFinish() { }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            ProcessCreateForm form = new ProcessCreateForm();
            form.ShowDialog();

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                ProcessName = (form.Controls.Find("txtProcessName", true)[0] as TextBox).Text;
                runWizard = true;
            }
            else
            {
                runWizard = false;
                return;
            }
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return runWizard;
        }

        public virtual void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            projectItems.Add(projectItem);

            string folderName = new FileInfo(projectItem.FileNames[0]).DirectoryName;

            if (projectItems.Count() == 2)
            {
                var processFile = projectItems.Where(a => a.Name.EndsWith(".process")).SingleOrDefault();
                var diagramFile = projectItems.Where(a => a.Name.EndsWith(".diagram")).SingleOrDefault();

                ProcessFileHelper.CreateNewProcessOverview(ProcessName, processFile, diagramFile);
            }
        }
    }
}
