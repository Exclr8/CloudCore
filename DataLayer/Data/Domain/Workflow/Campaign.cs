using System;


namespace CloudCore.Domain.Workflow
{
    public class Campaign
    {
        public long InstanceId { get; set; }
        public DateTime Activate { get; set; }
        public long KeyValue { get; set; }
        public string Header { get; set; }
        public string SubHeader { get; set; }
        public string ActivityName { get; set; }
        public int Priority { get; set; }
    }
}
