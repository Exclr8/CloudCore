using System;
using System.Linq;
using CloudCore.Admin.Areas.Admin.Models;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Admin.Tests.SystemValues
{
    [TestClass]
    public class SystemValueCategoryTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        [TestMethod]
        public void SystemValueCategorySearchModel_Search_NoInput_ItemsFound()
        {
            var model = new SystemValueCategorySearchModel();
            model.Search(Repository);
            Assert.IsTrue(model.SearchResults.Any());
        }

        [TestMethod]
        public void SystemValueCategorySearchModel_Search_CategoryNameMatches_license_OneItemFound()
        {
            var model = new SystemValueCategorySearchModel { CategoryName = "licence", FilterOptions = "{0}"};
            model.Search(Repository);
            Assert.IsTrue(model.SearchResults.Count() == 1);
        }

        [TestMethod]
        public void SystemValueCategorySearchModel_Search_NonExistentCategoryName_NoItemsFound()
        {
            var model = new SystemValueCategorySearchModel { CategoryName = Guid.NewGuid().ToString(), FilterOptions = "{0}" };
            model.Search(Repository);
            Assert.IsFalse(model.SearchResults.Any());
        }
    }
}
