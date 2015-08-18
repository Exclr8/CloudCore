using CloudCore.Domain.Specifications.Workflow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Domain.Tests.Workflow
{
    [TestClass]
    public class GetActivityByInstanceSpecTests
    {
        [TestMethod]
        public void GetActivityByInstanceSpec_CanInstantiate()
        {
            const long instanceid = 1642;

            var spec = new GetActivityByInstanceSpec(instanceid);

            Assert.AreEqual(instanceid, spec.InstanceId);
        }
    }
}
