using System;
using CloudCore.Domain.Workflow;
using CloudCore.Web.Core.Security.Authentication;

using CloudCore.Data;

namespace CloudCore.Web.Models
{

    public class OpenWorkItem
    {
        public Int64 InstanceId { get; set; }
        public Int64 KeyValue { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
    }

    public class TaskListModel
    {
        public const string ContentPlaceHolderName = "taskListContent";

        public string ActiveSidebarTab { get; set; }

        public OpenWorkItem OpenWorkItemByInstance( Int64 instanceId)
        {

            CloudCoreDB db = new CloudCoreDB();
            Int64? keyvalue = null;
            Guid? activityGuid = null;
            Guid? subProcessGuid = null;

            db.Cloudcore_WorkItemStartByInstance(CloudCoreIdentity.UserId, instanceId, ref keyvalue, ref activityGuid, ref subProcessGuid);
            if ((activityGuid != null) && (subProcessGuid != null))
            {
                return new OpenWorkItem() { InstanceId = instanceId, KeyValue = keyvalue.Value, Action = "_" + activityGuid.Value.ToString().Replace("-", "_"), Controller = "_" + subProcessGuid.Value.ToString().Replace("-", "_") };

            }
            else
            {
                return null;
            }
        }
    }
}