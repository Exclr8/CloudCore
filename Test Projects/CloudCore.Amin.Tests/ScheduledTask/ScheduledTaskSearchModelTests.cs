using System;
using System.Linq;
using CloudCore.Admin.Areas.Admin.Models;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Admin.Tests.ScheduledTask
{
    [TestClass]
    public class ScheduledTaskSearchModelTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        [TestMethod]
#if !DEBUG // TODO: We don't have workflow processes and scheduled tasks yet for the released version of CloudCore. (Database script)
        [Ignore]
#endif
        public void ScheduledTaskSearchModel_Search_NoInput_ItemsFound()
        {
            var model = new ScheduledTaskSearchModel();
            model.Search(Repository);
            Assert.IsTrue(model.SearchResults.Any());
        }

        [TestMethod]
#if !DEBUG
        [Ignore]
#endif
        public void ScheduledTaskSearchModel_Search_NonExistentName_NoItemsFound()
        {
            var model = new ScheduledTaskSearchModel { ScheduledTaskName = Guid.NewGuid().ToString(), ScheduledTaskNameFilter = "%{0}%" };
            model.Search(Repository);
            Assert.IsFalse(model.SearchResults.Any());
        }

        [TestMethod]
#if !DEBUG
        [Ignore]
#endif
        public void ScheduledTaskSearchModel_Search_ValidIntervalType_ItemsFound()
        {
            var model = new ScheduledTaskSearchModel { IntervalTypeName = "sec", IntervalTypeNameFilter = "{0}%" };
            model.Search(Repository);
            Assert.IsTrue(model.SearchResults.Any());
        }

        [TestMethod]
#if !DEBUG
        [Ignore]
#endif
        public void ScheduledTaskSearchModel_Search_AnyTaskType_TwoItemsFound()
        {
            var model = new ScheduledTaskSearchModel { ScheduledTaskType = "Any" };
            model.Search(Repository);
            Assert.AreEqual(2, model.SearchResults.Count());
        }

        [TestMethod]
#if !DEBUG
        [Ignore]
#endif
        public void ScheduledTaskSearchModel_Search_SqlTaskType_OneItemFound()
        {
            var model = new ScheduledTaskSearchModel { ScheduledTaskType = "Sql" };
            model.Search(Repository);
            Assert.AreEqual(1, model.SearchResults.Count());
        }

        [TestMethod]
#if !DEBUG
        [Ignore]
#endif
        public void ScheduledTaskSearchModel_Search_CSharpTaskType_OneItemFound()
        {
            var model = new ScheduledTaskSearchModel { ScheduledTaskType = "CSharp" };
            model.Search(Repository);
            Assert.AreEqual(1, model.SearchResults.Count());
        }

        [TestMethod]
#if !DEBUG
        [Ignore]
#endif
        [ExpectedException(typeof(ArgumentException))]
        public void ScheduledTaskSearchModel_Search_InvalidTaskType_Error()
        {
            var model = new ScheduledTaskSearchModel { ScheduledTaskType = "garbage" };
            model.Search(Repository);
        }
    }
}
