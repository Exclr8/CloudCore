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
    public class CloudCostingTests
    {
        private CloudCostingActivityTestClass cloudCostingActivityTestClass;
        private WorklistItem workListItem;
        private CloudCoreDB db;

        [TestInitialize]
        public void Init()
        {
            db = new CloudCoreDB { ObjectTrackingEnabled = true };

            //CleanCostLedgerTable();

            WorkflowTests.DeployProcess();
            WorkflowTests.DeployProcessTestData();

            cloudCostingActivityTestClass = new CloudCostingActivityTestClass();
        }

        private void CleanCostLedgerTable()
        {
            var allCostLedgerItems = from wl in db.Cloudcore_CostLedger
                                     select wl;


            db.Cloudcore_CostLedger.DeleteAllOnSubmit(allCostLedgerItems);
            db.SubmitChanges();
        }

        [TestMethod]
        public void CanCreateCostLedgerItem()
        {

            workListItem = cloudCostingActivityTestClass.GetWorkListItem();
            cloudCostingActivityTestClass.OnVirtualWork();


            var result = (from wl in db.Cloudcore_CostLedger
                          where wl.InstanceId == workListItem.InstanceId
                          select new
                          {
                              wl.Cost,
                          }).Single();

            Assert.AreEqual(100, result.Cost);
        }
    }

    public class CloudCostingActivityTestClass : CloudCostingActivity
    {
        public override decimal Execute()
        {
            ThreadSafeDataAccess = new NormalWorkflowThreadSafeDataAccess();

            return 100;
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
