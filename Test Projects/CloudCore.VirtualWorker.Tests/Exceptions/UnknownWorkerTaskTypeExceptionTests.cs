using System;
using CloudCore.VirtualWorker.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.VirtualWorker.Tests.Exceptions
{
    [TestClass]
    public class UnknownWorkerTaskTypeExceptionTests
    {
        [TestMethod]
        public void UnknownWorkerTaskTypeException_CanInstantiateDefault()
        {
            var ex = new UnknownWorkerTaskTypeException();
            Assert.IsNotNull(ex);
            Assert.IsInstanceOfType(ex, typeof(Exception));
        }

        [TestMethod]
        public void UnknownWorkerTaskTypeException_CanInstantiateWithInnerException()
        {
            var ex = new UnknownWorkerTaskTypeException("hallo", new Exception("test"));
        }

        [TestMethod]
        public void UnknownWorkerTaskTypeException_CanInstantiateWithMessage()
        {
            var ex = new UnknownWorkerTaskTypeException("bye");
        }
    }
}
