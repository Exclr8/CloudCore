using System;

namespace CloudCore.Domain
{
    [Serializable]
    public class UserDashboardItem : DashboardItem
    {
        public long Id { get; set;  }
        public int UserId { get; set; }
        public string NFullName { get; set; }
        public int TilePosition { get; set; }
    }
}
