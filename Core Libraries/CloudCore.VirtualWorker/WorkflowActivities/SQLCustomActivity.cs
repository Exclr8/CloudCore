
namespace CloudCore.VirtualWorker.WorkflowActivities
{
    public abstract class SqlCustomActivity : BaseActivity
    {
        public override sealed void OnVirtualWork()
        {
            Database.ExecuteCommand(string.Format(@"exec [cloudcore].[CCEvent_{0}] @InstanceId = {1}, @KeyValue = {2}", 
                                                    SqlItemGuid, 
                                                    WorkflowData.InstanceId, 
                                                    WorkflowData.KeyValue));
        }
    }
}
