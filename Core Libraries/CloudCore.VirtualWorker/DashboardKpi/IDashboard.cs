using System;

namespace CloudCore.VirtualWorker.DashboardKpi
{
    public interface IDashboard
    {
        Guid UniqueId { get; }
        string Title { get; }
        string Description { get; }
        string Name { get; }
        int IntervalInMinutes { get; }
        string DashboardData(long userId);
    }
}