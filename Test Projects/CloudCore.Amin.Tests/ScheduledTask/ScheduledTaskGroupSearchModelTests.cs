using System;
using System.Linq;
using CloudCore.Admin.Areas.Admin.Models.ScheduledTaskGroup;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Admin.Tests.ScheduledTask
{
    [TestClass]
    public class ScheduledTaskGroupSearchModelTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        [TestMethod]        
#if !DEBUG // TODO: We don't have workflow processes and scheduled tasks yet for the released version of CloudCore. (Database script)
        [Ignore]
#endif
        public void ScheduledTaskGroupSearchModel_DefaultInput_ItemsFound()
        {
            var model = new ScheduledTaskGroupSearchModel();
            model.Search(Repository);
            Assert.IsTrue(model.SearchResults.Any());
        }

        [TestMethod]
#if !DEBUG 
        [Ignore]
#endif
        public void ScheduledTaskGroupSearchModel_Search_NonExistentName_NoItemsFound()
        {
            var model = new ScheduledTaskGroupSearchModel {  Name = Guid.NewGuid().ToString(), NameFilter = "%{0}%" };
            model.Search(Repository);
            Assert.IsFalse(model.SearchResults.Any());
        }

        [TestMethod]
#if !DEBUG 
        [Ignore]
#endif
        public void ScheduledTaskGroupSearchModel_Search_InvalidManagerName_NoItemsFound()
        {
            var model = new ScheduledTaskGroupSearchModel { UserName = Guid.NewGuid().ToString(), UserNameFilter = "%{0}%" };
            model.Search(Repository);
            Assert.IsFalse(model.SearchResults.Any());
        }
    }
}
