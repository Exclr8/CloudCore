using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudCore.Core;
using CloudCore.Core.Dashboard;
using CloudCore.Domain;

using CloudCore.Data;

namespace CloudCore.Web.Areas.CUI.Helpers
{
    public class DashboardHelper
    {


        public List<UserDashboardItem> GetUserAssignedDashboards(int userId)
        {
            return (from d in CloudCoreDB.Context.Cloudcore_VwUserDashboard
                   where d.UserId == userId
                   select new CloudCore.Domain.UserDashboardItem
                   {
                       UserId = d.UserId,
                       AssemblyName = d.AssemblyName,
                       Id = d.DashboardId,
                       Description = d.Description,
                       TilePosition = d.TilePosition,
                       Title = d.Title,
                       DashboardGuid = d.DashboardGuid,
                       NFullName = d.NFullname
                   }).ToList();
        }

        public List<KpiTableEntity> UserDashboardDataList(int userId)
        {
            var storageTable = new KpiScheduledTaskStorageTable();
            var tableQuery = storageTable.Table.CreateQuery<KpiTableEntity>();

            return tableQuery.Where(i => i.UserId == userId).ToList();
        }

        public KpiTableEntity GetUserDashboardTileData(int userId, int tilePosition)
        {
            var storageTable = new KpiScheduledTaskStorageTable();
            var tableQuery = storageTable.Table.CreateQuery<KpiTableEntity>();

            return tableQuery.Where(i => i.UserId == userId && i.TilePosition == tilePosition).SingleOrDefault();
        }

        public bool IsUserDashboardDataPopulated(List<KpiTableEntity> userDashboardData, Guid dashboardGuid, out KpiTableEntity dashboardData)
        {
            dashboardData = userDashboardData.FirstOrDefault(item => item.DashboardGuid == dashboardGuid);
            return dashboardData != null;
        }

        public void UpdateDashboard(Guid dashboardGuid)
        {
            CloudCoreDB.Context.Cloudcore_StartDashboard(dashboardGuid);
        }
    }
}