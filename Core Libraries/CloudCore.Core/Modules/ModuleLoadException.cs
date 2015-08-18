using System;
using System.Runtime.Serialization;

namespace CloudCore.Core.Modules
{
    [Serializable]
    public sealed class ModuleLoadException : Exception, ISerializable
    {
        public ModuleLoadException() { }

        public ModuleLoadException(string message) : base(message) { }

        public ModuleLoadException(string message, Exception innerException) : base(message, innerException) { }
    }
}
