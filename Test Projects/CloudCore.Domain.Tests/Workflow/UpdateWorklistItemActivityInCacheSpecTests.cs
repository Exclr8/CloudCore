using CloudCore.Domain.Specifications.Workflow;
using CloudCore.Domain.Workflow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Domain.Tests.Workflow
{
    [TestClass]
    public class UpdateWorklistItemActivityInCacheSpecTests
    {
        [TestMethod]
        public void UpdateWorklistItemActivityInCacheSpec_CanInstantiate()
        {
            const long fakeInstanceId = 776381;
            var fakeWorkItem = new WorkItem { Id = 776381 };
            var spec = new UpdateWorklistItemActivityInCacheSpec(fakeWorkItem);
            
            Assert.IsNotNull(spec.Entity);
            Assert.AreEqual(fakeInstanceId, spec.Entity.Id);
        }
    }
}
