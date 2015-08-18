using System;
using CloudCore.VirtualWorker.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.VirtualWorker.Tests.Exceptions
{
    [TestClass]
    public class FatalExceptionTests
    {
        [TestMethod]
        public void FatalException_CanInstantiateDefault()
        {
            var ex = new FatalException();
            Assert.IsNotNull(ex);
            Assert.IsInstanceOfType(ex, typeof(Exception));
        }

        [TestMethod]
        public void FatalException_CanInstantiateWithInnerException()
        {
            var ex = new FatalException("hallo", new Exception("test"));
        }

        [TestMethod]
        public void FatalException_CanInstantiateWithMessage()
        {
            var ex = new FatalException("bye");
        }
    }
}
