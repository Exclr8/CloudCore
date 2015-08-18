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
    public partial class Group
    {
        [ValidationMethod(ValidationCategories.Open | ValidationCategories.Save | ValidationCategories.Menu)]
        private void ValidateGroupName(ValidationContext context)
        {
            if (string.IsNullOrEmpty(this.GroupName) || string.IsNullOrWhiteSpace(this.GroupName))
                context.LogError(Validation.GroupNameEmpty, Validation.GroupNameEmptyCode, this);

            if (this.GroupName.Length > 50)
                context.LogError(Validation.GroupNameLength, Validation.GroupNameLengthCode, this);
        }
    }
}
