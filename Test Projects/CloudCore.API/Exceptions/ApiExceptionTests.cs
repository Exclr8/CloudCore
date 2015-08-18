using System;
using CloudCore.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.API.Tests.Exceptions
{
    [TestClass]
    public class ApiExceptionTests
    {
        [TestMethod]
        public void ApiException_CanInstantiateDefault()
        {
            var ex = new ApiException();
            Assert.IsNotNull(ex);
            Assert.IsInstanceOfType(ex, typeof(Exception));
        }

        [TestMethod]
        public void ApiException_CanInstantiateWithInnerException()
        {
            var ex = new ApiException("hallo", new Exception("test"));
        }

        [TestMethod]
        public void ApiException_CanInstantiateWithMessage()
        {
            var ex = new ApiException("bye");
        }
    }
}
