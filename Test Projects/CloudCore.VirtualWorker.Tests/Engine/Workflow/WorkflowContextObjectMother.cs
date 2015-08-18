using CloudCore.Core.Logging;
using CloudCore.VirtualWorker.Engine.Workflow;
using CloudCore.VirtualWorker.Threading;
using CloudCore.VirtualWorker.Threading.Workflow;

namespace CloudCore.VirtualWorker.Tests.Engine.Workflow
{
    public static class WorkflowContextObjectMother
    {
        public static WorkflowContext GenerateWorkflowContextWithFailingActivities(ExitStrategy exitStrategy)
        {
            return new WorkflowContext(sleepIntervalTimeInSeconds: 0,
                                       locationConfig: null,
                                       activityTypes: ActivityObjectMother.GenerateFakeFailingActivities(),
                                       loggingCategory: LogCategories.FailingWorkflowEngine,
                                       threadSafeDataAccess: new FailingWorkflowThreadSafeDataAccess(),
                                       exitStrategy: exitStrategy,
                                       onEngineRevolutionCallBack: () => { exitStrategy.Quitting = true; },
                                       parallelThreadCount:-1);
        }
    }
}