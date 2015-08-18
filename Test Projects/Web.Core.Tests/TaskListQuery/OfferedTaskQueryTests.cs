using System;
using CloudCore.Domain.Specifications.Workflow;
using CloudCore.Web.Core.Workflow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Core.Tests.TaskListQuery
{
    [TestClass]
    public class OfferedTaskQueryTests
    {
        public const string Title = "Offered Tasks";
        public const string Description = "Returns a list of all offered tasks the current user can complete.";
        private OfferedTaskQuery taskListQueryTestClass = null;
        private const int UserId = 1;
        private const int ApplicationId = 1;
        private int? ReferenceTypeId = 1;
        private const string ReferenceValue = "ReferenceValue";
        private bool? Delayed = true;
        private int? StatusTypeId = 1;
        private int? OpenedBy = 1;

        [TestInitialize]
        public void Init()
        {
            taskListQueryTestClass = new OfferedTaskQuery();
        }

        [TestMethod]
        public void OfferedTaskQuery_CanSetTitle()
        {
            Assert.AreEqual(Title, taskListQueryTestClass.Title);
        }

        [TestMethod]
        public void OfferedTaskQuery_CanSetDescription()
        {
            Assert.AreEqual(Description, taskListQueryTestClass.Description);
        }

        [TestMethod]
        public void OfferedTaskQuery_CanSetTaskListSpecification()
        {
            //set delayed to true to test that it is being set to false
            var taskListSpec = new TaskListSpec(UserId, ApplicationId, ReferenceTypeId, ReferenceValue, Delayed,
                StatusTypeId, OpenedBy);

            taskListQueryTestClass.SetFilter(taskListSpec);

            Assert.AreEqual(UserId, taskListSpec.UserId);
            Assert.AreEqual(ApplicationId, taskListSpec.ApplicationId);
            Assert.AreEqual(false, taskListSpec.Delayed);
            Assert.AreEqual(ReferenceTypeId, taskListSpec.ReferenceTypeId);
            Assert.AreEqual(ReferenceValue, taskListSpec.ReferenceValue);
            Assert.AreEqual(0, taskListSpec.StatusTypeId);
            Assert.AreEqual(OpenedBy, taskListSpec.OpenedBy);
        }
    }
}
