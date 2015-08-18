using System;
using System.Collections.Generic;
using System.Linq;
using CloudCore.Domain;
using CloudCore.Web.Core.Caching;
using CloudCore.Web.Core.Menu;
using CloudCore.Web.Core.Security.Authentication;

using CloudCore.Data;

namespace CloudCore.Web.Models
{
    public class ViewFavouriteActionsModel
    {
        public IEnumerable<FavouriteActionModel> Favourites { get; set; }
        public void GetFavourites()
        {
            var currentfavourites = CloudCoreDB.Context.Cloudcore_Favourite.Where(r => r.UserId == CloudCoreIdentity.UserId && r.FavouriteTypeId == 0).Select(r => r.FavouriteGuid).ToList();
            var permittedoptions = MenuStructure.GetPermittedMenuStructure().Where(r => !r.Action.IsFolder).Select(m => new FavouriteActionModel { Reference = m.Action.ActionGuid, Title = m.Action.ActionTitle }).ToList();

            Favourites = permittedoptions.Where(r => currentfavourites.Contains(r.Reference));
        }

        public void RemoveFavourite( Guid reference)
        {
            UserProfile.RemoveFavourite( reference, 0);
        }
    }
}