using System;
using System.Runtime.Serialization;

namespace CloudCore.VirtualWorker.Exceptions
{
    [Serializable]
    public class FatalException : ApplicationException, ISerializable
    {
        public FatalException() { }

        public FatalException(string message) : base(message) { }

        public FatalException(string message, Exception innerException) : base(message, innerException) { }
    }
}
