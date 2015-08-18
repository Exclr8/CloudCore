using System.Collections.Generic;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace CloudCore.VSExtension.Wizards
{


    /// <summary>
    /// Serves as a base class for project item template wizards. Provides empty 
    /// implementations for all methods except <see cref="ProjectItemFinishedGenerating"/>.
    /// </summary>
    public partial class T4LookupFormWizard : T4BaseTransformationWizard
    {
        private LookupTemplateData templateData = TemplateTestData.GetLookupViewData();


        protected override void OnWizardFinish()
        {
            this.ItemTemplateParams.Add("$ContextName$", templateData.ContextName);
        }

        public override void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            GenerateT4Item(projectItem, templateData, typeof(LookupTemplateData));
        }

    }
}
