using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Architect.ProcessOverview
{
    [ValidationState(ValidationState.Enabled)]
    public partial class SubProcessElement
    {
        [ValidationMethod(CustomCategory = "BrokenSubProcessReferences")]
        private void ValidationMessage(ValidationContext context)
        {
            context.LogError("The sub process file for sub process" + this.Name + " does not exist and has been deleted.  Please make sure you clean up all orphaned files in your project for this missing sub process.", "001", this.Process);
        }
    }
}
