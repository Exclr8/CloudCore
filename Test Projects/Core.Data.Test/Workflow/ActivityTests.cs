using System;
using System.Linq;
using CloudCore.Domain;
using CloudCore.Domain.Workflow;
using Frameworkone.Domain;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace Core.Data.Tests.Workflow
{
    [TestClass]
    public class ActivityTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        private readonly Group group = new Group { Id = null, ManagerId = 0, Name = Guid.NewGuid().ToString() };
        private readonly Guid activityGuid = new Guid("31BA9BF0-6BDB-4850-9A92-F9B82AE1B008");
        private Activity activity;

        [TestInitialize]
        public void CreateTempAccessPoolForActivityAllocationTests()
        {
            activity = Repository.Get<Activity>(a => a.Guid == activityGuid);
        }

        [TestMethod]
        public void Activity_DeleteAllocation_AllocationRemoved()
        {
            var stopActivity = Repository.Get<Activity>(0);
            var allocationCountBefore = stopActivity.GetGroupAllocations(Repository).Count();
            stopActivity.DeleteAllocation(Repository, 0);
            var allocationCountAfter = stopActivity.GetGroupAllocations(Repository).Count();
            Assert.IsTrue(allocationCountAfter == allocationCountBefore - 1);
        }

        [TestMethod]
#if !DEBUG // TODO: We don't have workflow processes and scheduled tasks yet for the released version of CloudCore. (Database script)
        [Ignore]
#endif
        public void Activity_CreateAllocation_AllocationAdded()
        {
            var allocationCountBefore = activity.GetGroupAllocations(Repository).Count();

            var groupId = Repository.Insert(group);
            activity.CreateAllocation(Repository, (int)groupId);

            var allocationCountAfter = activity.GetGroupAllocations(Repository).Count();
            Assert.IsTrue(allocationCountAfter == allocationCountBefore + 1);
        }

        [TestMethod]
#if !DEBUG 
        [Ignore]
#endif
        public void Activity_StartAndReturnWorkItem_ReturnWorkItemWithCorrectActivity()
        {
            var workflowItem = GenerateWorklistItemWithRandomKeyValue();

            Assert.IsNotNull(workflowItem);
            Assert.IsNotNull(workflowItem.CurrentActivity);
            Assert.IsTrue(workflowItem.Id > 0);
            Assert.IsTrue(workflowItem.CurrentActivity.Guid == activityGuid);
            Assert.IsTrue(workflowItem.CurrentActivity.Name == "Some DB Stuff");
        }

        private WorkItem GenerateWorklistItemWithRandomKeyValue()
        {
            long keyValue = new Random().Next(minValue: 123456, maxValue: int.MaxValue);
            return activity.StartAndReturnWorkItem(Repository, keyValue, 0);
        }

        [TestMethod]
#if !DEBUG
        [Ignore]
#endif
        public void Activity_RestartFailedWorkItems_WorkItemStatusIsPendingAgain()
        {
            var workflowItem = GenerateWorklistItemWithRandomKeyValue();
            
            workflowItem.Fail("testing", WorkItemStatus.Failed, Repository);
            Assert.AreEqual(WorkItemStatus.Failed.Id, workflowItem.Status.Id);

            workflowItem.CurrentActivity.RestartFailedWorkItems(Repository);

            workflowItem = Repository.Get<WorkItem>(workflowItem.Id.Value);
            Assert.AreEqual(WorkItemStatus.Pending.Id, workflowItem.Status.Id);
        }
    }
}
