using System.Collections.Generic;

using CloudCore.Domain.Workflow;


namespace CloudCore.Domain.Workflow
{
    public interface ITaskListQuery
    {
        string Title { get; }
        string Description { get; }

        IEnumerable<TaskItem> Execute(int userId, int referenceTypeId, string referenceValue, int applicationid);
    }
}