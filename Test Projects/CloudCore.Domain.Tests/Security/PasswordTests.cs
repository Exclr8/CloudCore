using CloudCore.Domain.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Domain.Tests.Security
{
    [TestClass]
    public class PasswordTests
    {
        private readonly Password password = new Password("password");
        
        [TestMethod]
        public void Password_Compare_CorrectPasswordAndPasswordHash_ReturnsTrue()
        {
            var result = password.Compare(5, "eb1e77f4f9deb2c001ad694ba59939755____");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Password_Compare_IncorrectPasswordPasswordHash_ReturnsFalse()
        {
            var result = password.Compare(5, "eb1e77f4f9deb2c041ad694ba59939755____");

            Assert.IsFalse(result);
        }
    }
}
