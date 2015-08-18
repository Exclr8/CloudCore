using System.Collections.Generic;
using CloudCore.Admin.Classes.FormObjects;
using CloudCore.Data;
using System.Linq;

namespace CloudCore.Admin.Models
{
    public class ActivityAccessPoolAllocationModel : ActivityForm
    {
        public IEnumerable<AccessPoolItem> AccessPools { get; set; }

        public ActivityAccessPoolAllocationModel() { }

        public ActivityAccessPoolAllocationModel(int activityId)
        {
            ActivityId = activityId;
        }

        public void LoadAccessPools()
        {
            var db = new CloudCoreDB();
            AccessPools = (from ap in db.Cloudcore_AccessPool
                           join aa in db.Cloudcore_ActivityAllocation on ap.AccessPoolId equals aa.AccessPoolId
                           where aa.ActivityId == ActiveActivityDetails.ActivityId
                           select new AccessPoolItem
                           {
                               AccessPoolId = ap.AccessPoolId,
                               AccessPoolName = ap.AccessPoolName
                           });
        }
    }

}