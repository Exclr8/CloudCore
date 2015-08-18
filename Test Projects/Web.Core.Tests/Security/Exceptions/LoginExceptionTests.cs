using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudCore.Web.Core.Security.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Web.Core.Tests
{

    [TestClass]
    public class LoginExceptionTests
    {
        [TestMethod]
        public void LoginException_CanInstantiateDefault()
        {
            var ex = new LoginException();
            Assert.IsNotNull(ex);
            Assert.IsInstanceOfType(ex, typeof(Exception));
        }

        [TestMethod]
        public void LoginException_CanInstantiateWithInnerException()
        {
            var ex = new LoginException("hallo", new Exception("test"));
        }

        [TestMethod]
        public void LoginException_CanInstantiateWithMessage()
        {
            var ex = new LoginException("bye");
        }
    }
}
