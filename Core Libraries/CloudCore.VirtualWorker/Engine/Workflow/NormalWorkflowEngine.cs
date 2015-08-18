using CloudCore.Domain.Workflow;

namespace CloudCore.VirtualWorker.Engine.Workflow
{
    public class NormalWorkflowEngine : WorkflowLoopOperation
    {
        public NormalWorkflowEngine(WorkflowContext context) : base(context) { }

        protected override WorkItemStatus GetFailureStatusOutcome(int maxRetries, int retries) // LSP violation
        {
            return maxRetries > 0 ? WorkItemStatus.Retry : WorkItemStatus.Failed;
        }

        protected override WorklistItem GetNonLocationAwareWorklistItem()
        {
            return GetNonLocationAwareWorklistItem(WorkItemStatus.Pending);
        }

        protected override WorklistItem GetLocationAwareWorklistItem()
        {
            return GetLocationAwareWorklistItem(WorkItemStatus.Pending);
        }
    }
}
