using System.Globalization;
using CloudCore.Core;
using CloudCore.Core.Data;
using CloudCore.Core.DependencyResolution;
using CloudCore.Core.Security.Api;
using Frameworkone.Caching;
using Frameworkone.UnitTestUtilities.Cache;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudCore.Data;

namespace CloudCore.API.Tests.Core.Common.API
{
    [TestClass]
    public class AccessTokenTest
    {
        private readonly ICacheProvider cacheProvider = new InMemoryCacheProvider(new CachePolicyFake());

        public AccessTokenTest()
        {
            var dataModule = new CloudCoreDataModule();
            IoC.Initialize();
            IoC.ScanModule(dataModule);
            IoC.AdditionalConfiguration(dataModule);
        }

        [TestMethod]
        public void AccessToken_CreateToken_NotNull()
        {
            var token = new AccessToken(Repository.Instance, 1, 0, cacheProvider);

            token.UpdateUserLogin(Repository.Instance);
            token.WriteToCache(cacheProvider);

            Assert.IsNotNull(token);
        }

        [TestMethod]
        public void AccessToken_ValidateCaching()
        {
            var token = new AccessToken(Repository.Instance, 1, 0, cacheProvider);

            token.UpdateUserLogin(Repository.Instance);
            token.WriteToCache(cacheProvider);

            var secret = token.Secret;
            var token2 = AccessToken.ReadFromCache(secret, cacheProvider);
            Assert.IsNotNull(token, "Token not set.");
            Assert.IsNotNull(token2, "Deserialized token is null.");
            Assert.IsTrue(token.UserId == token2.UserId, "UserId is not the same for the token after caching.");
            Assert.IsTrue(token.ApplicationId == token2.ApplicationId, "ApplicationId is not the same for the token after caching.");
            Assert.IsTrue(token.Expiry.ToString(CultureInfo.InvariantCulture) == token2.Expiry.ToString(CultureInfo.InvariantCulture), "Expiry is not the same for the token after caching.");
        }

    }
}
