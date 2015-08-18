using System;
using System.Diagnostics;
using System.Linq;
using CloudCore.VirtualWorker.Engine;
using CloudCore.VirtualWorker.Tests.Mocks;
using CloudCore.VirtualWorker.Tests.Threading.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.VirtualWorker.Tests
{
    [TestClass]
    public class WorkerInstanceTests
    {
        #region Tests

        [TestMethod]
        public void CanStartWorker()
        {
            var worker = new MockedWorker();
            var started = worker.OnStart();
            Assert.IsTrue(started);
        }

        [TestMethod]
        [TestCategory("Long-running tests")]
        public void Worker_StartAndRun_WasAllOperationsKickedOff()
        {
            var worker = StartFakeWorker<CheckOperationCountMockedWorker>();
            var engineCount = worker.ActiveEngines.Count(engine => engine.EngineType != EngineType.KeepAlive);

            Assert.AreEqual(6, engineCount);
        }

        private static MockedWorker StartFakeWorker<T>() where T : MockedWorker
        {
            var worker = Activator.CreateInstance<T>();
            worker.OnStart();
            worker.Run();
            return worker;
        }

#if !DEBUG
        /* this to simulate a crash from within the main worker loops. The 
         * crash could be due to unreliable developer plugins, or operating 
         * system difficulties. Threads should be restarted automatically,
         * and errors logged. The code that crashes the threads is hard-coded
         * and should NOT be in the production / release build. */
        [Ignore]
#endif
        [TestMethod]
        [Timeout(30000)]
        [TestCategory("Long-running tests")]
        public void Worker_ThreadCrashMonitor_IsLoopRunning()
        {
            var worker = StartFakeWorker<WorkerFailingThreadCallbackMockedWorker>();
            Assert.IsTrue(worker.LoopCount >= 2, "The thread crash monitor loop engine could not restart crashed threads. The number of the worker execution loops for the crash monitor was less than 2 (the minimum loop count required to pass the test)!");
        }

        #endregion
    }
}
