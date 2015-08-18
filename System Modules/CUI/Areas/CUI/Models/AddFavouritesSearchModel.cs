using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CloudCore.Domain;
using CloudCore.Web.Core.BaseModels;
using CloudCore.Web.Core.Menu;
using CloudCore.Web.Core.Security.Authentication;

using CloudCore.Data;

namespace CloudCore.Web.Models
{

    public class FavouriteActionModel
    {
        public Guid Reference { get; set; }
        public string Title { get; set; }

    }

    public class AddFavouritesSearchModel : BaseSearchModel<FavouriteActionModel>
    {
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        public override void Search()
        {

            var db = new CloudCoreDB();
            var currentfavourites = CloudCoreDB.Context.Cloudcore_Favourite.Where(r => r.UserId == CloudCoreIdentity.UserId && r.FavouriteTypeId == 0).Select(r => r.FavouriteGuid).ToList();
            var permittedoptions = MenuStructure.GetPermittedMenuStructure().Where(r => !r.Action.IsFolder).Select(m => new FavouriteActionModel { Reference = m.Action.ActionGuid, Title = m.Action.ActionTitle }).ToList();
            permittedoptions.RemoveAll(r => currentfavourites.Contains(r.Reference));
            //       && !currentfavourites.Select(k => k.FavouriteReference).Contains(r.Action.ActionGuid)).;
            SearchResults = permittedoptions.Where(f => f.Title.Contains(this.Title??"")).ToList<FavouriteActionModel>();

        }
    }
}