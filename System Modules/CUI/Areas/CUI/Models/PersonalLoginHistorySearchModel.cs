using System;
using System.ComponentModel.DataAnnotations;
using CloudCore.Web.Core.BaseModels;

using CloudCore.Data;
using CloudCore.Web.Core.Security.Authentication;
using System.Linq;

namespace CloudCore.Web.Models
{
    public class LoginHistory
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public string UserLogin { get; set; }
        public int ApplicationId { get; set; }
        public DateTime Connected { get; set; }
    }

    public class PersonalLoginHistorySearchModel : BaseSearchModel<LoginHistory>
    {
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        private int UserId { get; set; }
        public void Search( int userId)
        {
            UserId = userId;
            Search();
        }
        public override void Search()
        {
            if (StartDate > EndDate)
            {
                throw new ArgumentException("Start Date cannot be greater than End Date");
            }

            CloudCoreDB database = CloudCore.Data.CloudCoreDB.Context;

            var result = from lh in database.Cloudcore_LoginHistory
                         join user in database.Cloudcore_User on lh.UserId equals user.UserId
                         where user.UserId == CloudCoreIdentity.UserId
                         select new LoginHistory
                         {
                             Connected = lh.Connected
                         };

            result = result.Where(r => r.Connected > StartDate);
            result = result.Where(r => r.Connected < EndDate.AddDays(1));
            result = result.Take(20);

            SearchResults = result;
        }
    }
}