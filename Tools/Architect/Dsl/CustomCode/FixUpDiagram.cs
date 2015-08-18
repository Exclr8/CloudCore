using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Architect
{
    internal sealed partial class FixUpDiagram
    {
        private Microsoft.VisualStudio.Modeling.ModelElement GetParentForWorkflowRule(WorkflowRule childElement)
        {
            return childElement.SubProcess;
        }

        private Microsoft.VisualStudio.Modeling.ModelElement GetParentForCloudcoreUser(CloudcoreUser childElement)
        {
            return childElement.SubProcess;
        }

        private Microsoft.VisualStudio.Modeling.ModelElement GetParentForCloudcoreUser(MobileActivity childElement)
        {
            return childElement.SubProcess;
        }

        private Microsoft.VisualStudio.Modeling.ModelElement GetParentForCloudcoreUser(HybridActivity childElement)
        {
            return childElement.SubProcess;
        }

        private Microsoft.VisualStudio.Modeling.ModelElement GetParentForDatabaseEvent(DatabaseEvent childElement)
        {
            return childElement.SubProcess;
        }

        private Microsoft.VisualStudio.Modeling.ModelElement GetParentForStop(Stop childElement)
        {
            return childElement.SubProcess;
        }

        private Microsoft.VisualStudio.Modeling.ModelElement GetParentForDatabasePark(DatabasePark childElement)
        {
            return childElement.SubProcess;
        }

        private Microsoft.VisualStudio.Modeling.ModelElement GetParentForCloudPark(CloudPark childElement)
        {
            return childElement.SubProcess;
        }

        private Microsoft.VisualStudio.Modeling.ModelElement GetParentForCloudCustom(CloudCustom childElement)
        {
            return childElement.SubProcess;
        }

        private Microsoft.VisualStudio.Modeling.ModelElement GetParentForPostageApp(PostageApp childElement)
        {
            return childElement.SubProcess;
        }

        private Microsoft.VisualStudio.Modeling.ModelElement GetParentForClickatell(Clickatell childElement)
        {
            return childElement.SubProcess;
        }

        private Microsoft.VisualStudio.Modeling.ModelElement GetParentForDatabaseCosting(DatabaseCosting childElement)
        {
            return childElement.SubProcess;
        }
    }
}
