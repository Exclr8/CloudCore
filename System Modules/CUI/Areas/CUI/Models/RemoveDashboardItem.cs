using CloudCore.Core.Dashboard;
using CloudCore.Data;

using System.Linq;

namespace CloudCore.Web.Areas.CUI.Models
{
    public class RemoveDashboardItem
    {
        public int UserId { get; set; }
        public int TilePosition { get; set; }

        public void DeleteUserDashboardAllocation()
        {
            CloudCoreDB.Context.Cloudcore_DashboardUserAllocationDelete(UserId, TilePosition);
            var storageTable = new KpiScheduledTaskStorageTable();
            var tableQuery = storageTable.Table.CreateQuery<KpiTableEntity>();

            var kpiItems = tableQuery.Where(i => i.UserId == UserId && i.TilePosition == TilePosition).ToList();

            kpiItems.ForEach(storageTable.Delete);
        }
    }
}