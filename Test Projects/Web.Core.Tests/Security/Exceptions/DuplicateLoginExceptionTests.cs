using System;
using CloudCore.Web.Core.Security.Authentication.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Core.Tests.Security.Exceptions
{
    [TestClass]
    public class DuplicateLoginExceptionTests
    {
        [TestMethod]
        public void DuplicateLoginException_CanInstantiateDefault()
        {
            var ex = new DuplicateLoginException();
            Assert.IsNotNull(ex);
            Assert.IsInstanceOfType(ex, typeof(Exception));
        }

        [TestMethod]
        public void DuplicateLoginException_CanInstantiateWithInnerException()
        {
            var ex = new DuplicateLoginException("hallo", new Exception("test"));
        }

        [TestMethod]
        public void DuplicateLoginException_CanInstantiateWithMessage()
        {
            var ex = new DuplicateLoginException("bye");
        }
    }
}
