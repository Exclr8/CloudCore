using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;

namespace Architect
{
    public partial class FlowBuilder
    {
        //Rule Source
        private static bool CanAcceptWorkflowRuleAsSource(WorkflowRule candidate)
        {
            return true;
        }

        private static bool CanAcceptWorkflowRuleAndWorkflowRuleAsSourceAndTarget(WorkflowRule source, WorkflowRule target)
        {
            return source != target;
        }

        private static bool CanAcceptWorkflowRuleAndActivityAsSourceAndTarget(WorkflowRule source, Activity target)
        {
            return true;
        }
    }
}
