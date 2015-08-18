using System;
using System.ComponentModel.DataAnnotations;
using CloudCore.Domain;
using CloudCore.Web.Core.BaseModels;
using CloudCore.Web.Core.EditorTemplateAttributes;

using CloudCore.Data;
using System.Linq;
using System.Data.Linq.SqlClient;

namespace CloudCore.Web.Models
{

    public class GlobalLoginHistory
    {
        public DateTime DateTimeLoggedIn { get; set; }
        public string UserFullName { get; set; }
        public string Login { get; set; }
    }

    public class GlobalLoginHistorySearchModel : BaseSearchModel<GlobalLoginHistory>
    {
        public string FilterOptions { get; set; }

        [Display(Name = "User Name")]
        public string UserFullName { get; set; }

        [Display(Name = "Start Date")]
        [MaxDate(0, 0, 0)] 
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [MaxDate(0, 0, 0)] 
        public DateTime EndDate { get; set; }

        public override void Search()
        {
            if (StartDate > EndDate)
            {
                throw new ArgumentException("Start Date cannot be greater than End Date");
            }

            CloudCoreDB database = CloudCore.Data.CloudCoreDB.Context;

            var result = from LoginHistory in database.Cloudcore_LoginHistory
                         join user in database.Cloudcore_User on LoginHistory.UserId equals user.UserId
                         orderby LoginHistory.Connected
                         select new GlobalLoginHistory
                         {
                             DateTimeLoggedIn = LoginHistory.Connected,
                             UserFullName = user.Fullname,
                             Login = user.Login
                         };

            if (!string.IsNullOrEmpty(UserFullName))
            {
                result = result.Where(r => SqlMethods.Like(r.UserFullName, string.Format(FilterOptions, UserFullName)));
            }

            result = result.Where(r => r.DateTimeLoggedIn > StartDate);
            result = result.Where(r => r.DateTimeLoggedIn < EndDate);
            result = result.Take(20);

            SearchResults = result;
        }
    }
}