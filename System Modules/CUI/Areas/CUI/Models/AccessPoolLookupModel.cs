using CloudCore.Domain;

using CloudCore.Web.Core.BaseModels;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Linq;
using System;
using CloudCore.Data;
using System.Data.Linq.SqlClient;

namespace CloudCore.Web.Models
{
    public class AccessPoolLookupDefinitionModel
    {
        public int AccessPoolId { get; set; }

        [Display(Name = "Access Pool Name")]
        public string AccessPoolName { get; set; }

        [Required]
        [Display(Name = "Manager")]
        public string ManagerName { get; set; }

    }

    public class AccessPoolLookupModel : BaseSearchModel<AccessPoolLookupDefinitionModel>
    {
        public int AccessPoolId { get; set; }
      
        [Display(Name = "Access Pool Name")]
        public string Name { get; set; }
        public string NameFilter { get; set; }

        [Display(Name = "Manager")]
        public string ManagerName { get; set; }
        public string ManagerNameFilter { get; set; }        

        public override void Search()
        {

            var database = CloudCoreDB.Context;

            var accessPools = (from accpool in database.Cloudcore_AccessPool
                               join manager in database.Cloudcore_User
                                 on accpool.ManagerId equals manager.UserId
                               select new AccessPoolLookupDefinitionModel
                               {
                                   AccessPoolId = accpool.AccessPoolId,
                                   AccessPoolName = accpool.AccessPoolName,
                                   ManagerName = manager.Fullname
                               });


            if (!string.IsNullOrEmpty(Name))
            {
                accessPools = accessPools.Where(r => SqlMethods.Like(r.AccessPoolName, string.Format(NameFilter, Name)));
            }
            if (!string.IsNullOrEmpty(ManagerName))
            {
                accessPools = accessPools.Where(r => SqlMethods.Like(r.ManagerName, string.Format(ManagerNameFilter, ManagerName)));
            }


            SearchResults = accessPools;
        }
    }
}