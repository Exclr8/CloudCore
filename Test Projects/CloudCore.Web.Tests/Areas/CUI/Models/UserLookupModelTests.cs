using System;
using System.Linq;
using CloudCore.Web.Areas.CUI.Models;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Web.Tests.User
{
    [TestClass]
    public class UserLookupModelTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        [TestMethod]
#if !DEBUG // The only two users distributed with Cloudcore (Release) database script are -99 (Virtual Worker) and 0 (System/Admin), and the search excludes them always.
        [Ignore]
#endif
        public void UserLookupModel_Search_NoInput_ItemsFound()
        {
            var model = new UserLookupModel();
            model.Search(Repository);
            Assert.IsTrue(model.SearchResults.Any());
        }

        [TestMethod]
#if !DEBUG 
        [Ignore]
#endif
        public void UserLookupModel_Search_ValidExistingUser_ItemsFound()
        {
            var model = new UserLookupModel { UserFullName = "Mehlhorn", UserFullNameOptions = "%{0}%" };
            model.Search(Repository);
            Assert.IsTrue(model.SearchResults.Any());
        }

        [TestMethod]
        public void UserLookupModel_Search_InValidExistingUser_NoItemsFound()
        {
            var model = new UserLookupModel { UserFullName = Guid.NewGuid().ToString(), UserFullNameOptions = "%{0}%" };
            model.Search(Repository);
            Assert.IsFalse(model.SearchResults.Any());
        }
    }
}
