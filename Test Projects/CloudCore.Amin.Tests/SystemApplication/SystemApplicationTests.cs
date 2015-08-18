using System;
using System.Linq;
using CloudCore.Admin.Areas.Admin.Models;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Admin.Tests.SystemApplication
{
    [TestClass]
    public class SystemApplicationTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        [TestMethod]
        public void SystemApplication_Search_NoInput_ItemsFound()
        {
            var model = new SystemApplicationSearchModel();
            model.Search(Repository);
            Assert.IsTrue(model.SearchResults.Any());
        }

        [TestMethod]
        public void SystemApplication_Search_NonExistentName_NoItemsFound()
        {
            var model = new SystemApplicationSearchModel { ApplicationName = Guid.NewGuid().ToString(), FilterOptionsApplicationName = "%{0}%" };
            model.Search(Repository);
            Assert.IsTrue( !model.SearchResults.Any() );
        }

        [TestMethod]
        public void SystemApplication_Search_CompanyNameStartsWith_frame_AtLeastTwoItemsFound()
        {
            var model = new SystemApplicationSearchModel { CompanyName = "frame", FilterOptionsCompanyName = "{0}%" };
            model.Search(Repository);
            Assert.IsTrue(model.SearchResults.Count() >= 2);
        }

        [TestMethod]
        public void SystemApplication_Search_ContactPersonContains_mehlhorn_AtLeastTwoItemsFound()
        {
            var model = new SystemApplicationSearchModel { ContactPerson = "mehlhorn", FilterOptionsContactPerson = "%{0}%" };
            model.Search(Repository);
            Assert.IsTrue(model.SearchResults.Count() >= 2);
        }
    }
}
