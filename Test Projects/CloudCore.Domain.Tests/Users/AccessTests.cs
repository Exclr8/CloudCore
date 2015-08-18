using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Domain.Tests.Users
{
    [TestClass]
    public class AccessTests
    {
        [TestMethod]
        public void Access_NewInstance_DefaultActiveIsFalse()
        {
            var access = new Access();
            Assert.IsFalse(access.Active);
        }

        [TestMethod]
        public void Access_InternalOnly_ActiveIsTrue()
        {
            var access = new Access { InternalAccess = true };
            Assert.IsTrue(access.Active);
        }

        [TestMethod]
        public void Access_ExternalOnly_ActiveIsTrue()
        {
            var access = new Access { ExternalAccess = true };
            Assert.IsTrue(access.Active);
        }

        [TestMethod]
        public void Access_InternalAndExternal_ActiveIsTrue()
        {
            var access = new Access { ExternalAccess = true, InternalAccess = true };
            Assert.IsTrue(access.Active);
        }
    }
}
