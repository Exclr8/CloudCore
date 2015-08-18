using System;
using System.Linq;
using CloudCore.Admin.Areas.Admin.Models;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Admin.Tests.Workflow
{
    [TestClass]
    public class ActivityTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        [TestMethod]
#if !DEBUG // TODO: We don't have any workflow processes or scheduled tasks yet for the released version of CloudCore. (Database script)
        [Ignore]
#endif
        public void ActivitySearchModel_Search_NoInput_ActivitiesFound()
        {
            var model = new ActivitySearchModel();
            model.Search(Repository);
            Assert.IsTrue(model.SearchResults.Any());
        }

        [TestMethod]
        public void ActivitySearchModel_Search_NonExistentName_ResultEmtpy()
        {
            var model = new ActivitySearchModel { ActivityName = Guid.NewGuid().ToString(), ActivityNameFilter = "%{0}%" };
            model.Search(Repository);
            Assert.IsFalse(model.SearchResults.Any());
        }

        [TestMethod]
#if !DEBUG 
        [Ignore]
#endif
        public void ActivitySearchModel_Search_ExistingDataFiltered_ItemsFound()
        {
            var model = new ActivitySearchModel
            {
                ModuleName = "cloudcore", 
                ModuleNameFilter = "%{0}%", 
                ProcessName = "test", 
                ProcessNameFilter = "%{0}%",
                SubProcessName = "test",
                SubProcessNameFilter = "%{0}%"
            };

            model.Search(Repository);
            Assert.IsTrue(model.SearchResults.Any());
        }

        [TestMethod]
#if !DEBUG 
        [Ignore]
#endif
        public void ActivityLookupModel_Search_ApplicationId_0_NoOtherInput_ItemsFound()
        {
            var model = new ActivityLookupModel(applicationIdBeingSearched: 0);
            model.Search(Repository);
            Assert.IsTrue(model.SearchResults.Any());
        }
    }
}
