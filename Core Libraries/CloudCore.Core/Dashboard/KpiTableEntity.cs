using System;
using System.IO;
using Microsoft.WindowsAzure.Storage.Table;

namespace CloudCore.Core.Dashboard
{
    public class KpiTableEntity : TableEntity
    {
        public long UserId { get; set; }

        public Guid DashboardGuid { get; set; }

        public byte[] Image { get; set; }

        public string ResultData { get; set; }

        public int TilePosition { get; set; }

        public string ActionName { get; set; }

        public string ControllerName { get; set; }

        public string AreaName { get; set; }
    }    
}
