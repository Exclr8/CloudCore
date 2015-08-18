using System;
using CloudCore.Web.Areas.CUI.Controllers;
using CloudCore.Web.Areas.CUI.Models;
using Frameworkone.UnitTestUtilities.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Web.Tests.Areas.CUI.Controllers
{
    [TestClass]
    public class LoginControllerTests : BaseMailManControllerTest<LoginController>
    {
        [TestMethod]
        // [Ignore] // Test not conclusive, as we do not test any conditions afterward. We expect a login failure message back (empty logon details)
        public void LoginController_Login_Test()
        {
            Controller.Index(new LogOnModel { }, string.Empty);
        }
    }
}
