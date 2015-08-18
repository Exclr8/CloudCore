using System;
using CloudCore.Domain.Specifications.Workflow;
using CloudCore.Web.Core.Workflow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Core.Tests.TaskListQuery
{
    [TestClass]
    public class SuspendedTaskQueryTests
    {
        public const string Title = "Suspended Tasks";
        public const string Description = "Returns a list of all tasks currently suspended and allocated to the current user.";
        private SuspendedTaskQuery taskListQueryTestClass = null;
        private const int UserId = 1;
        private const int ApplicationId = 1;
        private int? ReferenceTypeId = 1;
        private const string ReferenceValue = "ReferenceValue";
        private bool? Delayed = false;
        private int? StatusTypeId = 1;
        private int? OpenedBy = 1;

        [TestInitialize]
        public void Init()
        {
            taskListQueryTestClass = new SuspendedTaskQuery();
        }

        [TestMethod]
        public void SuspendedTaskQuery_CanSetTitle()
        {
            Assert.AreEqual(Title, taskListQueryTestClass.Title);
        }

        [TestMethod]
        public void SuspendedTaskQuery_CanSetDescription()
        {
            Assert.AreEqual(Description, taskListQueryTestClass.Description);
        }

        [TestMethod]
        public void SuspendedTaskQuery_CanSetTaskListSpecification()
        {
            //set delayed to false to test that it is being set to true
            var taskListSpec = new TaskListSpec(UserId, ApplicationId, ReferenceTypeId, ReferenceValue, Delayed,
                StatusTypeId, OpenedBy);

            taskListQueryTestClass.SetFilter(taskListSpec);

            Assert.AreEqual(UserId, taskListSpec.UserId);
            Assert.AreEqual(ApplicationId, taskListSpec.ApplicationId);
            Assert.AreEqual(true, taskListSpec.Delayed);
            Assert.AreEqual(ReferenceTypeId, taskListSpec.ReferenceTypeId);
            Assert.AreEqual(ReferenceValue, taskListSpec.ReferenceValue);
            Assert.AreEqual(StatusTypeId, taskListSpec.StatusTypeId);
            Assert.AreEqual(OpenedBy, taskListSpec.OpenedBy);
        }
    }
}
