using System;
using System.Linq;
using System.Web.Mvc;
using CloudCore.Data;
using CloudCore.Data.Sql;
using CloudCore.Web.Core.Caching.CachedReusableObjects;

namespace CloudCore.Web.Core.Workflow.Models
{
    public class WorkItemCachedReusableObject : CachedReusableObject<WorkItemCachedReusableObject>
    {
        public override string GetTitle()
        {
            return string.Format("{0} - {1}", this.ActivityName, this.KeyValue);
        }

        public override void AddContent(CROContent content, UrlHelper Url)
        {
            content.AddHtmlContent("Activity Name", this.ActivityName);
            content.AddHtmlContent("Sub-Process Name", this.SubProcessName);
            content.AddHtmlContent("Process Name", this.ProcessName);
        }

        protected override void GetPropertyValues()
        {
            var result = CloudCoreDB.Context.Cloudcore_VwWorklistEx.Single(r => r.InstanceId == InstanceId);

            ParentInstanceId = result.PInstanceId;
            ActivityId = result.ActivityId;
            ActivityName = result.ActivityName;
            ActivityGuid = result.ActivityGuid;
            SubProcessGuid = result.SubProcessGuid;
            SubProcessId = result.SubProcessId;
            SubProcessName = result.SubProcessName;
            ProcessRevisionId = result.ProcessRevisionId;
            ProcessGuid = result.ProcessGuid;
            ProcessModelId = result.ProcessModelId;
            ProcessName = result.ProcessName;
            UserId = result.UserId;
            UserName = result.UserName;
            KeyValue = result.KeyValue;
            StatusId = result.StatusTypeId;
            Priority = result.Priority;
            Activate = result.Activate;
            DocWait = result.DocWait;
        }

        public Int64 InstanceId { get { return Convert.ToInt64(Key); } }
        public Int64? ParentInstanceId { get; internal set; }
        public int ProcessModelId { get; internal set; }
        public int ProcessRevisionId { get; internal set; }
        public Guid ProcessGuid { get; internal set; }
        public string ProcessName { get; internal set; }
        public Guid SubProcessGuid { get; internal set; }
        public int SubProcessId { get; internal set; }
        public string SubProcessName { get; internal set; }
        public int ActivityId { get; internal set; }
        public Guid? ActivityGuid { get; internal set; }
        public string ActivityName { get; internal set; }
        public int StatusId { get; internal set; }
        public int EntityID { get; internal set; }
        public string EntityName { get; internal set; }
        public int UserId { get; internal set; }
        public string UserName { get; internal set; }
        public int Priority { get; internal set; }

        public Int64 KeyValue { get; internal set; }
        public int Creator { get; internal set; }
        public DateTime Activate { get; internal set; }
        public bool DocWait { get; internal set; }
        public DateTime DueDate { get; internal set; }

        // added functions
        public string AsAction { get { return "_" + ActivityGuid.ToString().Replace("-", "_"); } }
        public string AsController { get { return "_" + SubProcessGuid.ToString().Replace("-", "_"); } }


    }
}
