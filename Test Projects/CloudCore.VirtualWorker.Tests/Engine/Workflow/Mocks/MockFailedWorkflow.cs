using CloudCore.Domain.Workflow;
using CloudCore.VirtualWorker.Engine.Workflow;

namespace CloudCore.VirtualWorker.Tests.Engine.Workflow.Mocks
{
    public class MockFailedWorkflowEngine : FailedWorkflowEngine
    {
        public WorkItemStatus StatusResult;

        private readonly WorklistItem _worklistItem;

        public MockFailedWorkflowEngine(WorkflowContext context, WorklistItem worklistItem)
            : base(context)
        {
            ExitStrategy.Quitting = false; // <<==== IMPORTANT! Otherwise the engine "loop" will just quit before it has even started
            _worklistItem = worklistItem;

            FinalStatusOutcomeDeterminedHandler += outcomeStatusId =>
            {
                StatusResult = outcomeStatusId;
                ExitStrategy.Quitting = true;
            };
        }

        protected override WorklistItem GetWorklistItem()
        {
            return _worklistItem;
        }

        protected override void UpdateFailureOutcome(long instanceId, string message, WorkItemStatus outcome) { }
    }
}