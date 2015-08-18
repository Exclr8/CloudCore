using System;
using CloudCore.Domain;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Data.Tests
{
    [TestClass]
    public class SystemModuleTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        [TestMethod]
        public void CanUploadSystemModule()
        {
            var guid = Guid.NewGuid();

            var module = new SystemModule
            {
                AssemblyName = "Assembly Module Test",
                Id = 0,
                SystemModuleGuid = guid
            };

            module.Register(Repository);

            var systemModule = Repository.FindAll<SystemModule>(sm => sm.AssemblyName == module.AssemblyName);

            Assert.IsNotNull(systemModule);
            Assert.AreEqual("Assembly Module Test", module.AssemblyName);
            Assert.AreEqual(guid, module.SystemModuleGuid);
        }
    }
}
