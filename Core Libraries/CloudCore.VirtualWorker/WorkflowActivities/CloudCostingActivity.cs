
namespace CloudCore.VirtualWorker.WorkflowActivities
{
    public abstract class CloudCostingActivity : BaseActivity
    {
        public abstract decimal Execute();

        public override sealed void OnVirtualWork()
        {
            var costValue = Execute();

            if (costValue != 0)
            {
                ThreadSafeDataAccess.DataAccessOperation(() => Database.Cloudcore_WorkItemFlowCosting(WorkflowData.ActivityId, WorkflowData.InstanceId, costValue));
            }
        }

    }
}
