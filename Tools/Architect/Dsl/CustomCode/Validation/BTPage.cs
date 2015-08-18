using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Validation;
using Architect.CustomCode.Helpers;
using EnvDTE;

namespace Architect
{
    [ValidationState(ValidationState.Enabled)]
    public partial class CloudcoreUser
    {
        /// <summary> /// 
        /// Validation method to ensure that page exists for this activity /// 
        /// </summary> 
        [ValidationMethod(ValidationCategories.Open | ValidationCategories.Save | ValidationCategories.Menu)]
        private void ValidatePageExists(ValidationContext context)
        {
            string itemName = string.Format("{0}.cshtml", this.VisioId.Replace("-", "_"));
            ArchitectDte dte = ArchitectDte.Instance;
            dte.Store = Store;

            if (!SubProcessFiles.CheckFileExists(dte.WebProject, itemName, this.SubProcess.VisioId, FolderName.Views, true))
            {
                string error = string.Format(System.Globalization.CultureInfo.CurrentUICulture,
                    CustomCode.Validation.ValidationResources.PageNotExist, Name, this.SubProcess.SubProcessName);
                context.LogError("Page: " + error, "Page Activity", this);
            }
        }
    }
}
