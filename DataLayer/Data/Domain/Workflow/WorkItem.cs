using System;

using CloudCore.Domain.Workflow.Exceptions;

using CloudCore.Data;
using System.Linq;
using System.Data.Linq;

namespace CloudCore.Domain.Workflow
{
    [Serializable]
    public class WorkItem
    {
        public long InstanceId { get; set; }
        public Activity CurrentActivity { get; set; }

        public Int64? ParentInstanceId { get; set; }
        
        public WorkItemStatus Status { get; set; }
        
        public int UserId { get; set; }
        
        public string UserName { get; set; }
        
        public int Priority { get; set; }
        
        public Int64 KeyValue { get; set; }
        
        public DateTime ActivationSchedule { get; set; }
        
        public int OpenedBy { get; set; }
    }

}
