using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudCore.Core;
using CloudCore.Domain.Specifications.Workflow;
using CloudCore.Domain.Workflow;
using Frameworkone.Domain;
using Frameworkone.UnitTestUtilities;
using Frameworkone.UnitTestUtilities.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Web.Core.Tests.TaskListQuery
{
    [TestClass]
    public class TaskListQueryTests
    {
        public const string Title = "Title";
        public const string Description = "Description";
        private TaskListQueryTestClass taskListQueryTestClass = null;
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
            taskListQueryTestClass = new TaskListQueryTestClass();
        }

        [TestMethod]
        public void TaskListQueryTestClass_CanSetTitle()
        {
            Assert.AreEqual(Title, taskListQueryTestClass.Title);
        }

        [TestMethod]
        public void TaskListQueryTestClass_CanSetDescription()
        {
            Assert.AreEqual(Description, taskListQueryTestClass.Description);
        }

        [TestMethod]
        public void TaskListQueryTestClass_CanSetTaskListSpecification()
        {
            var taskListSpec = new TaskListSpec(UserId, ApplicationId, ReferenceTypeId, ReferenceValue, Delayed, StatusTypeId, OpenedBy);

            Assert.AreEqual(UserId, taskListSpec.UserId);
            Assert.AreEqual(ApplicationId, taskListSpec.ApplicationId);
            Assert.AreEqual(Delayed, taskListSpec.Delayed);
            Assert.AreEqual(ReferenceTypeId, taskListSpec.ReferenceTypeId);
            Assert.AreEqual(ReferenceValue, taskListSpec.ReferenceValue);
            Assert.AreEqual(StatusTypeId, taskListSpec.StatusTypeId);
            Assert.AreEqual(OpenedBy, taskListSpec.OpenedBy);

            taskListQueryTestClass.SetFilter(taskListSpec);

            Assert.AreEqual(2, taskListSpec.UserId);
            Assert.AreEqual(2, taskListSpec.ApplicationId);
            Assert.AreEqual(true, taskListSpec.Delayed);
            Assert.AreEqual(2, taskListSpec.ReferenceTypeId);
            Assert.AreEqual("NewReferenceValue", taskListSpec.ReferenceValue);
            Assert.AreEqual(2, taskListSpec.StatusTypeId);
            Assert.AreEqual(2, taskListSpec.OpenedBy);
        }

        [TestMethod]
        public void TaskListQueryTestClass_CanExecuteTaskListSpecification()
        {
            //TODO:issues with mocking repository FindAll Call 
            var repository = MockHelper.MockRepository<TaskItem>(TaskItemQuery());

            var result = taskListQueryTestClass.Execute(repository, UserId,ReferenceTypeId.Value, ReferenceValue, ApplicationId);

            Assert.AreEqual(3, result.Count());
        }

        private IEnumerable<TaskItem> TaskItemQuery()
        {
            return new List<TaskItem>
            {
                { MockHelper.CreateSimpleGenericMock<TaskItem>() },
                { MockHelper.CreateSimpleGenericMock<TaskItem>() },
                { MockHelper.CreateSimpleGenericMock<TaskItem>() },
            };
        }
    }

    public class TaskListQueryTestClass : CloudCore.Web.Core.Workflow.TaskListQuery
    {
        public override string Title
        {
            get { return TaskListQueryTests.Title; }
        }

        public override string Description
        {
            get { return TaskListQueryTests.Description; }
        }

        public override void SetFilter(TaskListSpec taskListSpec)
        {
            base.SetFilter(taskListSpec);

            taskListSpec.UserId = 2;
            taskListSpec.ApplicationId = 2;
            taskListSpec.Delayed = true;
            taskListSpec.OpenedBy = 2;
            taskListSpec.ReferenceTypeId = 2;
            taskListSpec.ReferenceValue = "NewReferenceValue";
            taskListSpec.StatusTypeId = 2;
        }
    }
}
