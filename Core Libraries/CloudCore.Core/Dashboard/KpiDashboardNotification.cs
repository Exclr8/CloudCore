using System;
using System.Linq;
using System.Collections.Generic;
using CloudCore.Data;

namespace CloudCore.Core.Dashboard
{
    public class KpiDashboardNotification
    {
        // ReSharper disable once InconsistentNaming
        private readonly static Lazy<KpiDashboardNotification> _instance = new Lazy<KpiDashboardNotification>(
            () => new KpiDashboardNotification());

        private List<INotifyService> services;

        private KpiDashboardNotification()
        {
            services = new List<INotifyService>();
        }

        private void NotifyOfChanges(List<KpiTableEntity> values)
        {
            services.ForEach(service => service.NotifyChanged(values));
        }

        public void RegisterNotificationService(INotifyService service)
        {
            if (!services.Contains(service))
                services.Add(service);
        }

        public static KpiDashboardNotification Instance
        {
            get { return _instance.Value; }
        }

        public static void UpdateDashboard(string dashboardGuid )
        {
            var storageTable = new KpiScheduledTaskStorageTable();

            var tableQuery = storageTable.Table.CreateQuery<KpiTableEntity>();

            var guid = Guid.Parse(dashboardGuid);

            var kpiItems = tableQuery.Where(i => i.DashboardGuid == guid).ToList();

            kpiItems.ForEach(i =>
            {
                if (!CloudCoreDB.Context.Cloudcore_VwUserDashboard.Select(udi => udi.DashboardGuid == i.DashboardGuid && udi.UserId == i.UserId).Any())
                {
                    storageTable.Delete(i);
                    kpiItems.Remove(i);
                }
            });

            Instance.NotifyOfChanges(kpiItems);
        }
    }
}
