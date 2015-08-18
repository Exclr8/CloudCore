using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Integration;
using Microsoft.VisualStudio.Modeling.Integration.Shell;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Architect
{
    [ValidationState(ValidationState.Enabled)]
    public partial class SubProcess
    {
        [ValidationMethod(ValidationCategories.Open | ValidationCategories.Save | ValidationCategories.Menu)]
        private void ValidateProcessRef(ValidationContext context)
        {
            string fileName = Utilities.GetFileNameForStore(this.Store);

            if (fileName == "")
                return;

            IModelBus modelBus = this.Store.GetService(typeof(SModelBus)) as IModelBus;
            //ModelBusAdapterManager manager = modelBus.FindAdapterManagers(fileName).First();
           // ModelBusReference reference = manager.CreateReference(fileName);
            //ModelBusAdapter adapter = modelBus.CreateAdapter(this.ProcessRef);


            if (this.ProcessRef == null)
            {
                string error = string.Format(System.Globalization.CultureInfo.CurrentUICulture,
                    CustomCode.Validation.ValidationResources.EmptyNameError, "Process Reference");
                context.LogError("SubProcess: " + error, "ModelBus", this);

                return;
            }

            /*var process = adapter.ResolveElementReference(this.ProcessRef);

            if (process == null)
            {
                string error = string.Format(System.Globalization.CultureInfo.CurrentUICulture,
                    CustomCode.Validation.ValidationResources.ProcessNotExist, "Process Reference");
                context.LogError("SubProcess: " + error, "ModelBus", this);

                return;
            }*/
        }

        [ValidationMethod(CustomCategory = "ValidateSubProcessNameExistsBeforeReference")]
        private void ValidateSubProcessNameExistsBeforeReference(ValidationContext context)
        {
            if (String.IsNullOrEmpty(this.SubProcessName))
            {
                string error = string.Format(System.Globalization.CultureInfo.CurrentUICulture,
                 CustomCode.Validation.ValidationResources.ValidateSubProcessNameExistsBeforeReference, "Process Reference");
                context.LogError("SubProcess: " + error, "Name", this);
            }
        }
    }
}
