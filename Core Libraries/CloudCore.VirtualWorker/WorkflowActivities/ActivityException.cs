using System;
using System.Runtime.Serialization;

namespace CloudCore.VirtualWorker.WorkflowActivities
{
    [Serializable]
    public class ActivityException : ApplicationException, ISerializable
    {
        public ActivityException() { }
        public ActivityException(string message) : base(message) { }
        public ActivityException(string message, Exception inner) : base(message, inner) { }
    }
}
