using EnvDTE;

namespace CloudCore.VSExtension.Wizards
{

    /// <summary>
    /// Serves as a base class for project item template wizards. Provides empty 
    /// implementations for all methods except <see cref="ProjectItemFinishedGenerating"/>.
    /// </summary>
    public partial class T4DashboardWizard : T4BaseTransformationWizard
    {
        public static DashboardData TemplateData = new DashboardData();

        public T4DashboardWizard()
        {
            this.Pages.Add(new DashboardTypeSheet());
        }

        public override void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            GenerateT4Item(projectItem, TemplateData, typeof(DashboardData));
        }

        protected override void OnWizardFinish()
        {
            this.ItemTemplateParams.Add("$ContextName$", TemplateData.ContextName);
        }
    }
}
