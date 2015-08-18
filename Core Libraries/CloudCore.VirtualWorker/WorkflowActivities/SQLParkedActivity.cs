using System.Linq;

namespace CloudCore.VirtualWorker.WorkflowActivities
{
    public abstract class SqlParkedActivity : BaseActivity
    {
        public override sealed void OnVirtualWork()
        {
            var delayInMinutes = Database.ExecuteQuery<int>(string.Format(@"select [cloudcore].[CCPark_{0}]({1}, {2})", 
                                                                            SqlItemGuid,
                                                                            WorkflowData.InstanceId, 
                                                                            WorkflowData.KeyValue))
                                          .SingleOrDefault();

            DelayWorkItem(delayInMinutes);
        }
    }
}
