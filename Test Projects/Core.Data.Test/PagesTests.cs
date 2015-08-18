using System;
using System.Linq;
using CloudCore.Domain;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Data.Tests
{
    [TestClass]
    public class PagesTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        [TestInitialize]
        public void Init()
        {
            var systemAction = new SystemAction
            {
                
            };
        }

        [TestMethod]
        public void CanInsertPage()
        {
          
        }
    }
}
