namespace CloudCore.VirtualWorker.Engine.ScheduledTask
{
    public enum ScheduledTaskStatusId
    {
        Pending = 0,
        Running = 1,
        Retry = 42,
        Disabled = 100,
        Failed = 101
    }
}
