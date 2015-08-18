using System;
using CloudCore.VirtualWorker.WorkflowActivities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.VirtualWorker.Tests.Exceptions
{
    [TestClass]
    public class ActivityExceptionTests
    {
        [TestMethod]
        public void ActivityException_CanInstantiateDefault()
        {
            var ex = new ActivityException();
            Assert.IsNotNull(ex);
            Assert.IsInstanceOfType(ex, typeof(Exception));
        }

        [TestMethod]
        public void ActivityException_CanInstantiateWithInnerException()
        {
            var ex = new ActivityException("hallo", new Exception("test"));
        }

        [TestMethod]
        public void ActivityException_CanInstantiateWithMessage()
        {
            var ex = new ActivityException("bye");
        }
    }
}
