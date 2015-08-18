using CloudCore.Core.Data;
using CloudCore.Core.DependencyResolution;
using CloudCore.Data;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KpiDashboardTests
{
    [TestClass]
    public class KpiImgTests
    {

        [TestInitialize]
        public void Init()
        {
            SetupIocForDataTests();
        }

        private void SetupIocForDataTests()
        {
            var dataModule = new CloudCoreDataModule();
            IoC.Initialize();
            IoC.ScanModule(dataModule);
            IoC.AdditionalConfiguration(dataModule);
        }

        [TestMethod]
        public void AreAllFilesGenerating()
        {
            var dashTest = new TestKpiImgDashboard();

            dashTest.Execute();
        }
    }
}
