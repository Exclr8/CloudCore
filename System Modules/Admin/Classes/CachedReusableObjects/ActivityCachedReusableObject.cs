using System;
using System.Web.Mvc;
using CloudCore.Domain.Workflow;
using CloudCore.Web.Core.Caching.CachedReusableObjects;

using CloudCore.Data;
using System.Linq;

namespace CloudCore.Admin.Classes.CachedReusableObjects
{
    public class ActivityCachedReusableObject : BaseCachedReusableObject<ActivityCachedReusableObject>
    {
        public int ActivityId { get { return Convert.ToInt32(Key); } }
        public int ProcessRevisionId { get; set; }
        public int SubProcessId { get; set; }
        public string ActivityName { get; set; }
        public string ActivityType { get; set; }
        public bool Startable { get; set; }
        public string ProcessName { get; set; }
        public int MaximumRetries { get; set; }
        public int RetryDelayInSeconds { get; set; }

        protected override void GetPropertyValues()
        {
            using (var context = CloudCoreDB.Context)
            {
                var result = (from a in context.Cloudcore_Activity
                              join am in context.Cloudcoremodel_ActivityModel on a.ActivityModelId equals am.ActivityModelId
                              join at in context.Cloudcoremodel_ActivityType on am.ActivityTypeId equals at.ActivityTypeId
                              join pr in context.Cloudcoremodel_ProcessRevision on am.ProcessRevisionId equals pr.ProcessRevisionId
                              join pm in context.Cloudcoremodel_ProcessModel on pr.ProcessModelId equals pm.ProcessModelId
                              where a.ActivityId == ActivityId
                              select new
                              {
                                  ProcessRevisionId = a.ProcessRevisionId,
                                  SubProcessId = am.SubProcessId,
                                  ActivityName = am.ActivityName,
                                  ActivityType = at.ActivityTypeName,
                                  Startable = am.Startable,
                                  ProcessName = pm.ProcessName,
                                  MaximumRetries = am.MaxRetries,
                                  RetryDelayInSeconds = am.RetryDelayInSeconds,
                              }).Single();

                this.ProcessRevisionId = result.ProcessRevisionId;
                this.SubProcessId = result.SubProcessId;
                this.ActivityName = result.ActivityName;
                this.ActivityType = result.ActivityType;
                this.Startable = result.Startable;
                this.ProcessName = result.ProcessName;
                this.MaximumRetries = result.MaximumRetries;
                this.RetryDelayInSeconds = result.RetryDelayInSeconds;
            }
        }

        public override void AddContent(CROContent content, UrlHelper urlHelper)
        {
            content.AddHtmlContent("Activity Name", ActivityName);
            content.AddHtmlContent("Process Name", ProcessName);
            content.AddHtmlContent("Activity Type", ActivityType);
            content.AddHtmlContent("Startable", Startable ? "Yes" : "No");
        }

        public override string GetTitle()
        {
            return "Activity Details";
        }
    }
}