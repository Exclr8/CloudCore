using EnvDTE;

namespace CloudCore.VSExtension.Wizards
{

    /// <summary>
    /// Serves as a base class for project item template wizards. Provides empty 
    /// implementations for all methods except <see cref="ProjectItemFinishedGenerating"/>.
    /// </summary>
    public partial class T4SearchViewWizard : T4BaseTransformationWizard
    {
        public static SearchTemplateData TemplateData = new SearchTemplateData();

        public T4SearchViewWizard()
        {
            this.Pages.Add(new DataContextSheet(TemplateData));
            this.Pages.Add(new SearchQuerySheet());
            this.Pages.Add(new SearchGridColumnsSheet());
            this.Pages.Add(new SearchFilterColumnsSheet());
            this.Pages.Add(new SearchDetailsSheet());
        }

        public override void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            GenerateT4Item(projectItem, TemplateData, typeof(SearchTemplateData));
        }

        protected override void OnWizardFinish()
        {
            this.ItemTemplateParams.Add("$ContextName$", TemplateData.ContextName);           
        }
    }
}
