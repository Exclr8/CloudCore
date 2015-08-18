using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Architect
{
    [ValidationState(ValidationState.Enabled)]
    public partial class ToProcessConnector
    {
        public string ToActivityId
        {
            get;
            set;
        }

        public string ToProcessId
        {
            get;
            set;
        }

        [ValidationMethod(ValidationCategories.Open | ValidationCategories.Save | ValidationCategories.Menu)]
        private void ValidateToProcessConnectorHasSources(ValidationContext context)
        {
            if (SourceActivities.Count == 0 && SourceActs.Count == 0 && SActivity.Count == 0)
            {
                string error = string.Format(System.Globalization.CultureInfo.CurrentUICulture,
                    CustomCode.Validation.ValidationResources.ValidateInFlowToProcessConnector, Name);
                context.LogError("ToProcessConnector: " + error, "Flow", this);
            }
        }

        [ValidationMethod(ValidationCategories.Open | ValidationCategories.Save | ValidationCategories.Menu)]
        private void ValidateSubProcessActivityHasRef(ValidationContext context)
        {
            if (this.ToProcessConnectorRef == null)
            {
                var error = string.Format(System.Globalization.CultureInfo.CurrentUICulture,
                CustomCode.Validation.ValidationResources.ValidateSubProcessActivityHasSubProcessActivityRef, Name);

                context.LogError("ToProcessConnector: " + error, "Flow", this);
            }
        }
    }

    [ValidationState(ValidationState.Enabled)]
    public partial class FromProcessConnector
    {
        [ValidationMethod(ValidationCategories.Open | ValidationCategories.Save | ValidationCategories.Menu)]
        private void ValidateFromProcessConnectorHasTargets(ValidationContext context)
        {
            if (TargetActivities.Count == 0 && TargetActs.Count == 0 && TActivity.Count == 0)
            {
                string error = string.Format(System.Globalization.CultureInfo.CurrentUICulture,
                    CustomCode.Validation.ValidationResources.ValidateFlowFromProcessConnector, Name);
                context.LogError("FromProcessConnector: " + error, "Flow", this);
            }
        }
    }
}
