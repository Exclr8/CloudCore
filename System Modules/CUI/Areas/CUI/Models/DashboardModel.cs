using System;
using System.Collections.Generic;
using System.Linq;
using CloudCore.Core.Dashboard;
using CloudCore.Domain;
using CloudCore.Web.Areas.CUI.Helpers;

using System.Web.Mvc;

namespace CloudCore.Web.Areas.CUI.Models
{
    public class DashboardModel
    {
        private readonly int userId;



        public List<DashboardTile> Tiles { get; set; }

        public DashboardModel(int userId )
        {
            this.userId = userId;
            Tiles = new List<DashboardTile>();
        }

        public void LoadUserDashboardTiles(UrlHelper urlHelper)
        {
            var dashboardTasks = new DashboardHelper();

            var assignedUserDashboards = dashboardTasks.GetUserAssignedDashboards(userId);
            var userDashboardData = dashboardTasks.UserDashboardDataList(userId);

            foreach (var assignedUserDashboard in assignedUserDashboards)
            {
                var assignedDashboard = assignedUserDashboard;
                KpiTableEntity dashboardData;

                if (dashboardTasks.IsUserDashboardDataPopulated(userDashboardData, assignedDashboard.DashboardGuid, out dashboardData))
                {
                    var url = String.Empty;
                    if (!String.IsNullOrWhiteSpace(dashboardData.ActionName) || 
                        !String.IsNullOrWhiteSpace(dashboardData.ControllerName))
                    {
                        url = String.IsNullOrWhiteSpace(dashboardData.AreaName)
                            ? urlHelper.Action(dashboardData.ActionName, dashboardData.ControllerName)
                            : urlHelper.Action(dashboardData.ActionName, dashboardData.ControllerName, new { Area = dashboardData.AreaName });
                    }

                    Tiles.Add(new DashboardTile
                    {
                        TilePosition = dashboardData.TilePosition,
                        TileContext = dashboardData.Image,
                        HasImageData = true,
                        Url = url
                    });
                }
                else
                {
                    Tiles.Add(new DashboardTile
                    {
                        TilePosition = assignedDashboard.TilePosition
                    });

                    dashboardTasks.UpdateDashboard(assignedDashboard.DashboardGuid);
                }
            }
        }

        public DashboardTile GetTileByPosition(int tilePosition)
        {
            var dashboardTile = Tiles.Count == 0 
                ? null 
                : Tiles.FirstOrDefault(tile => tile.TilePosition == tilePosition);
            return dashboardTile;
        }
    }

    public class DashboardTile
    {
        public int TilePosition { get; set; }

        public bool HasImageData { get; set; }

        public Byte[] TileContext { get; set; }

        public bool HasUrl { get { return !String.IsNullOrWhiteSpace(Url); } }

        public string Url { get; set; }
    }
}