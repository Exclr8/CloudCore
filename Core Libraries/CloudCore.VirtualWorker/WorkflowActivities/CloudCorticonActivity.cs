
namespace CloudCore.VirtualWorker.WorkflowActivities
{
    public abstract class CloudCorticonActivity : BaseActivity
    {
        public abstract void Execute();

        public override sealed void OnVirtualWork()
        {
            // TODO: Implement!!!
            Execute();
        }
    }
}
