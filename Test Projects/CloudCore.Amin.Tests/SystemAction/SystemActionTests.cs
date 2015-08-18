using System;
using System.Linq;
using CloudCore.Admin.Areas.Admin.Models;
using CloudCore.Web.Core.Security.Authorization;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Admin.Tests.SystemAction
{
    [TestClass]
    public class SystemActionTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        private const string ContainsFilterText = "%{0}%";
        [TestMethod]
        public void PagesSearchModel_Search_NoInput_ItemsFound()
        {
            var model = new PagesSearchModel();
            model.Search(Repository);
            Assert.IsTrue(model.SearchResults.Any());
        }

        [TestMethod]
        public void PagesSearchModel_Search_InvalidTitle_NoItemsFound()
        {
            var model = new PagesSearchModel { ActionTitle = Guid.NewGuid().ToString(), FilterOptionsActionTitle = ContainsFilterText };
            model.Search(Repository);
            Assert.IsFalse(model.SearchResults.Any());
        }

        [TestMethod]
        public void PagesSearchModel_Search_ValidExistingData_ItemsFound()
        {
            var model = new PagesSearchModel
            {
                Area = "admin", 
                FilterOptionsArea = "{0}",
                Controller = "user",
                FilterOptionsController = ContainsFilterText,
                Action = "e",
                FilterOptionsAction = ContainsFilterText,
                ActionType = "i",
                FilterOptionsActionType = ContainsFilterText,
                SystemModule = "admin",
                FilterOptionsSysModule = ContainsFilterText
            };

            model.Search(Repository);
            Assert.IsTrue(model.SearchResults.Any());
        }

        /// <summary>
        /// We know the admin module does not require page rights
        /// </summary>
        /// <seealso cref="UserPermission.RefreshPermissions"/>
        [TestMethod]
        public void PageWithoutRightsModel_Search_NoInput_ItemsFound()
        {
            var model = new PageWithoutRightsModel();
            model.Search(Repository);
            Assert.IsTrue(model.SearchResults.Any());
        }

        [TestMethod]
        public void PageWithoutRightsModel_Search_SystemActionGuidsNotEmpty()
        {
            var model = new PageWithoutRightsModel();
            model.Search(Repository);
            Assert.IsFalse(model.SearchResults.Any(a => a.ActionGuid == Guid.Empty && a.ActionId != 0));
        }

        [TestMethod]
        public void PageAccessPoolLookupModel_Search_NoInput_ItemsFound()
        {
            var model = new PageAccessPoolLookupModel { ActionId = 3 };
            model.Search(Repository);
            Assert.IsTrue(model.SearchResults.Any());
        }

        [TestMethod]
        public void PageAccessPoolLookupModel_Search_NonExistingPoolName_NoItemsFound()
        {
            var model = new PageAccessPoolLookupModel { ActionId = 3, Name = Guid.NewGuid().ToString(), FilterOptions = "%{0}%" };
            model.Search(Repository);
            Assert.IsFalse(model.SearchResults.Any());
        }

        [TestMethod]
        public void PageAccessPoolLookupModel_Search_ExistingPoolName_ItemsFound()
        {
            var model = new PageAccessPoolLookupModel { ActionId = 3, Name = "cloud", FilterOptions = "%{0}%" };
            model.Search(Repository);
            Assert.IsTrue(model.SearchResults.Any());
        }
    }
}
