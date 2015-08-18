using System.Collections.Generic;
using CloudCore.VirtualWorker.Engine.ScheduledTask;
using CloudCore.VirtualWorker.Threading;

namespace CloudCore.VirtualWorker.Tests.Engine.ScheduledTasks.Mocks
{
    public class MockedFailedScheduledTaskEngine : FailedScheduledTaskEngine
    {
        public ScheduledTaskStatusId StatusResult;
        private readonly ScheduledTaskExecutionInfo _getReturnItem;

        public MockedFailedScheduledTaskEngine(ScheduledTaskMonitorContext context, ScheduledTaskExecutionInfo fakeItemForGetScheduledTasksToRun = null)
            : base(context)
        {
            ExitStrategy.Quitting = false; // <<==== IMPORTANT! Otherwise the engine "loop" will just quit before it has even started
            _getReturnItem = fakeItemForGetScheduledTasksToRun;

            FinalStatusOutcomeDeterminedHandler += outcomeStatusId =>
            {
                StatusResult = outcomeStatusId;
                ExitStrategy.Quitting = true;
            };

        }

        protected override List<ScheduledTaskExecutionInfo> GetScheduledTasksToRun()
        {
            if (_getReturnItem == null)
                return base.GetScheduledTasksToRun();

            return new List<ScheduledTaskExecutionInfo> { _getReturnItem };
        }
        
        protected override void UpdateFailureOutcome(int scheduledTaskId, string message, ScheduledTaskStatusId outcome) { }
        protected override void SendFailureReportViaEmail(int scheduledTaskId, string errorMessage) { }
    }
}
