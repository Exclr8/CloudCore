using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Architect
{
    [ValidationState(ValidationState.Enabled)]
    public partial class Stop
    {
        
        [ValidationMethod(ValidationCategories.Save)]
        private void ValidateAllStopToFlow(ValidationContext context)
        {
            if (this is ToProcessConnector)
                return;

            if (SourceActivities.Count == 0 && SourceActs.Count == 0 && SActivity.Count == 0)
            {
                string error = string.Format(System.Globalization.CultureInfo.CurrentUICulture,
                    CustomCode.Validation.ValidationResources.ValidateInFlow, Name);
                context.LogError("Stop: " + error, "Flow", this);
            }

            if (!(SubProcess.Activities.Where(a => a is Stop).Any()))
            {
                string error = string.Format(System.Globalization.CultureInfo.CurrentUICulture,
                                   CustomCode.Validation.ValidationResources.ValidateOutFlow, Name);
                context.LogError("Stop: No Stop Found", "Flow", this);
            }
        }


    }
}
