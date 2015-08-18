using System;
using System.IO;
using CloudCore.Core.Hosting.VirtualFiles;
using CloudCore.Core.Modules;
using Frameworkone.UnitTestUtilities.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Core.Tests.CloudCoreVirtualFiles
{
    [TestClass]
    public class CloudCoreVirtualFileTests
    {
        private CloudCoreVirtualFileTestClass cloudCoreVirtualFileTestClass;

        private const string VirtualPath = "VirtualPath";
        private const string ResourcePath = "ResourcePath";
        private CloudCoreModule cloudCoreModule;

        [TestInitialize]
        public void Init()
        {
            cloudCoreModule = MockHelper.CreateSimpleGenericMock<CloudCoreModule>();
            cloudCoreVirtualFileTestClass = new CloudCoreVirtualFileTestClass(VirtualPath, cloudCoreModule, ResourcePath);
        }

        [TestMethod]
        public void CanSetCloudCoreModule()
        {
            Assert.AreEqual(cloudCoreModule, cloudCoreVirtualFileTestClass.Module);
        }

        [TestMethod]
        public void CanSetResourcePath()
        {
            Assert.AreEqual(ResourcePath, cloudCoreVirtualFileTestClass.ResourcePath);
        }

        [TestMethod]
        public void CanSetVirtualPath()
        {
            Assert.AreEqual(VirtualPath, cloudCoreVirtualFileTestClass.VirtualPath);
        }

        [TestMethod]
        public void CanGetResourceHash()
        {
            const string resourceHash = "94e0328e309320616893196fc14a4605";

            Assert.AreEqual(resourceHash, cloudCoreVirtualFileTestClass.ResourceHash);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfModuleIsNullCatchException()
        {
            cloudCoreVirtualFileTestClass = null;
            cloudCoreVirtualFileTestClass = new CloudCoreVirtualFileTestClass(VirtualPath, null, ResourcePath);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfResourcePathIsEmptyCatchException()
        {
            cloudCoreVirtualFileTestClass = null;

            cloudCoreVirtualFileTestClass = new CloudCoreVirtualFileTestClass(VirtualPath, cloudCoreModule, "");
           
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IfFlushToDiskCatchException()
        {
            cloudCoreVirtualFileTestClass.FlushToDisk("");
        }
    }

    public class CloudCoreVirtualFileTestClass : CloudCoreVirtualFile
    {
        public CloudCoreVirtualFileTestClass(string virtualPath, CloudCoreModule module, string resourcePath)
            : base(virtualPath, module, resourcePath)
        {
        }

        public override Stream Open()
        {
            throw new NotImplementedException();
        }
    }
}
