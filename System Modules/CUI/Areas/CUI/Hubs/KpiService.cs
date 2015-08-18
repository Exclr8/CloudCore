using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using CloudCore.Core.Dashboard;
using CloudCore.Logging;
using CloudCore.Logging.AzureTableStorage;
using CloudCore.Web.Core.Security.Authentication;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.WindowsAzure.Storage.Table;
using WebGrease.Css.Extensions;

namespace CloudCore.Web.Areas.CUI.Hubs
{
    [HubName("kpiDashboardService")]
    public class KpiService : Hub
    {
        private readonly KpiDashboardService<KpiService> instance;

        public KpiService()
            : this(KpiDashboardService<KpiService>.Instance)
        {

        }

        public KpiService(KpiDashboardService<KpiService> dashboardService)
        {
            instance = dashboardService;
        }

        public void RegisterConnection(string connectionId)
        {
            var userId = CloudCoreIdentity.UserId;
            instance.RegisterUserConnection(userId, connectionId);
        }
    }
}

