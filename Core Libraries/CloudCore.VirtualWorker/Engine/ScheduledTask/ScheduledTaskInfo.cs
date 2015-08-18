using System;

namespace CloudCore.VirtualWorker.Engine.ScheduledTask
{
    public class ScheduledTaskExecutionInfo
    {
        public int ScheduledTaskId { get; set; }
        public Guid ScheduledTaskGuid { get; set; }
        public ExecutionType ScheduledTaskType { get; set; }
        public string ScheduledTaskName { get; set; }
        public int MaximumRetries { get; set; }
        public int CurrentRetries { get; set; }
    }
}
