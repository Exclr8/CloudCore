using System;
using System.Collections.Generic;
using System.Globalization;
using CloudCore.Configuration.ConfigFile;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;

namespace CloudCore.Core.Dashboard
{
    public class KpiDashboardService<THub> : INotifyService where THub : Hub
    {
        // ReSharper disable once InconsistentNaming
        private readonly static Lazy<KpiDashboardService<THub>> _instance = new Lazy<KpiDashboardService<THub>>(
            () => new KpiDashboardService<THub>(GlobalHost.ConnectionManager.GetHubContext<THub>().Clients));

        private IHubConnectionContext<dynamic> Clients { get; set; }

        public static KpiDashboardService<THub> Instance
        {
            get { return _instance.Value; }
        }

        public KpiDashboardService(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
            KpiDashboardNotification.Instance.RegisterNotificationService(this);
        }

        public void RegisterUserConnection(int userId, string connectionId)
        {
            UserDictionaryStorageTable.Update(new UserConnectionTableEntity
            {
                UserId = userId,
                ConnectionId = connectionId,
                PartitionKey = "UserConnectionTableData",
                Timestamp = DateTime.Now,
                ETag = "*",
                RowKey = Guid.NewGuid().ToString()
            });
        }

        //Called from service to push changes to browser
        public void UpdateClientKpi(List<KpiTableEntity> kpiData)
        {
            kpiData.ForEach(UpdateClientKpi);
        }

        //Called from service to push changes to browser
        public void UpdateClientKpi(KpiTableEntity kpiData)
        {
            var connectionId = UserDictionaryStorageTable.GetConnectionId(kpiData.UserId);

            if (connectionId != null)
            {
                //kpiData.HighChartsOptions = RecreateJsonOptionsInCorrectFormat(kpiData.HighChartsOptions);
                Clients.Client(connectionId).UpdateKpi(kpiData);
            }
                
        }
        
        public void NotifyChanged(List<KpiTableEntity> values)
        {
            if (ReadConfig.CommonCloudCoreApplicationSettings.ServiceBus.IsServiceBusDefined())
            {
                UpdateClientKpi(values);
            }
        }

        //private string RecreateJsonOptionsInCorrectFormat(string options)
        //{
        //    var obj = JsonConvert.DeserializeObject(options);

        //    return JsonConvert.SerializeObject(obj);
        //}
    }
}
