using CloudCore.Core.VirtualWorker;
using CloudCore.Data;

namespace Core.Common.Tests.Core.VirtualWorker.Instance
{
    public class MockedWorker : Worker
    {
        public int Counter;

        public MockedWorker()
        {
            SleepIntervalTimeInSeconds = 0;
        }

        protected override void StartDiagnosticMonitor()
        { }

        protected override void RegisterWorkerModules()
        { }
    }

    public class WorkflowMockedWorker : MockedWorker
    {
        protected override void OnWorkflowLooped()
        {
            Counter++;

            if (Counter > 10)
            {
                Exit = true;
            }
        }
    }

    public class ScheduledMockedWorker : MockedWorker
    {
        protected override void OnScheduledTaskLooped()
        {
            Counter++;

            if (Counter > 10)
            {
                Exit = true;
            }
        }
    }

    public class FailedScheduledMockedWorker : MockedWorker
    {
        protected override void OnFailedScheduledTaskLooped()
        {
            Counter++;

            if (Counter > 10)
            {
                Exit = true;
            }
        }
    }

    public class WorkflowFailedMockedWorker : MockedWorker
    {
        protected override void OnWorkflowFailedLooped()
        {
            Counter++;

            if (Counter > 10)
            {
                Exit = true;
            }
        }
    }
}