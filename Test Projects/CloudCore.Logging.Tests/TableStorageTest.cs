using Frameworkone.UnitTestUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Logging.Tests
{
    [TestClass]
    public class TableStorageTest //: TestBase
    {
        private static TableStorageLogger loggerTs;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            loggerTs = new TableStorageLogger();
            Assert.IsNotNull(loggerTs);
        }


        [TestMethod]
        [Ignore] // OData and Edm issues
        public void TableStorageLogger_DebugTest()
        {
            loggerTs.Debug("test", "Category");
        }

        [TestMethod]
        [Ignore] // OData and Edm issues
        public void TableStorageLogger_WriteLineTest()
        {
            loggerTs.WriteLine("Test.WriteLine.Category", "Category");
            Logger.WriteLine("isInRole?");
        }


    }
}
