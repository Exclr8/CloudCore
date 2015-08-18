using System.Collections.Generic;
using CloudCore.Core.Data;
using CloudCore.Core.Modules;
using CloudCore.Logging;
using CloudCore.ProcessTest;

namespace CloudCore.VirtualWorker.Tests.Mocks
{
    public class MockedWorker : Worker
    {
        public int LoopCount;

        public MockedWorker()
        {
            SetSleepInterval();
        }

        protected override int GetWorkflowParallelThreadCount()
        {
            return 2;
        }

        protected override ILogger GetLogger()
        {
            return new DebugLogger();
        }

        private void SetSleepInterval()
        {
            SleepIntervalTimeInSeconds = 1;
        }

        protected override IEnumerable<CloudCoreModule> RegisterWorkerModules()
        {
            return new List<CloudCoreModule>
            {
                new CloudCoreDataModule(),
                new CoreCommonModule(),
                new CloudCoreProcessTestModule()
            };
        }

        protected override void StartDiagnosticMonitor() { }

    }
}