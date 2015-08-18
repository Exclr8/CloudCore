
namespace CloudCore.VirtualWorker.WorkflowActivities
{
    public abstract class CloudParkedActivity : BaseActivity
    {
        public abstract int Execute();

        public override sealed void OnVirtualWork()
        {
            DelayWorkItem(Execute());
        }
    }
}
