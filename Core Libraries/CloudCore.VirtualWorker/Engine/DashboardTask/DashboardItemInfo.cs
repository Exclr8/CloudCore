using System;

namespace CloudCore.VirtualWorker.Engine.DashboardTask
{
    public class DashboardItemInfo
    {
        public int DashboardId { get; set; }

        public Guid DashboardGuid { get; set; }

        public int SystemModuleId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string HighChartOptions { get; set; }
    }
}
