using System.ComponentModel.DataAnnotations;
using System.Linq;
using CloudCore.Domain;

using CloudCore.Web.Core.BaseModels;

using System.Data.Linq.SqlClient;
using System.Data.Linq;

namespace CloudCore.Admin.Models
{
    public class AccessPoolItem
    {
        public int AccessPoolId { get; set; }
        public string AccessPoolName { get; set; }
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
    }


    public class AccessPoolSearchModel : BaseSearchModel<AccessPoolItem>
    {
        public int AccessPoolId { get; set; }
        [Display(Name="Access Pool Name")]
        public string AccessPoolName { get; set; }
        public string AccessPoolNameFilter { get; set; }
        
        [Display(Name = "Manager")]
        public string ManagerFullname { get; set; }
        public string ManagerFullnameFilter { get; set; }

        public override void Search()
        {
            var results = (from accpool in CoreDataContext.Cloudcore_AccessPool
                           join manager in CoreDataContext.Cloudcore_User
                            on accpool.ManagerId equals manager.UserId
                           select new AccessPoolItem
                           {
                               AccessPoolId = accpool.AccessPoolId,
                               AccessPoolName = accpool.AccessPoolName,
                               ManagerId = accpool.ManagerId,
                               ManagerName = manager.Fullname
                           });



            if (!string.IsNullOrEmpty(AccessPoolName))
            {
                results = results.Where(r => SqlMethods.Like(r.AccessPoolName, string.Format(AccessPoolNameFilter, AccessPoolName.ToString().Trim())));
            }
            if (!string.IsNullOrEmpty(ManagerFullname))
            {
                results = results.Where(r => SqlMethods.Like(r.ManagerName, string.Format(ManagerFullnameFilter, ManagerFullname.ToString().Trim())));
            }


            SearchResults = results;
        }
    }
}