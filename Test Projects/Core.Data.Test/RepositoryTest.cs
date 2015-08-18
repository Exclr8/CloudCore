using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Data.Tests
{
    [TestClass]
    public class RepositoryTest : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        [TestMethod]
        public void CanConstructRepository()
        {
            Assert.IsNotNull(Repository);
        }
    }
}
