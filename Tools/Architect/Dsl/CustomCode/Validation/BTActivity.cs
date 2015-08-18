using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Architect.CustomCode.Validation;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Architect
{
    [ValidationState(ValidationState.Enabled)]
    public partial class Activity 
    {
        /// <summary> 
        /// Warning method to ensure that the Name of a Activity is : 
        /// - not empty
        /// </summary>
        /// <param name="context"></param> 
        [ValidationMethod(ValidationCategories.Open | ValidationCategories.Save | ValidationCategories.Menu)]
        private void ValidateAttributeName(ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(Name))
                context.LogError("Activity: " + string.Format(ValidationResources.EmptyNameError, ValidationResources.Activity), ValidationResources.Activity, this);
        }
    }
}
