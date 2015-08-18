using System;
using System.Linq;
using CloudCore.Admin.Areas.Admin.Models;
using CloudCore.Domain.Workflow;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Admin.Tests.Workflow
{
    [TestClass]
    public class WorklistTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        [TestMethod]
#if !DEBUG // TODO: We don't have workflow processes and scheduled tasks yet for the released version of CloudCore. (Database script)
        [Ignore]
#endif
        public void WorkListFailureReasonModel_Instantiate_FailedItemsFound()
        {
            // arrange
            var workItem = Repository.FindAll<WorkItem>().First();
            workItem.Fail("Testing", WorkItemStatus.Failed, Repository);

            // act
            var model = new WorkListFailureReasonModel(workItem.Id.Value, Repository);

            //assert
            Assert.IsTrue(model.Reasons.Any());

            // annihilate
        }
    }
}
