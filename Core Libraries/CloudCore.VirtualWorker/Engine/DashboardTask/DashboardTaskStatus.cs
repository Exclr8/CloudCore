namespace CloudCore.VirtualWorker.Engine.DashboardTask
{
    public enum DashboardTaskStatus
    {
        Pending = 0,
        Running = 1,
        Retry = 42,
        Disabled = 100,
        Failed = 101
    }
}
