using System;
using CloudCore.Configuration.SettingsProviders;
using Frameworkone.Configuration;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SettingsProvider.Tests
{

    [TestClass]
    public class DbSettingsProviderTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        private const int DefaultTestingIntergerSettingValueTwo = 2;
        public readonly DateTime DefaultDateTimeConfigValue = new DateTime(2009, 10, 17, 14, 31, 27);
        private const double DefaultDoubleConfigSetting = 2.7;

        [TestMethod]
        public void SettingsProvider_CanMapIntegers()
        {
            var integerSettings = new MySettingsWithIntegers() { NumberValue = DefaultTestingIntergerSettingValueTwo };
            var integerProvider = new DbSettingsProvider<MySettingsWithIntegers>(Repository);
            integerProvider.Save(integerSettings);
            var settings = integerProvider.Load();
            Assert.AreEqual(DefaultTestingIntergerSettingValueTwo, settings.NumberValue);
        }

        [TestMethod]
        public void SettingsProvider_CanMapDateTime()
        {
            var dateTimeConfigProvider = new DbSettingsProvider<MySettingsWithDateTime>(Repository);
            var dateTimeSettings = new MySettingsWithDateTime() { DateTimeValue = DefaultDateTimeConfigValue };
            dateTimeConfigProvider.Save(dateTimeSettings);
            var myOwnSettings = dateTimeConfigProvider.Load();
            Assert.AreEqual(DefaultDateTimeConfigValue, myOwnSettings.DateTimeValue);
        }

        [TestMethod]
        public void SettingsProvider_CanMapDouble()
        {
            var doubleTypeProvider = new DbSettingsProvider<MySettingsWithTypeDouble>(Repository);

            var myOwnSettings = new MySettingsWithTypeDouble { DoubleValue = DefaultDoubleConfigSetting };
            doubleTypeProvider.Save(myOwnSettings);
            myOwnSettings = doubleTypeProvider.Load();
            Assert.AreEqual(DefaultDoubleConfigSetting, myOwnSettings.DoubleValue);
        }

        public class MySettingsWithIntegers : ISettings
        {
            public int NumberValue { get; set; }
        }

        public class MySettingsWithDateTime : ISettings
        {
            public DateTime DateTimeValue { get; set; }
        }

        public class MySettingsWithTypeDouble : ISettings
        {
            public double DoubleValue { get; set; }
        }
    }
}
