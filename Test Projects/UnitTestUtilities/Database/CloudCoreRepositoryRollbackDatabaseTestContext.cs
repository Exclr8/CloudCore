using System.Data.Common;
using CloudCore.Core.Data;
using CloudCore.Core.DependencyResolution;
using CloudCore.Data.Buildbase;
using Frameworkone.Caching;
using Frameworkone.Domain;
using CloudCore.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudCore.Data;

namespace Frameworkone.UnitTestUtilities.Database
{
    public abstract class CloudCoreRepositoryRollbackDatabaseTestContext //: TestBase
    {
        private CloudCoreDBBase database;
        public CloudCoreDBBase DataProvider
        {
            get
            {
                return database;
            }
        }

        private DbTransaction transaction;

        private readonly IRepository repository;
        public IRepository Repository
        {
            get
            {
                return repository;
            }
        }

        protected CloudCoreRepositoryRollbackDatabaseTestContext()
        {
            SetupIocForDataTests();
            repository = CloudCore.Core.Repository.Instance;
            //database = (CloudCoreDBBase)ObjectFactory.GetInstance<IDataProvider>();
        }

        private void SetupIocForDataTests()
        {
            var dataModule = new CloudCoreDataModule();
            IoC.Initialize();
            IoC.ScanModule(dataModule);
            IoC.AdditionalConfiguration(dataModule);
        }

        [TestInitialize]
        public void InitDataContext()
        {
            if (database.Connection.State != System.Data.ConnectionState.Open)
            {
                database.Connection.Open();
            }

            transaction = database.Connection.BeginTransaction();
            database.Transaction = transaction;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            transaction.Rollback();
            database.Dispose();
            database = null;
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            //ObjectFactory.GetInstance<ICacheProvider>().Flush();
        }
    }
}
