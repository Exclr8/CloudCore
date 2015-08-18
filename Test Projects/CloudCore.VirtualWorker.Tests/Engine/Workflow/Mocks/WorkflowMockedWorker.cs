using CloudCore.VirtualWorker.Tests.Mocks;
using CloudCore.VirtualWorker.Threading;

namespace CloudCore.VirtualWorker.Tests.Engine.Workflow.Mocks
{
    public class WorkflowMockedWorker : MockedWorker
    {
        public WorkflowMockedWorker()
        {
            WorkflowMonitorLoopedHandler += () =>
            {
                LoopCount++;

                if (LoopCount >= 2)
                {
                    ExitStrategy.Quitting = true;
                }
            };
        }
    }
}
