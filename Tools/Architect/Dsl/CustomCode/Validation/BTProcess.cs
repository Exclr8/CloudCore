using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Architect.CustomCode.Validation;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Architect
{
    [ValidationState(ValidationState.Enabled)]
    public partial class SubProcess
    {
        /// <summary> 
        /// Warning method to ensure that the Name of a Process is : 
        /// - not empty
        /// </summary>
        /// <param name="context"></param> 
        [ValidationMethod(ValidationCategories.Open | ValidationCategories.Save | ValidationCategories.Menu)]
        private void ValidateAttributeName(ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(SubProcessName))
                context.LogError("SubProcess: " + string.Format(ValidationResources.EmptyNameError, ValidationResources.Process), ValidationResources.Process, this);
        }

        [ValidationMethod(ValidationCategories.Save | ValidationCategories.Menu)]
        private void StartableActivitySet(ValidationContext context)
        {
            var startableActivities = this.Activities.OfType<Start>();
            var toProcessConnectorActivities = this.Activities.OfType<ToProcessConnector>();
            var fromProcessConnectorActivities = this.Activities.OfType<FromProcessConnector>();

            if (toProcessConnectorActivities.Count() >= 0 && fromProcessConnectorActivities.Count() == 0)
                if (startableActivities.Count(a => a.IsStartable) == 0)
                    context.LogError("SubProcess: " + ValidationResources.OneStartableActivityMustBeSet, ValidationResources.Process, this);

            if (toProcessConnectorActivities.Count() >= 0 && fromProcessConnectorActivities.Count() > 0)
            {
                if (startableActivities.Count(a => a.IsStartable) == 0)
                    context.LogMessage("SubProcess: " + ValidationResources.OneStartableActivityShouldBeSet, ValidationResources.Process, this);
            }
                
            
        }
    }
}
