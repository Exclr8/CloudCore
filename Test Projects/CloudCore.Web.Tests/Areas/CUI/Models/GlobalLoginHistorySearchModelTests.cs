using System;
using System.Linq;
using CloudCore.Domain;
using CloudCore.Web.Areas.CUI.Models;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Web.Tests.Areas.CUI.Models
{
    [TestClass]
    public class GlobalLoginHistorySearchModelTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        private const int UserId = 0;

        [TestInitialize]
        public void TestInit()
        {
            CreateLoginAttempt(UserId);
        }

        [TestMethod]
        public void GlobalLoginHistorySearchModel_Search_NoInput_ItemsFound()
        {
            // arrange
            var model = new GlobalLoginHistorySearchModel { StartDate = DateTime.Today, EndDate = DateTime.Now };
            // act
            model.Search(Repository);
            // assert
            Assert.IsTrue(model.SearchResults.Any());
            // annihilate
        }

        [TestMethod]
        public void GlobalLoginHistorySearchModel_Search_NonExistingUser_NoItemsFound()
        {
            // arrange
            var model = new GlobalLoginHistorySearchModel { StartDate = DateTime.Today, EndDate = DateTime.Now, UserFullName = Guid.NewGuid().ToString(), FilterOptions = "%{0}%" };
            // act
            model.Search(Repository);
            // assert
            Assert.IsFalse(model.SearchResults.Any());
            // annihilate
        }

        private void CreateLoginAttempt(int userId = UserId)
        {
            var user = Repository.Get<Domain.User>(0);
            user.UpdateLogin(Repository, applicationId: 1);
        }
    }
}
