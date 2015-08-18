using CloudCore.Domain.Workflow;

namespace CloudCore.VirtualWorker.Engine.Workflow
{
    public class FailedWorkflowEngine : WorkflowLoopOperation
    {
        public FailedWorkflowEngine(WorkflowContext context) : base(context) { }

        protected override WorkItemStatus GetFailureStatusOutcome(int maxRetries, int currentRetries)
        {
            return currentRetries < maxRetries ? WorkItemStatus.Retry : WorkItemStatus.Failed;
        }

        protected override WorklistItem GetNonLocationAwareWorklistItem()
        {
            return GetNonLocationAwareWorklistItem(WorkItemStatus.Retry);
        }

        protected override WorklistItem GetLocationAwareWorklistItem()
        {
            return GetLocationAwareWorklistItem(WorkItemStatus.Retry);
        }
    }
}
