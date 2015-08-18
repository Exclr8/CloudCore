using System;
using System.Collections.Generic;
using CloudCore.VirtualWorker.Engine.ScheduledTask;
using CloudCore.VirtualWorker.Tests.Engine.ScheduledTasks.Mocks;

namespace CloudCore.VirtualWorker.Tests.Engine.ScheduledTasks
{
    public static class ScheduledTaskObjectMother
    {
        public static Dictionary<string, Type> GenerateFakeFailingTaskTypes()
        {
            return new Dictionary<string, Type>
            {
                {
                    "_" + Guid.NewGuid().ToString().Replace("-", "_").ToLower(), 
                    typeof (MockedFailingTask)
                },
                {
                    "_" + Guid.NewGuid().ToString().Replace("-", "_").ToLower(), 
                    typeof (MockedFailingTask)
                }
            };
        }

        public static ScheduledTaskExecutionInfo GenerateFakeScheduledTask(int maxRetries = 0, int currentRetries = 0)
        {
            return new FakeScheduledTask(maxRetries, currentRetries);
        }
    }
}