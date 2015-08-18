using System;
using CloudCore.VirtualWorker.WorkflowActivities;

namespace CloudCore.VirtualWorker.Tests.Engine.Workflow.Mocks
{
    public class _57953b5b_1e35_45ff_950b_100c2566c843 : BaseActivity
    {
        public override void OnVirtualWork()
        {
            throw new Exception("testing activity failure");
        }
    }

    public class _2333cd82_1bc3_4a55_8c93_33e189600b33 : BaseActivity
    {
        public override void OnVirtualWork()
        {
            throw new Exception("testing activity failure");
        }
    }
}
