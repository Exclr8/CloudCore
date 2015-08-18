using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CloudCore.Web.Core.BaseModels;

using CloudCore.Data;
using System.Data.Linq.SqlClient;

namespace CloudCore.Admin.Models.ScheduledTaskGroup
{

    public class ScheduledTaskGroup
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public int ManagerUserId { get; set; }
    }
    public class ScheduledTaskGroupSearchModel : BaseSearchModel<ScheduledTaskGroup>
    {
        [Display(Name = "Group Name")]
        public string Name { get; set; }

        public string NameFilter { get; set; }

        [Display(Name = "User Manager")]
        public string UserName { get; set; }

        public string UserNameFilter { get; set; }

        public override void Search()
        {
           var db = CloudCoreDB.Context;

           var results = from stg in db.Cloudcore_ScheduledTaskGroup
               join u in db.Cloudcore_User on stg.ManagerUserId equals u.UserId
               select new ScheduledTaskGroup
               {
                   Id = stg.ScheduledTaskGroupId,
                   Name = stg.ScheduledTaskGroupName,
                   ManagerName = u.Fullname,
                   ManagerUserId = u.UserId
               };
          
           if (!string.IsNullOrEmpty(Name))
           {
               results = results.Where(r => SqlMethods.Like(r.Name, string.Format(NameFilter, Name)));
           }
           
            if (!string.IsNullOrEmpty(UserName))
           {
               results = results.Where(r => SqlMethods.Like(r.ManagerName, string.Format(UserNameFilter, UserName)));
           }

            SearchResults = results;
        }
    }
}