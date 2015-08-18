using System;


namespace CloudCore.Domain.Workflow
{
    [Serializable]
    public class WorklistReference
    {
        public long InstanceId { get; set; }
        public string Reference { get; set; }
        public int ReferenceTypeId { get; set; }
    }
}
