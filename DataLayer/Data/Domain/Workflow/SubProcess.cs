using System;


namespace CloudCore.Domain.Workflow
{
    [Serializable]
    public class SubProcess
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public Process Process { get; set; }
    }

}
