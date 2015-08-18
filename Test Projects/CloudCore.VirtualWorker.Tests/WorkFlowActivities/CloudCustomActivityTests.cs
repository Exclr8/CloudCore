using System;
using CloudCore.VirtualWorker.WorkflowActivities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.VirtualWorker.Tests.WorkFlowActivities
{
    [TestClass]
    public class CloudCustomActivityTests
    {
        [TestMethod]
        public void CanExecuteActivity()
        {
            var cloudCustomActivityTestClass = new CloudCustomActivityTestClass();

            cloudCustomActivityTestClass.OnVirtualWork();

            Assert.IsTrue(cloudCustomActivityTestClass.HasExecuted);
        }
    }

    public class CloudCustomActivityTestClass : CloudCustomActivity
    {
        public bool HasExecuted = false;

        public override void Execute()
        {
            HasExecuted = true;
        }
    }
}
