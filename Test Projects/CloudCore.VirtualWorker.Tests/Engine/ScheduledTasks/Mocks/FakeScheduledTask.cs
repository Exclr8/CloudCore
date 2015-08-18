using System;
using CloudCore.VirtualWorker.Engine;
using CloudCore.VirtualWorker.Engine.ScheduledTask;

namespace CloudCore.VirtualWorker.Tests.Engine.ScheduledTasks.Mocks
{
    public class FakeScheduledTask : ScheduledTaskExecutionInfo
    {
        public FakeScheduledTask(int maxRetries = 0, int currentRetries = 0)
        {
            var random = new Random();
            ScheduledTaskId = random.Next(244, 18335);
            CurrentRetries = currentRetries;
            MaximumRetries = maxRetries;
            ScheduledTaskGuid = Guid.NewGuid();
            ScheduledTaskName = "Fake Scheduled Task";
            ScheduledTaskType = ExecutionType.CSharp;
        }
    }
}
