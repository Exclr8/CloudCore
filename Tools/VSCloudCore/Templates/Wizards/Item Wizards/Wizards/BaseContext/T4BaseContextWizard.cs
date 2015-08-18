using System.Collections.Generic;
using EnvDTE;
using CloudCore.VSExtension.Classes.Helpers;
using Microsoft.VisualStudio.TemplateWizard;

namespace CloudCore.VSExtension.Wizards
{

    /// <summary>
    /// Serves as a base class for project item template wizards. Provides empty 
    /// implementations for all methods except <see cref="ProjectItemFinishedGenerating"/>.
    /// </summary>
    public partial class T4BaseContextWizard : T4BaseTransformationWizard
    {
        public static BaseContextTemplateData TemplateData = new BaseContextTemplateData();


        public T4BaseContextWizard()
        {
            this.Pages.Add(new DataContextSheet(TemplateData));
            this.Pages.Add(new BaseContextQuerySheet());
            this.Pages.Add(new CROPropertyColumnsSheet());
            this.Pages.Add(new CRODisplayColumnsSheet());
            this.Pages.Add(new BaseContextDetailsSheet());
        }

        public override void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            GenerateT4Item(projectItem, TemplateData, typeof(BaseContextTemplateData));
        }


        protected override void OnWizardFinish()
        {
            this.ItemTemplateParams.Add("$ContextName$", TemplateData.ContextName);
            DataContextHelper.UnloadDataContextsFromMemory();
        }



    }
}
