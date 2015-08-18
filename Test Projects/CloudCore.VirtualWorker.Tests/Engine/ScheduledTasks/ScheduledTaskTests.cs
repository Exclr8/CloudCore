using System;
using CloudCore.Core.Tests;
using CloudCore.VirtualWorker.Engine.ScheduledTask;
using CloudCore.VirtualWorker.Tests.Engine.ScheduledTasks.Mocks;
using CloudCore.VirtualWorker.Threading;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.VirtualWorker.Tests.Engine.ScheduledTasks
{
    [TestClass]
    public class ScheduledTaskTest
    {
        #region Setup

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            DeployScheduledTasks();
        }

        private static void DeployScheduledTasks()
        {
            const string scriptName = "ScheduledTasksText";
            var resource = Resources.ResourceManager.GetObject(scriptName);

            if (resource == null)
            {
                throw new ArgumentException(string.Format(@"Could not execute specified T-SQL script file ""{0}"". The embedded resource was not found.", scriptName));
            }

            string scheduledTaskScript = resource.ToString();
            DatabaseSqlExecution.ExecuteSqlScript(scheduledTaskScript);
        }

        #endregion

        #region Tests

        [TestMethod]
        [TestCategory("Long-running Tests")]
        public void Worker_NormalScheduledTaskEngine_IsLoopRunning()
        {
            var worker = new MockedNormalScheduledTaskWorker();
            worker.OnStart();
            worker.Run();
            Assert.IsTrue(worker.LoopCount >= 2);
        }

        [TestMethod]
        [Timeout(40000)]
        [TestCategory("Long-running Tests")]
        public void Worker_FailScheduledTaskEngine_IsLoopRunning()
        {
            var worker = new FailedScheduledMockedWorker();
            worker.OnStart();
            worker.Run();
            Assert.IsTrue(worker.LoopCount >= 2);
        }

        [TestMethod]
        [TestCategory("Long-running Tests")]
        public void ScheduledTaskRetryWhenMaxRetriesNotReached()
        {
            var exitStrategy = new ExitStrategy();
            var context = ScheduledTaskContextObjectMother.GenerateFakeScheduledTaskContextWithFailingTasks(exitStrategy);
            var fakeScheduledTask = ScheduledTaskObjectMother.GenerateFakeScheduledTask(3, 2);
            var mockedFailedScheduledEngine = new MockedFailedScheduledTaskEngine(context);

            mockedFailedScheduledEngine.ExecuteScheduledTask(fakeScheduledTask);

            Assert.AreEqual(ScheduledTaskStatusId.Retry, mockedFailedScheduledEngine.StatusResult);
        }

        [TestMethod]
        [TestCategory("Long-running Tests")]
        public void ScheduledTaskFailWhenMaxRetriesReached()
        {
            var exitStrategy = new ExitStrategy();
            var context = ScheduledTaskContextObjectMother.GenerateFakeScheduledTaskContextWithFailingTasks(exitStrategy);
            var fakeScheduledTask = ScheduledTaskObjectMother.GenerateFakeScheduledTask(3, 3);
            var mockedFailedScheduledEngine = new MockedFailedScheduledTaskEngine(context);

            mockedFailedScheduledEngine.ExecuteScheduledTask(fakeScheduledTask);

            Assert.AreEqual(ScheduledTaskStatusId.Failed, mockedFailedScheduledEngine.StatusResult);
        }

        #endregion

        #region Tear Down

        #endregion
    }
}
