using System.Linq;

namespace CloudCore.VirtualWorker.WorkflowActivities
{
    public abstract class SqlWorkflowRuleActivity : BaseActivity
    {
        public override sealed void OnVirtualWork()
        {
            Outcome = Database.ExecuteQuery<string>(string.Format(@"select [cloudcore].[CCWorkflowRule_{0}]({1}, {2})", 
                                                                    SqlItemGuid, 
                                                                    WorkflowData.InstanceId, 
                                                                    WorkflowData.KeyValue))
                               .SingleOrDefault();
        }
    }
}
