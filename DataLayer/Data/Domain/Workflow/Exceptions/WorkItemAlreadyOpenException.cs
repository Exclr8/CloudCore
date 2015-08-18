using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CloudCore.Domain.Workflow.Exceptions
{
    [Serializable]
    public sealed class WorkItemAlreadyOpenException : ApplicationException, ISerializable
    {
        public WorkItemAlreadyOpenException() { }

        public WorkItemAlreadyOpenException(string message) : base(message) { }

        public WorkItemAlreadyOpenException(string message, Exception innerException) : base(message, innerException) { }
    }
}
