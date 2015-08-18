using System;
using System.Collections.Generic;
using System.Linq;
using CloudCore.Domain;
using CloudCore.Web.Core.Security.Authentication;
using CloudCore.Web.Core.Security.Authorization;

using Environment = CloudCore.Core.Modules.Environment;
using CloudCore.Data;

namespace CloudCore.Web.Core.Caching
{

    [Serializable]
    public class UserProfile : LiteralCache<UserProfile>
    {
        private readonly List<Favourite> menuFavourites;
        private readonly List<Favourite> dashboardFavourites;

        public UserProfile()
        {
            menuFavourites = new List<Favourite>();
            dashboardFavourites = new List<Favourite>();
        }


        public List<Favourite> MenuFavourites { get { return menuFavourites; } }
        public List<Favourite> DashboardFavourites { get { return dashboardFavourites; } }
        public string FullName { get { return CloudCoreIdentity.Fullname; } }


        protected override void Update()
        {
            dashboardFavourites.Clear();

            var userDashboardFavourites = UserFavouritesByType( FavouriteType.Dashboard);
            dashboardFavourites.AddRange(userDashboardFavourites);

            RenewMenuFavourites();
            base.Update();
        }

        private IEnumerable<Favourite> UserFavouritesByType( Domain.FavouriteType type)
        {

            return CloudCoreDB.Context.Cloudcore_Favourite.Where(
                    r => r.FavouriteTypeId == (int)type && r.UserId == CloudCoreIdentity.UserId).Take(7).Select(f => new Favourite
            {
                Id = new FavouriteId
                {
                    UserId = f.UserId,
                    Reference = f.FavouriteGuid,
                },
                Type = (FavouriteType)f.FavouriteTypeId
            });

        }

        private void RenewMenuFavourites()
        {
            menuFavourites.Clear();
            var userPermissions = new UserPermission();
            {
                var userMenuFavourites = UserFavouritesByType( FavouriteType.Menu).ToList();
                userMenuFavourites.ForEach(favourite =>
                {
                    bool handled = false;
                    var action = Environment.LoadedModuleActions.Actions.Where(r => r.Value.ActionGuid == favourite.Id.Reference).Select(t => t.Value).SingleOrDefault();
                    if (action != null)
                    {
                        if (userPermissions.IsAccessGranted(favourite.Id.Reference))
                        {
                            handled = true;
                            favourite.ActionId = action.ListIndex;
                            menuFavourites.Add(favourite);
                        }
                    }
                    if (!handled) { RemoveFavourite( favourite.Id.Reference, 0); }
                });
            }
        }

        public static void AddFavourite( Guid reference, FavouriteType favouriteType)
        {
            CloudCoreDB.Context.Cloudcore_FavouriteAdd(CloudCoreIdentity.UserId, reference, (short)favouriteType);

            ForceRefresh();
        }

        public static void RemoveFavourite( Guid reference, FavouriteType favouriteType)
        {
            CloudCoreDB.Context.Cloudcore_FavouriteRemove(CloudCoreIdentity.UserId, reference, Convert.ToInt32(favouriteType));
            ForceRefresh();
        }

        public int UserId
        {
            get
            {
                return CloudCoreIdentity.UserId;
            }

        }

        public int CampaignId
        {
            get
            {
                return 0;
                //var db = CloudCoreDB.Context;
                //var campaign = (from uc in db.Cloudcore_CampaignUser
                //                       where uc.UserId == CloudCoreIdentity.UserId 
                //                            && uc.Active
                //                       select new 
                //                       {
                //                           uc.CampaignID
                //                       }).SingleOrDefault();

                //return campaign != null ? campaign.CampaignID : -1; 
            }
            set
            {
                //CloudCoreDB.Context.Cloudcore_UserCampaignSelect(CloudCoreIdentity.UserId, value);
                //ForceRefresh();
            }
        }

    }
}
