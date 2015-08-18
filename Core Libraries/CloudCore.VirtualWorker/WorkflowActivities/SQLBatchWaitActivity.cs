using System.Linq;

namespace CloudCore.VirtualWorker.WorkflowActivities
{
    public abstract class SqlBatchWaitActivity : BaseActivity
    {
        public override sealed void OnVirtualWork()
        {
            var delayInMinutes = Database.ExecuteQuery<int>(string.Format(@"select [cloudcore].[CCBatchWait_{0}]({1}, {2})", 
                                                                            SqlItemGuid, 
                                                                            WorkflowData.InstanceId, 
                                                                            WorkflowData.KeyValue))
                                          .SingleOrDefault();
            DelayWorkItem(delayInMinutes);
        }
    }
}
