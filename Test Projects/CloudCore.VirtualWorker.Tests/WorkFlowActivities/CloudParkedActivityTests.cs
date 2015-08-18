using System;
using System.Linq;
using CloudCore.Data;
using CloudCore.VirtualWorker.Engine.Workflow;
using CloudCore.VirtualWorker.Tests.Engine.Workflow;
using CloudCore.VirtualWorker.Threading.Workflow;
using CloudCore.VirtualWorker.WorkflowActivities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.VirtualWorker.Tests.WorkFlowActivities
{
    [TestClass]
    public class CloudParkedActivityTests
    {
        private CloudParkedActivityTestClass cloudParkedActivityTestClass;

        [TestInitialize]
        public void Init()
        {
            cloudParkedActivityTestClass = new CloudParkedActivityTestClass();

            WorkflowTests.DeployProcess();
            WorkflowTests.DeployProcessTestData();
        }

        [TestMethod]
        public void CanDelayWorkItem()
        {
            const int minutesToDelay = 5;
            const double marginInMilliseconds = 100; // for approximation (we don't care if it's out by mere milliseconds)
            const int millisecondsToDelay = minutesToDelay * 60 * 1000;

            WorklistItem workListItem = cloudParkedActivityTestClass.GetWorkListItem();

            var timeBeforeDelay = DateTime.Now;

            cloudParkedActivityTestClass.OnVirtualWork();

            var db = new CloudCoreDB();

            var newActivateTimeFromDb = db.Cloudcore_VwWorklistEx.Single(w => w.InstanceId == workListItem.InstanceId).Activate;
            var millisecondDifference = (newActivateTimeFromDb - timeBeforeDelay).TotalMilliseconds;
            double millisecondDifferenceWithMargin = millisecondDifference + marginInMilliseconds;

            Assert.IsTrue(millisecondDifferenceWithMargin >= millisecondsToDelay); // approximately 5 minutes
        }
    }

    public class CloudParkedActivityTestClass : CloudParkedActivity
    {
        public override int Execute()
        {
            ThreadSafeDataAccess = new NormalWorkflowThreadSafeDataAccess();
            return 5;
        }
        public WorklistItem GetWorkListItem()
        {
            var result = (from wl in Database.Cloudcore_VwWorklistEx
                          select new
                          {
                              wl.ActivityId,
                              wl.ActivityGuid,
                              wl.ActivityName,
                              wl.InstanceId
                          }).First();

            var workListItem = new WorklistItem(result.ActivityId, result.ActivityGuid,
                result.ActivityName, 1, 1);
            workListItem.InstanceId = result.InstanceId;
            SetWorkItemData(workListItem);

            return workListItem;
        }
    }
}
