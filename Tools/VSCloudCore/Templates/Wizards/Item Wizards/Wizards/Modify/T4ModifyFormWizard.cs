using System;
using System.Collections.Generic;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace CloudCore.VSExtension.Wizards
{


    /// <summary>
    /// Serves as a base class for project item template wizards. Provides empty 
    /// implementations for all methods except <see cref="ProjectItemFinishedGenerating"/>.
    /// </summary>
    public partial class T4ModifyFormWizard : T4BaseTransformationWizard
    {
        private ModifyTemplateData templateData = TemplateTestData.GetModifyViewData();

        public ModifyDetailsSheet sheetItemDetails;

        public T4ModifyFormWizard()
        {
            // we need at least a contextpage
            sheetItemDetails = new ModifyDetailsSheet();
            this.Pages.Add(sheetItemDetails);
        }

        public override void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            GenerateT4Item(projectItem, templateData, typeof(ModifyTemplateData));
        }

        protected override void OnWizardStart(object automationObject)
        {
            sheetItemDetails.ContextName = templateData.ContextName;
            sheetItemDetails.ModuleNamespace = "Remove this";
            base.OnWizardStart(automationObject);
        }

        protected override void OnWizardFinish()
        {
            templateData.ContextName = sheetItemDetails.ContextName;

            this.ItemTemplateParams.Add("$ContextName$", sheetItemDetails.ContextName);
        }

    }
}
