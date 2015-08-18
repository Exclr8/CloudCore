using System.ComponentModel.DataAnnotations;
using CloudCore.Domain;
using CloudCore.Web.Core.BaseModels;

using System.Data.Linq.SqlClient;
using System.Linq;
using CloudCore.Data;

namespace CloudCore.Admin.Models
{
    public class AccessPoolUserSearch : BaseSearchModel<AccessPoolMember>
    {
        public int AccessPoolId { get; set; }
        public int UserId { get; set; }

        [Display(Name = "Name")]
        public string Fullname { get; set; }
        public string FullnameFilter { get; set; }
        public string Login { get; set; }
        public string LoginFilter { get; set; }
        public string Email { get; set; }
        public string EmailFilter { get; set; }

        public override void Search()
        {
            CloudCoreDB database = CloudCoreDB.Context;

            var results = (from u in database.Cloudcore_User
                           where u.UserId > 0 &&
                           !database.Cloudcore_VwAccessPool.Where(r => r.AccessPoolId == AccessPoolId).Select(su => new { su.UserId }).Contains(new { u.UserId })
                           select new AccessPoolMember
                           {
                               Fullname = u.Fullname,
                               UserId = u.UserId,
                               Email = u.Email,
                               AccessPoolId = this.AccessPoolId,
                               Login = u.Login
                           });

            if (!string.IsNullOrEmpty(Email))
            {
                results = results.Where(r => SqlMethods.Like(r.Email, string.Format(EmailFilter, Email)));
            }
            if (!string.IsNullOrEmpty(Fullname))
            {
                results = results.Where(r => SqlMethods.Like(r.Fullname, string.Format(FullnameFilter, Fullname.ToString().Trim())));
            }
            SearchResults = results;
        }
    }
}