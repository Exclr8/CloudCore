using CloudCore.Core.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Common.Tests
{
    [TestClass]
    public class EncryptionTests
    {
        private const string OriginalString = "1234567";
        private const string OriginalSalt = "helloworld";

        [TestMethod]
        public void EncryptReturnsEmptyIfInputIsEmpty()
        {            
            var result = Encryption.Encrypt("");

            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void EncryptSaltIsNotNullOrEmpty()
        {
            var result = Encryption.Encrypt(OriginalString, OriginalSalt);

            Assert.AreEqual("Rljn+XBn1ALwE2YsdpRifQ==", result);
        }

        [TestMethod]
        public void DecryptReturnsEmptyIfInputIsEmpty()
        {
            var result = Encryption.Decrypt("");

            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void CanDecryptWithSalt()
        {
            var encrypted = Encryption.Encrypt(OriginalString, OriginalSalt);

            var decrypted = Encryption.Decrypt(encrypted, OriginalSalt);

            Assert.AreEqual(OriginalString, decrypted);
        }

        [TestMethod]
        public void CanDecryptWithoutSalt()
        {
            var encrypted = Encryption.Encrypt(OriginalString);

            var decrypted = Encryption.Decrypt(encrypted);

            Assert.AreEqual(OriginalString, decrypted);
        }
    }
}
