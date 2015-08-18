using System;
using CloudCore.VirtualWorker.ScheduledTasks;

namespace CloudCore.VirtualWorker.Tests.Engine.ScheduledTasks.Mocks
{
    public class MockedFailingTask : IScheduledTask
    {
        public void Execute()
        {
            throw new Exception("testing scheduled task failure...");
        }
    }
}
