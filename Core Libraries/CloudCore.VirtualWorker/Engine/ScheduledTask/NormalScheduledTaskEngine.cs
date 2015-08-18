using System.Collections.Generic;

namespace CloudCore.VirtualWorker.Engine.ScheduledTask
{
    public class NormalScheduledTaskEngine : ScheduledTaskBaseOperation
    {
        public NormalScheduledTaskEngine(ScheduledTaskMonitorContext context) : base(context) { }

        protected override List<ScheduledTaskExecutionInfo> GetScheduledTasksToRun()
        {
            return GetScheduledTasksToRun(ScheduledTaskStatusId.Pending);
        }

        protected override ScheduledTaskStatusId GetFailureStatusOutcome(int maxRetries, int retries)
        {
            return maxRetries > 0 ? ScheduledTaskStatusId.Retry : ScheduledTaskStatusId.Failed;
        }
    }
}

