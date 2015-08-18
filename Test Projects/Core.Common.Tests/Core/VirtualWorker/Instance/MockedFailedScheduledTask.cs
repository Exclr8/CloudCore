using System.Collections.Generic;
using CloudCore.Core.Core.VirtualWorker.Instance.Tasks;
using CloudCore.Core.Workflow;
using CloudCore.Data;

namespace Core.Common.Tests.Core.VirtualWorker.Instance
{
    public class MockedFailedScheduledTask : FailedScheduledTask
    {
        public ScheduledTaskStatusType StatusResult;
        private readonly Cloudcore_ScheduledTaskListGetResult getReturnItem;

        public MockedFailedScheduledTask(Context context, Cloudcore_ScheduledTaskListGetResult getReturnItem = null)
            : base(context)
        {
            this.getReturnItem = getReturnItem;
        }

        protected override ScheduledTaskStatusType HandleScheduledTaskFailure(int scheduledTaskId, string msg, int maxRetries, int retries)
        {
            StatusResult = base.HandleScheduledTaskFailure(scheduledTaskId, msg, maxRetries, retries);
            return StatusResult;
        }

        protected override List<Cloudcore_ScheduledTaskListGetResult> GetScheduledTasks()
        {
            return new List<Cloudcore_ScheduledTaskListGetResult> { getReturnItem };
        }

        protected override void ProcessFailure(int scheduledTaskId, string msg, ScheduledTaskStatusType statusType)
        {
            
        }

        protected override void SendFailureReportViaEmail(int? scheduledTaskId, string msg)
        {
            
        }
    }
}
