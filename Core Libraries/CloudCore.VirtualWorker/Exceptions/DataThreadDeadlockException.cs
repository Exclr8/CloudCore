using System;

namespace CloudCore.VirtualWorker.Exceptions
{
    public class DataThreadDeadlockException : FatalException
    {
        public DataThreadDeadlockException(string message, Exception innerException = null) : base(message, innerException) { }
    }
}