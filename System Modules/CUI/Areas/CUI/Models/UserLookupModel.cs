using System.ComponentModel.DataAnnotations;
using System.Data.Linq.SqlClient;
using System.Linq;
using CloudCore.Data;
using CloudCore.Web.Core.BaseModels;

namespace CloudCore.Web.Models
{

    public class UserLookupResultItem
    {
        public int UserId { get; set; }

        [Display(Name = "Name")]
        public string UserFullName { get; set; }

    }

    public class UserLookupModel : BaseSearchModel<UserLookupResultItem>
    {      
        [Display(Name = "User Name")]
        public string UserFullName { get; set; }
        
        public string UserFullNameOptions { get; set; }

        public override void Search()
        {
            var database = CloudCoreDB.Context;

            var users = (from usr in database.Cloudcore_User
                         where usr.UserId > 0
                         select new UserLookupResultItem
                         {
                             UserId = usr.UserId,
                             UserFullName = usr.Fullname

                         });


            if (!string.IsNullOrEmpty(UserFullName))
            {
                users = users.Where(r => SqlMethods.Like(r.UserFullName, string.Format(UserFullNameOptions, UserFullName)));
            }
            SearchResults = users;
        }
    }
}