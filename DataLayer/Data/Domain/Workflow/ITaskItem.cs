using System;

namespace CloudCore.Domain.Workflow
{
    public interface ITaskItem
    {
        string Header { get; set; }
        string SubHeader { get; set; }
        string ActivityName { get; set; }
        Int64 KeyValue { get; set; }
        string ActivationSchedule { get; set; }
        int Priority { get; set; }
        int StatusId { get; set; }
    }
}