using System;
using System.Linq;
using CloudCore.Web.Areas.CUI.Models;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Web.Tests.Areas.CUI.Models
{
    [TestClass]
    public class AccessPoolLookupModelTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        [TestMethod]
        public void AccessPoolLookupModel_Search_NoInput_ItemsFound()
        {
            var model = new AccessPoolLookupModel();
            model.Search(Repository);
            Assert.IsTrue(model.SearchResults.Any());
        }
    }
}
