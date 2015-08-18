using System.Collections.Generic;
using CloudCore.Core.Data.Dashboard;

using CloudCore.Data;
using System.Data.Linq;
using System.Linq;
using CloudCore.Web.Core.Security.Authentication;



namespace CloudCore.Web.Models
{

    public class AvailableUsersDashboardItemsModel
    {
        public int TilePosition { get; set; }
        public int DashboardId { get; set; }
        public List<UserAvailableDashboardItem> UserAvailableDashboardItems { get; set; }

        public AvailableUsersDashboardItemsModel()
        {
            UserAvailableDashboardItems = new List<UserAvailableDashboardItem>();
        }

        public void PopulateUserAvailableDashboardItems( int userId)
        {
            UserAvailableDashboardItems.AddRange(
                CloudCoreDB.Context.Cloudcore_DashboardsAvailableToUser(userId).Select(r => new UserAvailableDashboardItem
                {
                    Description = r.Description,
                    Id = r.DashboardId.Value,
                    Title = r.Title
                })
            );
        }

        public void DashboardAddToCurrentUser()
        {
            CloudCoreDB.Context.Cloudcore_DashboardAddToUser(this.DashboardId, CloudCoreIdentity.UserId, this.TilePosition);
        }
    }
}