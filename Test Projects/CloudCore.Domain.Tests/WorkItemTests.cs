using System;
using CloudCore.Domain.Specifications.Workflow;
using CloudCore.Domain.Workflow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace CloudCore.Domain.Tests
{
    [TestClass]
    public class WorkItemTests : TestBase
    {
        private WorkItem workItem;

        [TestInitialize]
        public void Startup()
        {
            workItem = new WorkItem();
        }

        [TestMethod]
        public void CanFailWorkItem()
        {
            Repository.Expect(x => x.Update<WorkItem>(new WorkItemFailSpec(workItem, "testing", WorkItemStatus.Failed))).IgnoreArguments().Repeat.Once();

            Repository.Replay();

            workItem.Fail("testing", WorkItemStatus.Failed, Repository);

            Repository.VerifyAllExpectations();
        }

        [TestMethod]
        public void CanRestartWorkItem()
        {
            Repository.Expect(x => x.Update<WorkItem>(new UpdateWorkItemRestartSpec(workItem))).IgnoreArguments().Repeat.Once();

            Repository.Replay();

            workItem.Restart(Repository);
           
            Repository.VerifyAllExpectations();
        }

        [TestMethod]
        public void CanCancelWorkItemDeleted()
        {
            Repository.Expect(x => x.Delete<WorkItem>(new WorkItemCancelSpec(workItem, 0))).IgnoreArguments().Repeat.Once();

            Repository.Replay();

            workItem.Cancel(0, Repository);

            Repository.VerifyAllExpectations();
        }

        [TestMethod]
        public void CanDelayActivationScheduleInFutureAsSpecified()
        {
            Repository.Expect(x => x.Update<WorkItem>(new UpdateWorkItemDelaySpec(workItem))).IgnoreArguments().Repeat.Once();

            Repository.Replay();

            workItem.Delay(DateTime.Now.AddSeconds(6), Repository);

            Repository.VerifyAllExpectations();

        }

        [TestMethod]
        public void CanReleaseNoUserAssignedAfterward()
        {
            Repository.Expect(x => x.Update<WorkItem>(new UpdateWorkItemUserSpec(workItem))).IgnoreArguments().Repeat.Twice();
            Repository.Replay();

            workItem.UpdateUser(-99, Repository);
            workItem.Release(Repository);

            Repository.VerifyAllExpectations();            
        }

        [TestMethod]
        public void CanFlowNavigateActivityMovedOn()
        {
            Repository.Expect(x => x.Update<WorkItem>(new UpdateWorkItemFlowSpec(workItem, "cloudcoreuser1"))).IgnoreArguments().Repeat.Once();

            Repository.Replay();

            workItem.FlowNavigate(Repository, 0, null);

            Repository.VerifyAllExpectations();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Cannot start/open the activity because it is not a User activity.")]
        public void UserActivityOpenItemAlreadyOpenedByDifferentUserError()
        {
            workItem.CurrentActivity = new Activity(Guid.NewGuid())
            {
                Type = new ActivityType()
            };
            Repository.Expect(x => x.Update<WorkItem>(new WorkItemOpenSpec(workItem, -99))).IgnoreArguments().Repeat.Once();

            Repository.Replay();

            workItem.Open(Repository, -99);
            
            Repository.VerifyAllExpectations();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Cannot start/open the activity because it is not a User activity.")]
        public void CanOpenByInstanceNonUserActiviyException()
        {
            workItem.CurrentActivity = new Activity(Guid.NewGuid())
            {
                Type = new ActivityType()
            };
            Repository.Expect(x => x.Update<WorkItem>(new WorkItemOpenSpec(workItem, -99))).IgnoreArguments().Repeat.Once();    

            Repository.Replay();

            Repository.VerifyAllExpectations();   
        }

        [TestMethod]
        public void CanSetPriorityPriorityUpdated()
        {
            Repository.Expect(x => x.Update<WorkItem>(new UpdateWorkItemPrioritySpec(workItem))).IgnoreArguments().Repeat.Once();

            Repository.Replay();

            var priorityBefore = workItem.Priority;
            workItem.SetPriority(priorityBefore+1, Repository);

            Repository.VerifyAllExpectations();
        }
    }
}
