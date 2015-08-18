using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Configuration.ConfigFile.Tests
{
    [TestClass]
    public class CloudCoreWebSettingsTests
    {
        private const string DefaultNamespace = "CloudCore.Web.Areas.CUI.Controllers";

        [TestMethod]
        public void CloudCoreWebSettings_DefaultActionHasNamespace()
        {
            Assert.AreEqual(DefaultNamespace, ReadConfig.SettingsOnWebApplication.WebSettings.DefaultAction.Namespace);
        }

        [TestMethod]
        public void CloudCoreWebSettings_LoginActionHasNamespace()
        {
            Assert.AreEqual(DefaultNamespace, ReadConfig.SettingsOnWebApplication.WebSettings.LoginAction.Namespace);
        }
    }
}
