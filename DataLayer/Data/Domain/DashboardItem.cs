using System;


namespace CloudCore.Domain
{
    [Serializable]
    public class DashboardItem
    {
        public string AssemblyName { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public Guid DashboardGuid { get; set; }
        public int IntervalInMinutes { get; set; }
    }
}
