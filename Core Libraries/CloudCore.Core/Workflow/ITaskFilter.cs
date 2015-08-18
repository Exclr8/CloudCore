namespace CloudCore.Domain.Workflow
{
    public interface ITaskFilter
    {
        bool? DocWait { get; set; }
        int? ProcessModelId { get; set; }
        int? SubProcessId { get; set; }
        int? ActivityId { get; set; }
        int? AccessPoolId { get; set; }
        int? StatusId { get; set; }
        bool? Delayed { get; set; }
    }
}
