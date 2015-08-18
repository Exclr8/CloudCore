using System;
using System.Linq;
using CloudCore.Domain;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Data.Tests
{
    [TestClass]
    public class SystemApplicationTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        private readonly SystemApplication systemApplicationUnderTest;

        public SystemApplicationTests()
        {
            systemApplicationUnderTest = new SystemApplication
            {
                Id = null,
                Name = string.Format("My Test Application {0}", Guid.NewGuid()),
                CompanyName = "Aspin",
                ContactPerson = "Mannamarrak",
                ContactNumber = "1234567890"
            };
        }

        [TestInitialize]
        public void CreateApplication()
        {
            Repository.Insert(systemApplicationUnderTest);
        }

        [TestMethod]
        public void SystemApplication_AddAcitivtyAllocation_NewAllocationExists()
        {
            var activityCountBeforeAdd = systemApplicationUnderTest.GetActivities(Repository).Count();
            AddValidActivityAllocation();
            var activityCountAfterAdd = systemApplicationUnderTest.GetActivities(Repository).Count();
            Assert.IsTrue(activityCountAfterAdd > activityCountBeforeAdd);
        }

        private void AddValidActivityAllocation()
        {
            systemApplicationUnderTest.AddActivityAllocation(Repository, 0);
        }

        [TestMethod]
        public void SystemApplication_RemoveActivityAllocation_AllocationNotFoundAfterward()
        {
            AddValidActivityAllocation();
            var activityCountBeforeRemoval = systemApplicationUnderTest.GetActivities(Repository).Count();            
            systemApplicationUnderTest.RemoveActivityAllocation(Repository, 0);
            var activityCountAfterRemoval = systemApplicationUnderTest.GetActivities(Repository).Count();
            Assert.IsTrue(activityCountAfterRemoval < activityCountBeforeRemoval);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SystemApplication_AddActivityAllocationWithoutSystemApplicationId_Exception()
        {
            var invalidSystemApplication = new SystemApplication { Id = null };
            invalidSystemApplication.GetActivities(Repository);
        }

        [TestCleanup]
        public void RemoveApplication()
        {
            Repository.Delete(systemApplicationUnderTest);
        }
    }
}
