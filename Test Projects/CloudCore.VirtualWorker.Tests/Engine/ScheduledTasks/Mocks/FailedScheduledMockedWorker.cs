using CloudCore.Logging;
using CloudCore.VirtualWorker.Tests.Mocks;
using CloudCore.VirtualWorker.Threading;

namespace CloudCore.VirtualWorker.Tests.Engine.ScheduledTasks.Mocks
{
    public class FailedScheduledMockedWorker : MockedWorker
    {
        public FailedScheduledMockedWorker()
        {
            FailedScheduledTaskMonitorLoopedHandler += () =>
            {
                Logger.Warn("TESTING_FAILING_SCHEDULED_TASK","TEST");
                LoopCount++;

                if (LoopCount >= 2)
                {
                    ExitStrategy.Quitting = true;
                }
            }; 
        }
    }
}
