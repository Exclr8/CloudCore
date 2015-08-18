using CloudCore.Configuration.ConfigFile;
using Frameworkone.ThirdParty.Clickatell;
using Frameworkone.UnitTestUtilities.Clickatell.Decorators;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace Clickatell.Database.Tests
{
    [TestClass]
    public class ClickatellDatabaseTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        public ClickatellDatabaseTests()
        {
            ObjectFactory.Configure(SetDefaultClickatellSettings);
        }

        [TestMethod]
#if !DEBUG
        [Ignore] // This is not used in production yet (nuget release will contain the wrong sql data scripts for live deployment)
#endif
        public void ClickatellClient_DoesProviderRetrieveSettingsFromDatabase()
        {
            var dbProvider = new ClickatellDatabaseSettings(Repository);
            var clickatellSettings = dbProvider.GetSettings();
            AssertSettingsPopulated(clickatellSettings);
        }

        private static void AssertSettingsPopulated(ClickatellSettings clickatellSettings)
        {
            Assert.AreEqual("myusername", clickatellSettings.Username);
            Assert.AreEqual("mypassword", clickatellSettings.Password);
            Assert.AreEqual("myapikey", clickatellSettings.ApiKey);
        }

        private static void SetDefaultClickatellSettings(ConfigurationExpression config)
        {
            var clickatellConfigFileSettings = SetDefaultClicktellConfig(config);
            SetDefaultClickatellClient(clickatellConfigFileSettings, config);
        }

        private static ClickatellConfigFileSettings SetDefaultClicktellConfig(ConfigurationExpression x)
        {
            var clickatellConfigFileSettings = new ClickatellConfigFileSettings();
            x.For<IClickatellSettingsProvider>().Use(clickatellConfigFileSettings);
            return clickatellConfigFileSettings;
        }

        private static void SetDefaultClickatellClient(ClickatellConfigFileSettings clickatellConfigFileSettings,
            ConfigurationExpression x)
        {
            var clickatellClient = new ClickatellClient(clickatellConfigFileSettings);
            x.For<ClickatellClient>()
                .Use(new IgnoreAuthErrorClickatellClient(clickatellConfigFileSettings,
                    new IgnoreNoCreditErrorClickatellClient(clickatellConfigFileSettings, clickatellClient)));
        }
    }
}
