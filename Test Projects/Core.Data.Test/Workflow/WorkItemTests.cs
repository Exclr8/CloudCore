using System;
using System.Linq;
using CloudCore.Core.Data.Workflow;
using CloudCore.Domain.Specifications.Workflow;
using CloudCore.Domain.Workflow;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Data.Tests.Workflow
{
    [TestClass]
    public class WorkItemTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        private WorkItem workItem;
        private const string DefaultSearchFilterOption = "%{0}%";

        [TestInitialize]
        public void InitTest()
        {
            var searchSpec = new WorklistSearchSpec { StatusType= WorkItemStatus.Pending };
            workItem = new WorklistSearchImpl(DataProvider).Execute(searchSpec).First();
        }

        [TestMethod]
        public void WorkItem_Search_InvalidCriteria_NoItemsFound()
        {
            var searchSpec = new WorklistSearchSpec
            {
                SubProcessName = "ujwbefibwginweg8y23878345uguef928wkjs9u",
                SubProcessNameFilter = DefaultSearchFilterOption
            };
            var searchImpl = new WorklistSearchImpl(DataProvider);

            var workListItems = searchImpl.Execute(searchSpec);

            Assert.AreEqual(0, workListItems.Count());
        }

        [TestMethod]
        public void WorkItem_Search_ValidExistingData_ItemsFound()
        {
            var searchSpec = new WorklistSearchSpec
            {
                KeyValue = 399,
                ProcessName = "test",
                ProcessNameFilter = DefaultSearchFilterOption,
                SubProcessName = "Test",
                SubProcessNameFilter = DefaultSearchFilterOption,
                ActivityName = "db",
                ActivityNameFilter = DefaultSearchFilterOption,
                UserName = "sys",
                UserNameFilter = DefaultSearchFilterOption,
                StatusType = WorkItemStatus.Pending,
                DocWait = false
            };

            var searchImpl = new WorklistSearchImpl(DataProvider);

            var workListItems = searchImpl.Execute(searchSpec);

            Assert.AreNotEqual(0, workListItems.Count());
        }

        [TestMethod]
        public void WorkItem_FailedItem_Restart_StatusPendingAgain()
        {
            var failSpec = new WorkItemFailSpec(workItem, "testing", WorkItemStatus.Failed);
            var failImpl = new WorkItemFailImpl(DataProvider);
            
            failImpl.Execute(failSpec);

            var loadedItem = new WorkItemFindAll(DataProvider).Execute().SingleOrDefault(x => x.Id == workItem.Id);

            Assert.IsNotNull(loadedItem);
            Assert.AreEqual(WorkItemStatus.Failed.Id, loadedItem.Status.Id);

            workItem.Restart(Repository);

            loadedItem = new WorkItemFindAll(DataProvider).Execute().SingleOrDefault(x => x.Id == workItem.Id);

            Assert.IsNotNull(loadedItem);
            Assert.AreEqual(WorkItemStatus.Pending.Id, loadedItem.Status.Id);
        }

        [TestMethod]
        public void WorkItem_Cancel_WorkItemDeleted()
        {
            var cancelSpec = new WorkItemCancelSpec(workItem, 0);
            var cancelImpl = new WorkItemCancelImpl(DataProvider);

            cancelImpl.Execute(cancelSpec);

            var loadedItem = new WorkItemFindAll(DataProvider).Execute().SingleOrDefault(x => x.Id == workItem.Id);

            Assert.IsNull(loadedItem);
        }

        [TestMethod]
        public void WorkItem_Delay_ActivationScheduleInFutureAsSpecified()
        {
            var delaySpec = new UpdateWorkItemDelaySpec(workItem);
            var delayImpl = new UpdateWorkItemDelayImpl(DataProvider);

            delayImpl.Execute(delaySpec);

            var reactivateAt = DateTime.Now.AddSeconds(6);
            var loadedItem = new WorkItemFindAll(DataProvider).Execute().SingleOrDefault(x => x.Id == workItem.Id);
           
            Assert.AreNotEqual(reactivateAt, loadedItem.ActivationSchedule);
        }

        [TestMethod]
        public void WorkItem_Release_NoUserAssignedAfterward()
        {
            var releaseSpec = new UpdateWorkItemReleaseSpec(workItem);
            var releaseImpl = new UpdateWorkItemReleaseImpl(DataProvider);

            releaseImpl.Execute(releaseSpec);

            var loadedItemUpdateUser = new WorkItemFindAll(DataProvider).Execute().SingleOrDefault(x => x.Id == workItem.Id);
            
            Assert.AreNotEqual(-99, loadedItemUpdateUser.UserId);
            Assert.AreEqual(0, loadedItemUpdateUser.UserId);
        }

        [TestMethod]
        public void WorkItem_FlowNavigate_ActivityMovedOn()
        {
            var searchSpec = new WorklistSearchSpec
            {
                StatusType = WorkItemStatus.Pending,
                ActivityName = "db stuff",
                ActivityNameFilter = DefaultSearchFilterOption
            };

            
            var searchImpl = new WorklistSearchImpl(DataProvider);

            var nonFlowDecisionActivityWorkItem = searchImpl.Execute(searchSpec).FirstOrDefault();

            //var nonFlowDecisionActivityWorkItem = new WorkItemFindAll(DataProvider).Execute().SingleOrDefault(x => x.Id == workItem.Id);

            Assert.IsNotNull(nonFlowDecisionActivityWorkItem);

            nonFlowDecisionActivityWorkItem.FlowNavigate(Repository, 0, null);

            var workItemInDb = (from w in DataProvider.Cloudcore_VwWorklistEx
                                where w.InstanceId == nonFlowDecisionActivityWorkItem.Id.Value
                                select w).Single();

            Assert.AreEqual("cloudcoreuser1", workItemInDb.ActivityName.ToLower()); // a user/page activity
        }

        [TestMethod]
        public void WorkItem_UserActivity_Open_OpenedBy_ChangedToSpecifiedUser()
        {
            workItem.CurrentActivity.Type.Name = "CloudCore User Activity";
            var flowSpec = new UpdateWorkItemFlowSpec(workItem, null);
            var openSpec = new WorkItemOpenSpec(workItem, -99);
            var flowImpl = new UpdateWorkItemFlowImpl(DataProvider);
            var openImpl = new WorkItemOpenImpl(DataProvider);
            flowImpl.Execute(flowSpec);
            openImpl.Execute(openSpec);
        }

        [TestMethod]
        public void WorkItem_SetPriority_PriorityUpdated()
        {
            var priorityBefore = workItem.Priority;
            workItem.SetPriority(priorityBefore + 1, Repository);
            var priorityAfter = DataProvider.Cloudcore_Worklist.Single(w => w.InstanceId == workItem.Id.Value).Priority;
            Assert.AreEqual(priorityBefore + 1, priorityAfter);
        }

    }
}
