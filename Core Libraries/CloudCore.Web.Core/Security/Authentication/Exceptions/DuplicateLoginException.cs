using System;
using System.Runtime.Serialization;

/*
 * See Microsoft's standard for implementing custom exceptions:
 * http://msdn.microsoft.com/en-us/library/ms229064(v=vs.100).aspx
 */
namespace CloudCore.Web.Core.Security.Authentication.Exceptions
{
    [Serializable]
    public sealed class DuplicateLoginException : ApplicationException, ISerializable
    {
        public DuplicateLoginException() : base() { }
        public DuplicateLoginException(string message) : base(message) { }
        public DuplicateLoginException(string message, Exception inner) : base(message, inner) { }
    }
}
