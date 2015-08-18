using System;
using System.Collections.Generic;

using CloudCore.Data;
using System.Linq;

namespace CloudCore.Domain.Workflow
{
    [Serializable]
    public class TaskItem : ITaskItem
    {
        
        public long InstanceId { get; set; }
        public string Header { get; set; }
        public string SubHeader { get; set; }
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public Int64 KeyValue { get; set; }
        public string ActivationSchedule { get; set; }
        public int Priority { get; set; }
        public int StatusId { get; set; }
        public Guid SubProcessGuid { get; set; }
        public Guid ActivityGuid { get; set; }
        public int UserId { get; set; }
        public int ApplicationId { get; set; }
        public bool? Delayed { get; set; }
        public int StatusTypeId { get; set; }
        public bool DocWait { get; set; }
        public int ProcessModelId { get; set; }
        public int SubProcessId { get; set; }
        public string SubProcessName { get; set; }
        public int OpenedBy { get; set; }

        public List<WorklistReference> WorklistReferences { get; set; }

        public void SetWorkListReferences()
        {
            WorklistReferences = new List<WorklistReference>();
            WorklistReferences.AddRange(CloudCoreDB.Context.Cloudcore_WorklistReference.Where(w => w.InstanceId == this.InstanceId)
                .Select(r => new WorklistReference {
                    ReferenceTypeId = r.ReferenceTypeId,
                    Reference = r.Reference,
                    InstanceId = r.InstanceId
            
            }));
        }
    }
}