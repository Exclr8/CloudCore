using System;
using System.Runtime.Serialization;

namespace CloudCore.Api
{
    [Serializable]
    public class ApiException : ApplicationException, ISerializable
    {
        public ApiException() { }

        public ApiException(string message) : base(message) { }

        public ApiException(string message, Exception innerException) : base(message, innerException) { }
    }
}
