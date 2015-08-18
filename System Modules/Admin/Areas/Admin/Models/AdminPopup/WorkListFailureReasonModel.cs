using System.Collections.Generic;


using CloudCore.Data;
using System.Linq;

namespace CloudCore.Admin.Models
{
    public class WorkListFailureReasonModel
    {
        public WorkListFailureReasonModel(long instanceId)
        {
            Reasons = CloudCoreDB.Context.Cloudcore_WorklistFailure.Where(a => a.InstanceId == instanceId)
                                                                  .Select(a => a.Reason)
                                                                  .ToList();
        }

        public List<string> Reasons { get; set; }
    }
}