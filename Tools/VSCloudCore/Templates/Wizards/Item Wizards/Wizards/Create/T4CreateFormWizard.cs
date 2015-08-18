using System.Collections.Generic;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using CloudCore.VSExtension.Wizards.Create;

namespace CloudCore.VSExtension.Wizards
{


    /// <summary>
    /// Serves as a base class for project item template wizards. Provides empty 
    /// implementations for all methods except <see cref="ProjectItemFinishedGenerating"/>.
    /// </summary>
    public partial class T4CreateViewWizard : T4BaseTransformationWizard
    {
        public static CreateTemplateData TemplateData = new CreateTemplateData();

        public T4CreateViewWizard()
        {
            this.Pages.Add(new DataContextSheet(TemplateData));
            this.Pages.Add(new ListStoredProcsSheet());
            this.Pages.Add(new CreateDetailsSheet());
        }


        protected override void OnWizardFinish()
        {
            this.ItemTemplateParams.Add("$ContextName$", TemplateData.ContextName);
        }

        public override void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            GenerateT4Item(projectItem, TemplateData, typeof(CreateTemplateData));
        }

    }
}
