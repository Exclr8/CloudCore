using System.Collections.Generic;

namespace CloudCore.VirtualWorker.Engine.ScheduledTask
{
    public class FailedScheduledTaskEngine : ScheduledTaskBaseOperation
    {
        public FailedScheduledTaskEngine(ScheduledTaskMonitorContext context) : base(context) { }

        protected override List<ScheduledTaskExecutionInfo> GetScheduledTasksToRun()
        {
            return GetScheduledTasksToRun(ScheduledTaskStatusId.Retry);
        }

        protected override ScheduledTaskStatusId GetFailureStatusOutcome(int maxRetries, int retries)
        {
            return retries < maxRetries ? ScheduledTaskStatusId.Retry : ScheduledTaskStatusId.Failed;
        }
    }
}
