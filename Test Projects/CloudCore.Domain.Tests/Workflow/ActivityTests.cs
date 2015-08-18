using CloudCore.Domain.Workflow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Domain.Tests.Workflow
{
    [TestClass]
    public class ActivityTests
    {
        [TestMethod]
        public void Activity_CanInstantiate()
        {
            var activity = new Activity(0);
            Assert.AreEqual(0, activity.Id);
        }
    }
}
