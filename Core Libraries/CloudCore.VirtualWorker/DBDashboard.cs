using System;
using System.IO;
using System.Linq;
using System.Reflection;
using CloudCore.Core.Modules;
using CloudCore.Domain;

using CloudCore.VirtualWorker.DashboardKpi;
using CloudCore.Data;

namespace CloudCore.VirtualWorker
{
    public class DBDashboard
    {
        private readonly IDashboard _dashboard;
        private readonly Assembly _assembly;
        public DBDashboard(Type dashboard, Assembly assembly)
        {
            _dashboard = Activator.CreateInstance(dashboard) as IDashboard;
            _assembly = assembly;
        }

        public void Deploy()
        {
      

            if (!CloudCoreDB.Context.Cloudcore_Dashboard.Where(x => x.DashboardGuid == _dashboard.UniqueId).Any())
            {
                int? dashboardId = null;
                var db = CloudCoreDB.Context;
                var systemModuleId = db.Cloudcore_SystemModule.Single(x => x.AssemblyName == _assembly.FullName).SystemModuleId;

                db.Cloudcore_DashboardCreate(ref dashboardId, systemModuleId, _dashboard.Title, _dashboard.Description, _dashboard.IntervalInMinutes, _dashboard.UniqueId);

                if (!dashboardId.HasValue)
                {
                    throw new Exception("Could not create the new Dashboard Item. The system did not assign a new ID.");
                }
            }
            else
            {
                
                var dbDashboard = CloudCoreDB.Context.Cloudcore_Dashboard.Where(x => x.DashboardGuid == _dashboard.UniqueId).First();

                CloudCoreDB.Context.Cloudcore_DashboardModify(dbDashboard.DashboardId, _dashboard.Title, _dashboard.Description);
            }
        }
    }
}