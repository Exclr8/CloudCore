using System;
using System.Collections.Generic;
using System.Linq;
using CloudCore.Web.Core.BaseModels;
using Frameworkone.Domain;
using Frameworkone.UnitTestUtilities.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Core.Tests.BaseModels
{
    [TestClass]
    public class BaseSearchModelTests
    {
        [TestMethod]
        public void CanIntialiseSearchResults()
        {
            var baseSearchResultsTestClass = new BaseSearchResultsTestClass();

            baseSearchResultsTestClass.Search(MockHelper.MockRepository());

            Assert.IsNotNull(baseSearchResultsTestClass.SearchResults);
        }

        [TestMethod]
        public void CanAddItemsToSearchResults()
        {
            var baseSearchResultsTestClass = new BaseSearchResultsTestClass();

            baseSearchResultsTestClass.Search(MockHelper.MockRepository());

            Assert.AreEqual(1, baseSearchResultsTestClass.SearchResults.Count());
        }
    }

    public class BaseSearchResultsTestClassEntity : Entity
    {
    }

    public class BaseSearchResultsTestClass : BaseSearchModel<BaseSearchResultsTestClassEntity>
    {
        public override void Search(IRepository repository)
        {
            SearchResults = new List<BaseSearchResultsTestClassEntity>
            {
                new BaseSearchResultsTestClassEntity { Id = 1 }
            };
        }
    }
}
