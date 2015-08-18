using System;


namespace CloudCore.Domain.Workflow
{
    [Serializable]
    public class ProcessRevision
    {        
        public int VersionNumber { get; set; }
        public string ManagerName { get; set; }
        public DateTime LastChanged { get; set; }
    }
}
