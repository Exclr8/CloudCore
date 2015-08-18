
namespace CloudCore.VirtualWorker.WorkflowActivities
{
    public abstract class CloudCustomActivity : BaseActivity
    {
        public abstract void Execute();

        public override sealed void OnVirtualWork()
        {
            Execute();
        }
    }
}
