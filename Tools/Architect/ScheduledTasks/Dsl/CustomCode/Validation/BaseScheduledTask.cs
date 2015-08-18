using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Validation;
using Architect.ScheduledTasks.CustomCode.Validation;

namespace Architect.ScheduledTasks
{
    [ValidationState(ValidationState.Enabled)]
    public partial class BaseScheduledTask
    {
        [ValidationMethod (ValidationCategories.Open | ValidationCategories.Save | ValidationCategories.Menu ) ]
        private void ValidateScheduledTaskName(ValidationContext context)
        {
            if (string.IsNullOrEmpty(this.Name) || string.IsNullOrWhiteSpace(this.Name))
                context.LogError(Validation.STaskNameEmpty, Validation.STaskNameEmptyErrorCode, this);

            if (this.Name.Length > 50)
                context.LogError(Validation.STaskNameLength, Validation.STaskNameLengthCode, this);
        }

        [ValidationMethod(ValidationCategories.Open | ValidationCategories.Save | ValidationCategories.Menu)]
        private void ValidateScheduledTaskInterval(ValidationContext context)
        {
            if (this.Interval <= 0)
                context.LogError(Validation.STaskIntervalLessThanOrEqualToZero, Validation.STaskIntervalLessThanOrEqualToZeroCode, this);
        }

        [ValidationMethod(ValidationCategories.Open | ValidationCategories.Save | ValidationCategories.Menu)]
        private void ValidateScheduledTaskDate(ValidationContext context)
        {
            if (this.StartDate <= DateTime.Now)
                context.LogError(Validation.STaskDateInvalid, Validation.STaskDateInvalidCode, this);
        }
    }
}
