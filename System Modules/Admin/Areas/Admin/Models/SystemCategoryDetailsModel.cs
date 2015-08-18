using System.Collections.Generic;
using System.Linq;
using CloudCore.Domain;

using CloudCore.Data;

namespace CloudCore.Admin.Models
{
    public class SystemValueCategoryDetailsModel : SystemValueCategoryContext
    {
        public IEnumerable<SystemValueDetailModel> CategorySystemValues = Enumerable.Empty<SystemValueDetailModel>();

        public void GetSystemValues()
        {
            var database = CloudCoreDB.Context;

            var results = (from syscat in database.Cloudcore_SystemValue
                           where syscat.CategoryId == this.CategoryId
                           select new SystemValueDetailModel
                           {
                               ValueId = syscat.ValueID,
                               ValueName = syscat.ValueName,
                               ValueDescription = syscat.ValueDescription,
                               ValueData = syscat.ValueData
                           });

            CategorySystemValues = results;
        }
    }

}