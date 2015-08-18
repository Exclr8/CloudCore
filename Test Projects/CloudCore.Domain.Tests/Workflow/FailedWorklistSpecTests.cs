using CloudCore.Domain.Specifications.Workflow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Domain.Tests.Workflow
{
    [TestClass]
    public class FailedWorklistSpecTests
    {
        [TestMethod]
        public void FailedWorklistSpec_CanInstantiate()
        {
            const string processName = "test process";
            const string processNameFilter = "%";
            const string subProcessName = "test sub";
            const string subProcessNameFilter = "";
            const string activityName = "test act";
            const string activityNameFilter = "%";

            var spec = new FailedWorklistSpec(processName, processNameFilter, subProcessName, subProcessNameFilter, activityName, activityNameFilter);
            
            Assert.AreEqual(101, spec.FailureStatusId);
            Assert.AreEqual(processName, spec.ProcessName);
            Assert.AreEqual(processNameFilter, spec.ProcessNameFilter);
            Assert.AreEqual(subProcessName, spec.SubProcessName);
            Assert.AreEqual(subProcessNameFilter, spec.SubProcessNameFilter);
            Assert.AreEqual(activityName, spec.ActivityName);
            Assert.AreEqual(activityNameFilter, spec.ActivityNameFilter);
        }
    }
}
