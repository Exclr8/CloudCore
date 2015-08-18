using CloudCore.VirtualWorker.Tests.Mocks;
using CloudCore.VirtualWorker.Threading;

namespace CloudCore.VirtualWorker.Tests.Engine.ScheduledTasks.Mocks
{
    public class MockedNormalScheduledTaskWorker : MockedWorker
    {
        public MockedNormalScheduledTaskWorker() : base()
        {
            ScheduledTaskMonitorLoopedHandler += () =>
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
