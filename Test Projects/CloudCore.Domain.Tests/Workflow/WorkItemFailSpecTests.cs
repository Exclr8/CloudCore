using System;
using CloudCore.Domain.Specifications.Workflow;
using CloudCore.Domain.Workflow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Domain.Tests.Workflow
{
    [TestClass]
    public class WorkItemFailSpecTests
    {
        private const string ValidFailureReason = "test reason";
        private const string InvalidFailureReason = "";
        private const long FakeInstanceId = 321;
        private readonly WorkItem fakeWorkItem = new WorkItem { Id = FakeInstanceId };

        [TestMethod]
        public void WorkItemFailSpec_InstantiateWithValidFailStatusAndReason_ValidObject()
        {
            var spec = new WorkItemFailSpec(fakeWorkItem, ValidFailureReason, WorkItemStatus.Failed);

            Assert.AreEqual(FakeInstanceId, spec.Entity.Id);
            Assert.AreEqual(WorkItemStatus.Failed.Id, spec.FailureStatus.Id);
            Assert.AreEqual(ValidFailureReason, spec.Reason);
        }

        [TestMethod]
        public void WorkItemFailSpec_InstantiateWithRetryStatusAndReason_ValidObject()
        {
            var spec = new WorkItemFailSpec(fakeWorkItem, ValidFailureReason, WorkItemStatus.Retry);

            Assert.AreEqual(FakeInstanceId, spec.Entity.Id);
            Assert.AreEqual(WorkItemStatus.Retry.Id, spec.FailureStatus.Id);
            Assert.AreEqual(ValidFailureReason, spec.Reason);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WorkItemFailSpec_InstantiateWith_ValidFailureStatus_AndInvalidReason_Error()
        {
            var spec = new WorkItemFailSpec(fakeWorkItem, InvalidFailureReason, WorkItemStatus.Retry);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WorkItemFailSpec_InstantiateWith_InvalidFailureStatus_ValidReason_Error()
        {
            var spec = new WorkItemFailSpec(fakeWorkItem, ValidFailureReason, WorkItemStatus.Running);
        }
    }
}
