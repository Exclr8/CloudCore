using System;
using System.Runtime.Serialization;

namespace CloudCore.VirtualWorker.Exceptions
{
    [Serializable]
    public sealed class UnknownWorkerTaskTypeException : ApplicationException, ISerializable
    {
        public UnknownWorkerTaskTypeException() { }

        public UnknownWorkerTaskTypeException(string message) : base(message) { }

        public UnknownWorkerTaskTypeException(string message, Exception innerException) : base(message, innerException) { }
    }
}