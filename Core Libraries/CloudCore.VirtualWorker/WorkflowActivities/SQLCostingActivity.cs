using System.Linq;

namespace CloudCore.VirtualWorker.WorkflowActivities
{
    public abstract class SqlCostingActivity : BaseActivity
    {
        public override sealed void OnVirtualWork()
        {
            var cost = Database.ExecuteQuery<decimal>(string.Format(@"select [cloudcore].[CCCost_{0}]({1}, {2})", 
                                                                      SqlItemGuid, 
                                                                      WorkflowData.InstanceId, 
                                                                      WorkflowData.KeyValue))
                                .SingleOrDefault();

            if (cost != 0)
            {
                ThreadSafeDataAccess.DataAccessOperation(() => Database.Cloudcore_WorkItemFlowCosting(WorkflowData.ActivityId, WorkflowData.InstanceId, cost));
            }
        }
    }
}
