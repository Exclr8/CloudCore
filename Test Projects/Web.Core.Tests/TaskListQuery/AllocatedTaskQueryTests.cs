using System;
using CloudCore.Domain.Specifications.Workflow;
using CloudCore.Web.Core.Workflow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Core.Tests.TaskListQuery
{
    [TestClass]
    public class AllocatedTaskQueryTests
    {
        public const string Title = "Allocated Tasks";
        public const string Description = "Returns a list of all tasks allocated to the current user.";
        private AllocatedTaskQuery taskListQueryTestClass = null;
        private const int UserId = 1;
        private const int ApplicationId = 1;
        private readonly int? referenceTypeId = 1;
        private const string ReferenceValue = "ReferenceValue";
        private readonly bool? delayed = false;
        private readonly int? statusTypeId = 1;
        private readonly int? openedBy = 1;

        [TestInitialize]
        public void Init()
        {
            taskListQueryTestClass = new AllocatedTaskQuery();
        }

        [TestMethod]
        public void AllocatedTaskQuery_CanSetTitle()
        {
            Assert.AreEqual(Title, taskListQueryTestClass.Title);
        }

        [TestMethod]
        public void AllocatedTaskQuery_CanSetDescription()
        {
            Assert.AreEqual(Description, taskListQueryTestClass.Description);
        }

        [TestMethod]
        public void AllocatedTaskQuery_CanSetTaskListSpecification()
        {
            //set delayed to true to test that the spec is setting to false
            var taskListSpec = new TaskListSpec(UserId, ApplicationId, referenceTypeId, ReferenceValue, delayed,
                statusTypeId, openedBy);

            taskListQueryTestClass.SetFilter(taskListSpec);

            Assert.AreEqual(UserId, taskListSpec.UserId);
            Assert.AreEqual(ApplicationId, taskListSpec.ApplicationId);
            Assert.AreEqual(false, taskListSpec.Delayed);
            Assert.AreEqual(referenceTypeId, taskListSpec.ReferenceTypeId);
            Assert.AreEqual(ReferenceValue, taskListSpec.ReferenceValue);
            Assert.AreEqual(3, taskListSpec.StatusTypeId);
            Assert.AreEqual(openedBy, taskListSpec.OpenedBy);
        }
    }
}
