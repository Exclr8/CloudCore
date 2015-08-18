using System.Collections.Generic;
using System.Linq;
using CloudCore.Domain;

using CloudCore.Data;

namespace CloudCore.Admin.Models
{
    public class PagesModel : SystemPageContext
    {
        public IEnumerable<AccessPool> AccessPools { get; set; }

        internal void LoadAccessPools()
        {
            var dbContext = CloudCoreDB.Context;
            AccessPools = (from saa in dbContext.Cloudcore_SystemActionAllocation
                    join ap in dbContext.Cloudcore_AccessPool on saa.AccessPoolId equals ap.AccessPoolId
                    where saa.ActionId == this.ActionId
                    select new CloudCore.Domain.AccessPool
                    {
                        Id = ap.AccessPoolId,
                        Name = ap.AccessPoolName,
                        ManagerId = ap.ManagerId
                    });

        }
    }
}