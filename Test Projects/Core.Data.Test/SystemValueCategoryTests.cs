using System.Linq;
using CloudCore.Domain;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Data.Tests
{
    [TestClass]
    public class SystemValueCategoryTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {

        [TestMethod]
        public void CanCreateSystemValueCategory()
        {
            var newCategory = new SystemValueCategory
            {
                Name = "TestCategory"
            };

            var id = Repository.Insert(newCategory);

            Assert.IsNotNull(id);
            Assert.AreNotEqual(0, id.Value);

            var item = Repository.FindAll<SystemValueCategory>(x => x.Id == id).SingleOrDefault();
            
            Assert.IsNotNull(item);

            Repository.Delete(item);
        }

        [TestMethod]
        public void CanUpdateSystemValueCategory()
        {
            const string newName = "MySettingsUpdated123";
            const string oldName = "Licence";

            var systemValueCategoryOld = Repository.FindAll<SystemValueCategory>(svc => svc.Name == oldName).SingleOrDefault();

            Assert.IsNotNull(systemValueCategoryOld);

            systemValueCategoryOld.Name = newName;

            Repository.Update(systemValueCategoryOld);

            var systemValueCategoryNew = Repository.FindAll<SystemValueCategory>(svc => svc.Name == newName).SingleOrDefault();

            Assert.IsNotNull(systemValueCategoryNew);
            Assert.AreEqual(systemValueCategoryNew.Name, systemValueCategoryOld.Name);

            systemValueCategoryOld.Name = oldName;
            Repository.Update(systemValueCategoryOld);
        }
    }
}
