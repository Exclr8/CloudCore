using CloudCore.Core.Core.VirtualWorker.Instance.Tasks;
using CloudCore.Core.Workflow;
using CloudCore.Data;

namespace Core.Common.Tests.Core.VirtualWorker.Instance
{
    public class MockFailedWorkflow : FailedWorkflow
    {
        public WorkflowStatusType StatusResult;

        private readonly WorklistItem worklistItem;

        public MockFailedWorkflow(Context context, WorklistItem worklistItem)
            : base(context)
        {
            this.worklistItem = worklistItem;
        }

        protected override WorklistItem GetWorklistItem(CloudCoreDB db)
        {
            return worklistItem;
        }

        protected override WorkflowStatusType HandleWorklistFailure(CloudCoreDB db, long instanceId, int? activityId, string msg, int maxRetries, int retries)
        {
            StatusResult = base.HandleWorklistFailure(db, instanceId, activityId, msg, maxRetries, retries);
            return StatusResult;
        }
    }
}