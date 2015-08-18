using CloudCore.Domain.Specifications.Workflow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Domain.Tests.Workflow
{
    [TestClass]
    public class FailedActivitySpecTests
    {
        [TestMethod]
        public void FailedActivitySpec_CanInstantiate()
        {
            const string processName = "test process";
            const string processNameFilter = "%";
            const string subProcessName = "test sub";
            const string subProcessNameFilter = "";
            const string activityName = "test act";
            const string activityNameFilter = "%";

            var spec = new FailedActivitySpec(processName, processNameFilter, subProcessName, subProcessNameFilter, activityName, activityNameFilter);

            Assert.AreEqual(processName, spec.ProcessName);
            Assert.AreEqual(processNameFilter, spec.ProcessNameFilter);
            Assert.AreEqual(subProcessName, spec.SubProcessName);
            Assert.AreEqual(subProcessNameFilter, spec.SubProcessNameFilter);
            Assert.AreEqual(activityName, spec.ActivityName);
            Assert.AreEqual(activityNameFilter, spec.ActivityNameFilter);
        }
    }
}
