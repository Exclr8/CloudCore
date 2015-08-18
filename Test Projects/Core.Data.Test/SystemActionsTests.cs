using System;
using System.Linq;
using CloudCore.Domain;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Data.Tests
{
    [TestClass]
    public class SystemActionsTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        private SystemAction insertedSystemAction = null;
        long? insertedActionId = null;

        [TestInitialize]
        public void CanInsertSytemAction()
        {
            insertedActionId = InsertSystemAction("622A2620-769B-416B-B16A-57B93098BFD4");
            Assert.IsNotNull(insertedActionId);
            Assert.AreNotEqual(0, insertedActionId.Value);
        }

        private long? InsertSystemAction(string guidString)
        {            
            var actionToInsert = new SystemAction
            {
                Action = "TestAction",
                ActionGuid = new Guid(guidString),
                ActionType = SystemActionType.Create,
                Area = "TestArea",
                Controller = "TestController",
                Module = new SystemModule{ Id = 1 },
                Title = "TestTitle"
            };

            Repository.Insert(actionToInsert);
            insertedSystemAction = actionToInsert;
            return insertedSystemAction.Id;
        }

        [TestMethod]
        public void CanUpdateSystemAction()
        {
            var oldArea = insertedSystemAction.Area;
            var newArea = Guid.NewGuid().ToString();

            insertedSystemAction.Title = "Title5123";
            insertedSystemAction.Action = "Action5123";
            insertedSystemAction.ActionType = SystemActionType.Modify;
            insertedSystemAction.Area = newArea;
            insertedSystemAction.Controller = "Controller5123";

            Repository.Update(insertedSystemAction);

            var systemActionNew = Repository.FindAll<SystemAction>(x => x.Id == insertedActionId).SingleOrDefault();

            Assert.IsNotNull(systemActionNew);
            Assert.AreEqual("Title5123", systemActionNew.Title);
            Assert.AreEqual("Action5123", systemActionNew.Action);
            Assert.AreEqual(SystemActionType.Modify, systemActionNew.ActionType);
            Assert.AreEqual("Controller5123", systemActionNew.Controller);
            Assert.AreNotEqual(oldArea, systemActionNew.Area);
            Assert.AreEqual(newArea, systemActionNew.Area);
        }

        [TestMethod]
        public void CanDeleteSystemAction()
        {
            var systemActionOld = Repository.FindAll<SystemAction>(x => x.Id == insertedActionId).SingleOrDefault();
            Repository.Delete(systemActionOld);
            var deletedSystemAction = Repository.FindAll<SystemAction>(x => x.Id == insertedActionId).SingleOrDefault();
            Assert.IsNull(deletedSystemAction);
        }

        [TestMethod]
        public void SystemAction_AddToGroup_HasAddedAllocations()
        {
            var groupAllocationsCountBefore = insertedSystemAction.GetAllocatedGroups(Repository).Count();
            insertedSystemAction.AddGroupAllocation(Repository, 0);
            var groupAllocationsAfter = insertedSystemAction.GetAllocatedGroups(Repository).ToList();
            
            Assert.IsTrue(groupAllocationsAfter.Count > groupAllocationsCountBefore);
            Assert.IsTrue(groupAllocationsAfter.Any(a => a.Id == 0));
        }

        [TestMethod]
        public void SystemAction_RemoveGroupAllocation_AllocationNotFoundAfterward()
        {
            var systemActionId = insertedSystemAction.Id.Value;
            insertedSystemAction.AddGroupAllocation(Repository, 0);
            
            var menuRoot = Repository.Get<SystemAction>(systemActionId);
            var groupAllocationsCountBefore = menuRoot.GetAllocatedGroups(Repository).Count();
            
            menuRoot.RemoveGroupAllocation(Repository, 0);
            
            var groupAllocationsCountAfter = menuRoot.GetAllocatedGroups(Repository).Count();            
            
            Assert.IsTrue(groupAllocationsCountAfter < groupAllocationsCountBefore);
        }

        [TestCleanupAttribute]
        public void CanRemoveSystemAction()
        {
            Repository.Delete(insertedSystemAction);
        }
    }
}
