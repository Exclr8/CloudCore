using System.Web.Routing;
using CloudCore.Domain;
using CloudCore.Web.Core.BaseModels;

using CloudCore.Data;
using System.Data.Linq.SqlClient;
using System.Linq;

namespace CloudCore.Admin.Models
{
    public class AccessPoolLookupModel : BaseSearchModel<AccessPool>
    {
        public string Name { get; set; }
        public string NameFilter { get; set; }
        public string ReturnRouteAction { get; set; }
        public string ReturnRouteController { get; set; }
        public int ReturnRouteId { get; set; }
        public string ReturnRouteIdName { get; set; }

        public RouteValueDictionary GetReturnRouteValues(int accessPoolId)
        {
            var routeValuesToReturn = new RouteValueDictionary();

            if (string.IsNullOrWhiteSpace(ReturnRouteIdName))
                routeValuesToReturn.Add("id", ReturnRouteId);
            else
                routeValuesToReturn.Add(ReturnRouteIdName, ReturnRouteId);

            routeValuesToReturn.Add("accessPoolId", accessPoolId);
            
            return routeValuesToReturn;
        }

        public override void Search()
        {
            var result = from accessPool in CloudCoreDB.Context.Cloudcore_AccessPool
                         select new CloudCore.Domain.AccessPool()
                         {
                             Id = accessPool.AccessPoolId,
                             Name = accessPool.AccessPoolName,
                             ManagerId = accessPool.ManagerId
                         };

            if (!string.IsNullOrEmpty(Name))
            {
                result = result.Where(r => SqlMethods.Like(r.Name, string.Format(NameFilter, Name.ToString().Trim())));
            }

            SearchResults = result;
        }
    }
}