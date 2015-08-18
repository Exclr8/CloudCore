using System;
using System.Web.Mvc;
//using CloudCore.Domain.SchedulesTasks;
using CloudCore.Web.Core.Caching.CachedReusableObjects;

using CloudCore.Data;
using System.Linq;

namespace CloudCore.Admin.Classes.CachedReusableObjects
{
    public class ScheduledCachedReusableObject : BaseCachedReusableObject<ScheduledCachedReusableObject>
    {
        public override string GetTitle()
        {
            return "Scheduled Task Details";
        }

        public override void AddContent(CROContent content, UrlHelper urlHelper)
        {
            content.AddHtmlContent("Scheduled Task Name", ScheduledTaskName);
            content.AddHtmlContent("Scheduled Task Type", ScheduledTaskType);
            content.AddHtmlContent("Status", Status);
            content.AddHtmlContent("Next Run Date", NextRunDate.ToShortDateString());
            content.AddHtmlContent("Is Active", Active == false ? "No" : "Yes");
            content.AddHtmlContent("Failure Notify Email", NotifyEmail);
        }

        protected override void GetPropertyValues()
        { 
            CloudCoreDB database = CloudCoreDB.Context;
            var result = (from sched in database.Cloudcore_ScheduledTask
                          where sched.ScheduledTaskId == ScheduledTaskId
                          select sched).SingleOrDefault();

            this.ScheduledTaskGuid = result.ScheduledTaskGuid;
            this.ScheduledTaskName = result.ScheduledTaskName;
            this.ScheduledTaskTypeId = result.ScheduledTaskTypeId;
            this.ScheduledTaskType = result.ScheduledTaskType;
            this.DateCreated = result.Created;
            this.Started = result.Started;
            this.StatusId = result.StatusId;
            this.Status = result.Status;
            this.Active = result.Active;
            this.OnDemand = result.OnDemand;
            this.IntervalType = result.IntervalType;
            this.IntervalTypeName = result.IntervalTypeName;
            this.IntervalValue = result.IntervalValue;
            this.InitDate = result.InitDate;
            this.NextRunDate = result.NextRunDate;
            this.ScheduledTaskGroupId = result.ScheduledTaskGroupId;
            this.SystemModuleId = result.SystemModuleId;
            this.NotifyEmail = result.NotifyEmail;
        }

        #region Properties
        public int ScheduledTaskId { get { return Convert.ToInt32(Key); } }
        public Guid ScheduledTaskGuid { get; set; }
        public string ScheduledTaskName { get; set; }
        public int ScheduledTaskTypeId { get; set; }
        public string ScheduledTaskType { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? Started { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public bool Active { get; set; }
        public bool OnDemand { get; set; }
        public byte IntervalType { get; set; }
        public string IntervalTypeName { get; set; }
        public int IntervalValue { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime NextRunDate { get; set; }
        public int ScheduledTaskGroupId { get; set; }
        public int SystemModuleId { get; set; }
        public string NotifyEmail { get; set; }
        #endregion
    }
}