using System;
using System.Linq;
using CloudCore.Domain;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Data.Tests
{
    [TestClass]
    public class SystemValuesTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        [TestMethod] // TODO: Too many act-assert pairs... refactor tests.
        public void CanInsertSytemValue()
        {
            var systemValue = new SystemValue
            {
                CategoryId = 3,
                Name = "Test System Value",
                Data = "This is test data",
                Description = "Test Description"
            };
            
            var id = Repository.Insert(systemValue);

            Assert.IsNotNull(id);
            Assert.AreNotEqual(0, id.Value);

            var item = Repository.FindAll<SystemValue>(x => x.Id == id).SingleOrDefault();

            Assert.IsNotNull(item);
            Assert.AreEqual(item.Data, "This is test data");
        }

        [TestMethod] 
        public void CanUpdateSytemValue()
        {
            var systemValueOld = Repository.FindAll<SystemValue>().First();
            
            systemValueOld.Data = Guid.NewGuid().ToString();
            Repository.Update(systemValueOld);

            var systemValueNew = Repository.Get<SystemValue>(systemValueOld.Id ?? -1);
            Assert.IsNotNull(systemValueNew);
            Assert.AreEqual(systemValueNew.Data, systemValueOld.Data);
        }

        [TestMethod]
        public void CanDeleteSystemValue()
        {
            var systemValueOld = Repository.FindAll<SystemValue>(x => x.Name == "LicenseMode").SingleOrDefault();
            Repository.Delete(systemValueOld);
            var deletedSystemValue = Repository.FindAll<SystemValue>(x => x.Name == "LicenseMode").SingleOrDefault();
            Assert.IsNull(deletedSystemValue);
        }

        [TestMethod]
        public void CanFindAllSytemValues()
        {
            var systemValues = Repository.FindAll<SystemValue>().ToList();
            Assert.IsTrue(systemValues.Any(), "Couldn't find any system values in the database. Is it working?");
            Assert.IsFalse(string.IsNullOrEmpty(systemValues.First().Data));
        }
    }

}
