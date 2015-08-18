

namespace CloudCore.Domain.Specifications.Workflow
{
    public class TaskListSpec
    {
        public int UserId { get; set; }
        public int ApplicationId { get; set; }
        public int? ReferenceTypeId { get; set; }
        public string ReferenceValue { get; set; }
        public bool? Delayed { get; set; }
        public int? StatusTypeId { get; set; }
        public int? OpenedBy { get; set; }

        public TaskListSpec(int userId, int applicationId, int? referenceTypeId = null, string referenceValue = null, bool? delayed = null, int? statusTypeId = null, int? openedBy = null)
        {
            UserId = userId;
            ApplicationId = applicationId;
            ReferenceTypeId = referenceTypeId;
            ReferenceValue = referenceValue;
            Delayed = delayed;
            StatusTypeId = statusTypeId;
            OpenedBy = openedBy;
        }
    }
}
