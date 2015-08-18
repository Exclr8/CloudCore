using System.Collections.Generic;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace CloudCore.VSExtension.Wizards
{


    /// <summary>
    /// Serves as a base class for project item template wizards. Provides empty 
    /// implementations for all methods except <see cref="ProjectItemFinishedGenerating"/>.
    /// </summary>
    public partial class T4DetailsFormWizard : T4BaseTransformationWizard
    {
        public static DetailsTemplateData TemplateData = new DetailsTemplateData();

        public T4DetailsFormWizard()
        {
           this. Pages.Add(new DetailsDetailsSheet());
        }

        protected override void OnWizardFinish()
        {
            this.ItemTemplateParams.Add("$ContextName$", TemplateData.ContextName);
        }

        public override void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            GenerateT4Item(projectItem, TemplateData, typeof(DetailsTemplateData));
        }

    }
}
