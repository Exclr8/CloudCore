using System;
using System.Linq;
using CloudCore.Domain;
using CloudCore.Domain.Specifications.Group;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Data.Tests
{
    [TestClass]
    public class GroupTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        [TestMethod]
        public void CanSaveGroup()
        {
            var group = new Group
            {
                Name = "F1 Bananna",
                ManagerId = 0 
            };
            var result = Repository.Insert(group);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void CanUpdateGroup()
        {
            var group = Repository.FindAll<Group>(g => g.Id == 0).Single();
            var newRandomName = Guid.NewGuid().ToString();
            
            group.Name = newRandomName;
            Repository.Update(group);
            group = Repository.FindAll<Group>(g => g.Name == newRandomName).SingleOrDefault();
            
            Assert.IsNotNull(group);
        }

        [TestMethod]
        public void Repository_Group_AddUser_RemoveUser()
        {
            var user = Repository.Get<User>(0);
            var group = Repository.Get<Group>(0);
            var groupUsers = group.GetUsers(Repository);
            var count = groupUsers.Count();

            group.RemoveUser(Repository, (int)user.Id);
            Assert.AreEqual(count - 1, groupUsers.Count());

            group.AddUser(Repository, (int)user.Id);
            Assert.AreEqual(count, groupUsers.Count());
        }

        [TestMethod]
        public void Group_FindWithSpecificDetails_ReturnsValidGroup()
        {
            var group = Repository.FindAll<Group>(g => g.Id == 0).SingleOrDefault();
            Assert.IsNotNull(group);
        }

        [TestMethod]
        public void Group_GetManager_ReturnsUser()
        {
            var group = Repository.Get<Group>(0);
            var manager = group.GetManager(Repository);
            Assert.IsNotNull(manager);
            Assert.IsInstanceOfType(manager, typeof(User));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Group_OperationWithNullGroupId_ExceptionThrown()
        {
            var group = new Group { Id = null, Name = "The Peanut Gallery", ManagerId = 0 };
            @group.AddUser(Repository, 0);
        }

        [TestMethod]
        public void Group_Search_WithSpec_ItemsFound()
        {
            var groups = Repository.FindAll<Group>(new GroupSearchSpec {
                                                        GroupName = "", 
                                                        GroupNameFilter = "%{0}%", 
                                                        ManagerName = "", 
                                                        ManagerNameFilter = "%{0}%"
                                                   });

            Assert.IsTrue(groups.Any());
        }
    }
}
