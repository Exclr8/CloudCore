using System;
using CloudCore.Domain;

using CloudCore.Web.Core.BaseModels;

using CloudCore.Data;
using System.Data.Linq.SqlClient;
using System.Linq;

namespace CloudCore.Admin.Models
{
    public class PageAccessPoolLookupModel : BaseSearchModel<AccessPoolModel>
    {
        public PageAccessPoolLookupModel() { }

        public PageAccessPoolLookupModel(int actionIdBeingSearched)
        {
            ActionId = actionIdBeingSearched;
        }

        public string FilterOptions { get; set; }
        public string Name { get; set; }
        public int? ActionId { get; set; }

        public override void Search()
        {
            if (!ActionId.HasValue)
                throw new NullReferenceException("The ActionId cannot be null. Make sure it is being set before attempting the search.");

            var database = CloudCoreDB.Context;
            var result = from accessPool in database.Cloudcore_AccessPool
                         join u in database.Cloudcore_User on accessPool.ManagerId equals u.UserId
                         where
                               !(from accessPoolPage in database.Cloudcore_SystemActionAllocation
                                 where accessPoolPage.ActionId == ActionId
                                 select accessPoolPage.AccessPoolId)
                                 .Contains(accessPool.AccessPoolId)
                         select new AccessPoolModel()
                         {
                             AccessPoolId = accessPool.AccessPoolId,
                             AccessPoolName = accessPool.AccessPoolName,
                             ManagerUserId = u.UserId
                         };

            if (!string.IsNullOrEmpty(Name))
            {
                result = result.Where(r => SqlMethods.Like(r.AccessPoolName, string.Format(FilterOptions, Name)));
            }

            SearchResults = result;
        }
    }
}