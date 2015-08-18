using CloudCore.Core.Logging;
using CloudCore.VirtualWorker.Engine.ScheduledTask;
using CloudCore.VirtualWorker.Threading;
using CloudCore.VirtualWorker.Threading.Workflow;

namespace CloudCore.VirtualWorker.Tests.Engine.ScheduledTasks
{
    public static class ScheduledTaskContextObjectMother
    {
        public static ScheduledTaskMonitorContext GenerateFakeScheduledTaskContextWithFailingTasks(ExitStrategy exitStrategy)
        {
            return new ScheduledTaskMonitorContext(sleepIntervalTimeInSeconds: 0,
                                                   scheduledTaskTypes: ScheduledTaskObjectMother.GenerateFakeFailingTaskTypes(),
                                                   loggingCategory: LogCategories.FailingScheduledTaskMonitor,
                                                   exitStrategy: exitStrategy,
                                                   threadSafeDataAccess: new FailingWorkflowThreadSafeDataAccess(),
                                                   onEngineRevolutionCallBack: () => { exitStrategy.Quitting = true; });
        }
    }
}
