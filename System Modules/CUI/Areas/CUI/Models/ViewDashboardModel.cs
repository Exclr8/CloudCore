using System;

namespace CloudCore.Web.Models
{
    public class ViewDashboardModel
    {
        public bool TileContextDefined { get; set; }

        public int UserId { get; set; }
        
        public int TilePosition { get; set; }

        public string TileContext { get; set; }
    }
}