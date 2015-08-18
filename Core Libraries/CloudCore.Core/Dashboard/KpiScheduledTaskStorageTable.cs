using System.Collections.Generic;
using System.Linq;
using CloudCore.Logging.AzureTableStorage;

namespace CloudCore.Core.Dashboard
{
    public class KpiScheduledTaskStorageTable : CloudCoreStoredTable<KpiTableEntity>
    {
        public void UpdateBatch(List<KpiTableEntity> kpiTableEntities)
        {
            var instance = new KpiScheduledTaskStorageTable();

            var tableQuery = instance.Table.CreateQuery<KpiTableEntity>();

            foreach (var kpiTableEntity in kpiTableEntities)
            {
                var kpiItems = tableQuery.Where(x => x.TilePosition == kpiTableEntity.TilePosition && x.UserId == kpiTableEntity.UserId).ToList();
                kpiItems.ForEach(instance.Delete);
            }

            instance.InsertBatch(kpiTableEntities);
        }
    }
}
