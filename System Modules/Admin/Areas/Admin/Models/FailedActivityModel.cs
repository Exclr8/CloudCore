using System;

namespace CloudCore.Admin.Models
{
    public class FailedActivityModel
    {
        public long ActivityId { get; set; }
        public Guid ActivityGuid { get; set; }
        public string ActivityType { get; set; }
        public string ActivityName { get; set; }
        public int TotalFailures { get; set; }
        public long ProcessModelId { get; set; }
        public Guid ProcessGuid { get; set; }
        public string ProcessName { get; set; }
        public long SubProcessId { get; set; }
        public Guid SubProcessGuid { get; set; }
        public string SubProcessName { get; set; }
    }
}