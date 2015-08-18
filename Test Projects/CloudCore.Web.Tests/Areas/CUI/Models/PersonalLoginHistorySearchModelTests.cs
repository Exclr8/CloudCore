using System;
using System.Linq;
using CloudCore.Domain;
using CloudCore.Web.Areas.CUI.Models;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Web.Tests.Areas.CUI.Models
{
    [TestClass]
    public class PersonalLoginHistorySearchModelTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        private const int UserId = 0;
        
        [TestInitialize]
        public void TestInit()
        {
            CreateLoginAttempt();
        }

        [TestMethod]
        public void PersonalLoginHistorySearchModel_Search_NoInput_ItemsFound()
        {
            // arrange
            var model = new PersonalLoginHistorySearchModel { StartDate = DateTime.Today, EndDate = DateTime.Now };
            // act
            model.Search(Repository, UserId);
            // assert
            Assert.IsTrue(model.SearchResults.Any());
            // annihilate
        }

        [TestMethod]
        public void PersonalLoginHistorySearchModel_Search_NonExistingUserId_NoItemsFound()
        {
            // arrange
            var model = new PersonalLoginHistorySearchModel { StartDate = DateTime.Today, EndDate = DateTime.Now };
            // act
            model.Search(Repository, -9999);
            // assert
            Assert.IsFalse(model.SearchResults.Any());
            // annihilate
        }

        private void CreateLoginAttempt()
        {
            var user = Repository.Get<Domain.User>(0);
            user.UpdateLogin(Repository, applicationId: 1);
        }
    }
}
