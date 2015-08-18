using System;


namespace CloudCore.Domain.Workflow
{
    [Serializable]
    public class Process
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public ProcessRevision Revision { get; set; }

    }
}
