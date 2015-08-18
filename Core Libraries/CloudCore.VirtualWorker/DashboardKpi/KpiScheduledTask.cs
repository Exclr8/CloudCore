using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using CloudCore.Core;
using CloudCore.Core.Dashboard;
using CloudCore.Domain;

using Microsoft.WindowsAzure.ServiceRuntime;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using CloudCore.VirtualWorker.ScheduledTasks;
using CloudCore.Data;

namespace CloudCore.VirtualWorker.DashboardKpi
{
    public abstract class KpiScheduledTask : IScheduledTask, IDashboard        
    {
       

        protected KpiScheduledTask()
        {
    
        }

        public virtual string AreaName { get; set; }

        public virtual string ControllerActionName { get; set; }

        public virtual string ControllerName { get; set; }

        public abstract Guid UniqueId { get; }

        public abstract string Title { get; }

        public abstract string Name { get; }

        public abstract int IntervalInMinutes { get; }

        public abstract string Description { get; }

        public abstract string DashboardData(long userId);
        
        public void Execute()
        {
            var result = GetKpiUsers().Select(kpiUser =>
            {
                return new KpiTableEntity
                {
                    UserId = kpiUser.UserId,
                    DashboardGuid = UniqueId,
                    TilePosition = kpiUser.TilePosition,
                    ETag = "",
                    PartitionKey = "KpiTableData",
                    Timestamp = DateTime.Now,
                    ControllerName = ControllerName,
                    ActionName = ControllerActionName,
                    AreaName = this.AreaName,
                    RowKey = Guid.NewGuid().ToString()
                };
            }).ToList();

            if (result.Any())
            {
                OnPreSave(result);

                SaveToTableStorage(result);

                OnPostSave(result);
            }
        }

        protected virtual void OnPreSave(IEnumerable<KpiTableEntity> kpiBatchData)
        {
        }

        protected virtual void OnPostSave(IEnumerable<KpiTableEntity> kpiBatchData)
        {
            NotifyWebInstanceRole(kpiBatchData.First().DashboardGuid);
        }

        private IEnumerable<KpiUser> GetKpiUsers()
        {
            return CloudCoreDB.Context.Cloudcore_VwUserDashboard.Where(udi => udi.DashboardGuid == UniqueId)
                .Select(udi => new KpiUser
                {
                    UserId = udi.UserId,
                    TilePosition = udi.TilePosition
                });
        }

        private void NotifyWebInstanceRole(Guid dashboardGuid)
        {
            try
            {
                var webRoleEndPoint = GetWebInstanceRoleEndpoint(); 

                var postUrl = string.Format("{0}://{1}/Core/Asset/UpdateUserDashboard?dashboardGuid={2}",
                    webRoleEndPoint.Protocol, webRoleEndPoint.IPEndpoint, dashboardGuid);

                var request = WebRequest.CreateHttp(postUrl);
                request.Method = "http";
                request.Method = "POST";
                request.ContentLength = 0;
                var response = request.GetResponse();

                response.Close();
            }
            catch (Exception ex)
            {
                ex.Data.Add(Guid.NewGuid().ToString(), "Failed trying to post to site instance.");
                throw;
            }
        }

        private void SaveToTableStorage(IEnumerable<KpiTableEntity> kpiBatchData)
        {
            try
            {
                var storageTable = new KpiScheduledTaskStorageTable();
                var list = kpiBatchData.ToList();
                storageTable.UpdateBatch(list);
            }
            catch (Exception ex)
            {
                ex.Data.Add(Guid.NewGuid().ToString(), "Failed trying to save to table storage.");
                throw;
            }
        }

        private RoleInstanceEndpoint GetWebInstanceRoleEndpoint()
        {
            RoleInstanceEndpoint endpoint = null;

            foreach (var roleKey in RoleEnvironment.Roles.Keys)
            {
                foreach (var instance in RoleEnvironment.Roles[roleKey].Instances)
                {
                    if (instance.InstanceEndpoints.ContainsKey("HttpDashboardInternal"))
                    {
                        endpoint = instance.InstanceEndpoints["HttpDashboardInternal"];
                        break;
                    }
                }
            }

            return endpoint;
        }
    }
}
