using CloudCore.VirtualWorker.Tests.Mocks;
using CloudCore.VirtualWorker.Threading;
// ReSharper disable once RedundantUsingDirective (To shut up when in release mode)
using System;

namespace CloudCore.VirtualWorker.Tests.Threading.Mocks
{
    public class WorkerFailingThreadCallbackMockedWorker : MockedWorker
    {
        public WorkerFailingThreadCallbackMockedWorker()
        {
                PrepareThreadCrashSimulation();
                ListenForThreadRestartEvents();
        }

        private void ListenForThreadRestartEvents()
        {
            ThreadCrashMonitorLoopedHandler += ExpediteExitStrategy;
        }

        private void PrepareThreadCrashSimulation()
        {
            FaultedThreadRestartedHandler += ExpediteExitStrategy;
#if DEBUG

            UnsafeCallbackHandler += () =>
            {
               throw new Exception("simulating a thread crash..."); 
            };
#endif            
        }

        private void ExpediteExitStrategy()
        {
            LoopCount++;

            if (LoopCount >= 2)
            {
                ExitStrategy.Quitting = true;
            }
        }
    }
}
