using CloudCore.Domain.Workflow;
using CloudCore.VirtualWorker.Engine.Workflow;

namespace CloudCore.VirtualWorker.Tests.Engine.Workflow.Mocks
{
    public class MockNormalWorkflowEngine : NormalWorkflowEngine
    {
        public WorkItemStatus StatusResult;

        private readonly WorklistItem _worklistItem;

        public MockNormalWorkflowEngine(WorkflowContext context, WorklistItem worklistItem)
            : base(context)
        {
            ExitStrategy.Quitting = false;
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
