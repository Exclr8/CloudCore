using System;
using CloudCore.Domain.Workflow;
using CloudCore.VirtualWorker.Tests.Engine.Workflow.Mocks;
using CloudCore.VirtualWorker.Threading;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.VirtualWorker.Tests.Engine.Workflow
{
    [TestClass]
    public class WorkflowTests
    {
        #region Setup

        [TestInitialize]
        public void InitializeWorkerTests()
        {
            DeployProcess();
            DeployProcessTestData();
        }

        private const string ResourceNotFoundMessageTemplate = @"Could not execute test setup/tear-down SQL script file ""{0}"". Cannot not find the script in the embedded resources.";
        public static void DeployProcess()
        {
            const string scriptName = "ProcessDeploymentScriptText";
            var scriptContent = Resources.ResourceManager.GetObject(scriptName);

            if (scriptContent == null)
                throw new NullReferenceException(string.Format(ResourceNotFoundMessageTemplate, scriptName));

            var processScript = scriptContent.ToString();
            DatabaseSqlExecution.ExecuteSqlScript(processScript);
        }

        public static void DeployProcessTestData()
        {
            const string scriptName = "ProcessTestDataScriptText";

            var scriptContent = Resources.ResourceManager.GetObject(scriptName);

            if (scriptContent == null)
                throw new NullReferenceException(string.Format(ResourceNotFoundMessageTemplate, scriptName));

            var processDataScript = scriptContent.ToString();
            DatabaseSqlExecution.ExecuteSqlScript(processDataScript);
        }

        #endregion

        #region Tests

        [TestMethod]
        [Timeout(20000)]
        public void Worker_CanRunWorkerForWorkflowTask()
        {
            var worker = new WorkflowMockedWorker();
            worker.OnStart();
            worker.Run();
            Assert.IsTrue(worker.LoopCount >= 2);
        }

        [TestMethod]
        [Timeout(40000)]
        public void Worker_CanRunWorkerForFailedWorkflow()
        {
            var worker = new WorkflowFailedMockedWorker();
            worker.OnStart();
            worker.Run();
            Assert.IsTrue(worker.LoopCount >= 2);
        }

        [TestMethod]
        public void FailedWorkflowEngine_WorkflowMonitorLoop_WorkItemRetryWhenMaxRetriesNotReached()
        {
            var exitStrategy = new ExitStrategy();
            var context = WorkflowContextObjectMother.GenerateWorkflowContextWithFailingActivities(exitStrategy);
            var worklistItem = WorkListObjectMother.GenerateFakeWorklistItem(context.ActivityTypes, maxRetries: 3);
            var mockFailedWorkflow = new MockFailedWorkflowEngine(context, worklistItem);

            mockFailedWorkflow.WorkflowMonitorLoop();

            Assert.AreEqual(WorkItemStatus.Retry.Id, mockFailedWorkflow.StatusResult.Id);
        }

        [TestMethod]
        public void FailedWorkflowEngine_WorkflowMonitorLoop_WorkItemFailsWhenMaxRetriesReached()
        {
            var exitStrategy = new ExitStrategy();
            var context = WorkflowContextObjectMother.GenerateWorkflowContextWithFailingActivities(exitStrategy);
            var worklistItem = WorkListObjectMother.GenerateFakeWorklistItem(context.ActivityTypes, maxRetries: 3, currentRetries: 3);
            var mockFailedWorkflow = new MockFailedWorkflowEngine(context, worklistItem);

            mockFailedWorkflow.WorkflowMonitorLoop();

            Assert.AreEqual(WorkItemStatus.Failed.Id, mockFailedWorkflow.StatusResult.Id);
        }
        
        [TestMethod]
        public void NormalWorkflowEngine_WorkflowMonitorLoop_WhenFailingWithMaxRetriesGreaterThanZero_WorkflowItemRetry()
        {
            var exitStrategy = new ExitStrategy();
            var context = WorkflowContextObjectMother.GenerateWorkflowContextWithFailingActivities(exitStrategy);
            var worklistItem = WorkListObjectMother.GenerateFakeWorklistItem(context.ActivityTypes, maxRetries: 3, currentRetries: 0);
            var mockFailedWorkflow = new MockNormalWorkflowEngine(context, worklistItem);

            mockFailedWorkflow.WorkflowMonitorLoop();

            Assert.AreEqual(WorkItemStatus.Retry.Id, mockFailedWorkflow.StatusResult.Id);
        }

        [TestMethod]
        public void NormalWorkflowEngine_WorkflowMonitorLoop_WhenFailingWithMaxRetriesZero_WorkflowItemFailed()
        {
            var exitStrategy = new ExitStrategy();
            var context = WorkflowContextObjectMother.GenerateWorkflowContextWithFailingActivities(exitStrategy);
            var worklistItem = WorkListObjectMother.GenerateFakeWorklistItem(context.ActivityTypes, maxRetries: 0, currentRetries: 0);
            var mockFailedWorkflow = new MockNormalWorkflowEngine(context, worklistItem);

            mockFailedWorkflow.WorkflowMonitorLoop();

            Assert.AreEqual(WorkItemStatus.Failed.Id, mockFailedWorkflow.StatusResult.Id);
        }

        #endregion

        #region Tear Down
        
        #endregion
    }
}
