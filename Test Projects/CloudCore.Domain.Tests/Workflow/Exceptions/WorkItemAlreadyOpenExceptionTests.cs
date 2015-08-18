using System;
using CloudCore.Domain.Workflow.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Domain.Tests.Workflow.Exceptions
{
    [TestClass]
    public class WorkItemAlreadyOpenExceptionTests
    {
        [TestMethod]
        public void WorkItemAlreadyOpenException_CanInstantiateDefault()
        {
            var ex = new WorkItemAlreadyOpenException();
            Assert.IsNotNull(ex);
            Assert.IsInstanceOfType(ex, typeof(Exception));
        }

        [TestMethod]
        public void WorkItemAlreadyOpenException_CanInstantiateWithInnerException()
        {
            var ex = new WorkItemAlreadyOpenException("hallo", new Exception("test"));
        }

        [TestMethod]
        public void WorkItemAlreadyOpenException_CanInstantiateWithMessage()
        {
            var ex = new WorkItemAlreadyOpenException("bye");
        }
    }
}
