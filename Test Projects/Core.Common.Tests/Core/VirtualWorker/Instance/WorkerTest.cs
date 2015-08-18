using System;
using CloudCore.Core.Core.VirtualWorker.Instance.Tasks;
using CloudCore.Core.Workflow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Common.Tests.Core.VirtualWorker.Instance
{
    [TestClass]
    public class WorkerTest
    {
        [TestMethod]
        public void CanStartWorker()
        {
            var worker = new MockedWorker();
            var started = worker.OnStart();

            Assert.IsTrue(started);
        }

        #region Workflow

        [TestMethod]
        [Timeout(500)]
        public void CanRunWorkerForWorkflowTask()
        {
            var worker = new WorkflowMockedWorker();

            worker.OnStart();
            worker.Run();

            Assert.IsTrue(worker.Counter >= 10);
        }

        [TestMethod]
        public void CanRunWorkerForFailedWorkflow()
        {
            var worker = new WorkflowFailedMockedWorker();

            worker.OnStart();
            worker.Run();

            Assert.IsTrue(worker.Counter >= 10);
        }

        [TestMethod]
        [Timeout(500)]
        public void WorkflowItemRetryWhenMaxRetriesNotReached()
        {
            var worklistItem = WorkListObjectMother.FailureItem(3);
            var context = WorkflowContextObjectMother.WorkflowContext(worklistItem.ActivityGuid);
            var mockFailedWorkflow = new MockFailedWorkflow(context, worklistItem);

            mockFailedWorkflow.WorkflowLoop();

            Assert.AreEqual(WorkflowStatusType.Retry, mockFailedWorkflow.StatusResult);
        }

        [TestMethod]
        [Timeout(500)]
        public void WorkflowItemFailWhenMaxRetriesReached()
        {
            var worklistItem = WorkListObjectMother.FailureItem(3, 3);
            var context = WorkflowContextObjectMother.WorkflowContext(worklistItem.ActivityGuid);
            var mockFailedWorkflow = new MockFailedWorkflow(context, worklistItem);

            mockFailedWorkflow.WorkflowLoop();

            Assert.AreEqual(WorkflowStatusType.Failed, mockFailedWorkflow.StatusResult);
        }

        #endregion

        #region Scheduled Task

        [TestMethod]
        [Timeout(500)]
        public void CanRunWorkerForScheduledTask()
        {
            var worker = new ScheduledMockedWorker();

            worker.OnStart();
            worker.Run();

            Assert.IsTrue(worker.Counter >= 10);
        }

        [TestMethod]
        [Timeout(500)]
        public void CanRunWorkerForFailedScheduledTask()
        {
            var worker = new FailedScheduledMockedWorker();

            worker.OnStart();
            worker.Run();

            Assert.IsTrue(worker.Counter >= 10);
        }

        [TestMethod]
        [Timeout(500)]
        public void ScheduledTaskRetryWhenMaxRetriesNotReached()
        {
            var exit = false;
            var context = new ScheduledTaskContext(0, () => exit, null, () => exit = true);
            var mockedFailedScheduledTask = new MockedFailedScheduledTask(context);

            mockedFailedScheduledTask.ScheduledTaskExecute(1, Guid.NewGuid(), 1, "TEST", 3, 0);

            Assert.AreEqual(ScheduledTaskStatusType.Retry, mockedFailedScheduledTask.StatusResult);
        }

        [TestMethod]
        [Timeout(500)]
        public void ScheduledTaskFailWhenMaxRetriesReached()
        {
            var exit = false;
            var context = new ScheduledTaskContext(0, () => exit, null, () => exit = true);
            var mockedFailedScheduledTask = new MockedFailedScheduledTask(context);

            mockedFailedScheduledTask.ScheduledTaskExecute(1, Guid.NewGuid(), 1, "TEST", 3, 3);

            Assert.AreEqual(ScheduledTaskStatusType.Failed, mockedFailedScheduledTask.StatusResult);
        }

        #endregion
    }
}
