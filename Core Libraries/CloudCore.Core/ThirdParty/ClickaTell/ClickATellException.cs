using System;
using System.Runtime.Serialization;

namespace Frameworkone.ThirdParty.Clickatell
{
    [Serializable]
    public class ClickatellException : ApplicationException, ISerializable
    {
        public ClickatellException() { }
        public ClickatellException(string message) : base(message) { }
        public ClickatellException(string message, Exception inner) : base(message, inner) { }
    }
}
