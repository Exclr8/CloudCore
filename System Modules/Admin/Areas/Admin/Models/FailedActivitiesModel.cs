using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CloudCore.Domain.Workflow;

using CloudCore.Data;
using System.Data.Linq.SqlClient;
using System;

namespace CloudCore.Admin.Models
{
    public class FailedActivity
    {
        public int ActivityId { get; set; }
        public Guid ActivityGuid { get; set; }
        public string ActivityType { get; set; }
        public string ActivityName { get; set; }
        public int TotalFailures { get; set; }
        public int ProcessModelId { get; set; }
        public Guid ProcessGuid { get; set; }
        public string ProcessName { get; set; }
        public int SubProcessId { get; set; }
        public Guid SubProcessGuid { get; set; }
        public string SubProcessName { get; set; }
    }

    public class FailedWorklistItem
    {
        public long InstanceId { get; set; }
        public long KeyValue { get; set; }
        public DateTime FailedDateTime { get; set; }
        public int ActivityId { get; set; }
        public Guid ActivityGuid { get; set; }
        public string ActivityName { get; set; }
        public string ActivityType { get; set; }
        public int ProcessModelId { get; set; }
        public Guid ProcessGuid { get; set; }
        public string ProcessName { get; set; }
        public int SubProcessId { get; set; }
        public Guid SubProcessGuid { get; set; }
        public string SubProcessName { get; set; }
    }


    public class FailedActivitiesModel
    {
        public FailedActivitiesModel()
        {
            GroupByActivity = true;
        }

        [Display(Name = "Show Activity Groups")]
        public bool GroupByActivity { get; set; }

        [Display(Name = "Process")]
        public string ProcessName { get; set; }

        [Display(Name = "Sub-Process")]
        public string SubProcessName { get; set; }

        [Display(Name = "Activity")]
        public string ActivityName { get; set; }

        public string ProcessNameFilter { get; set; }
        public string SubProcessNameFilter { get; set; }
        public string ActivityNameFilter { get; set; }

        public IEnumerable<FailedWorklistItem> FailedWorklistItems { get; set; }
        public IEnumerable<FailedActivity> FailedActivities { get; set; }

        public void LoadFailedWorklistItems()
        {
            var db = CloudCoreDB.Context;
            var searchResults = (from failedWorkListItem in db.Cloudcore_WorklistFailure
                                 join fullWorklistItem in db.Cloudcore_VwWorklistEx on failedWorkListItem.InstanceId equals fullWorklistItem.InstanceId
                                 select new FailedWorklistItem
                                 {
                                     InstanceId = fullWorklistItem.InstanceId,
                                     KeyValue = fullWorklistItem.KeyValue,
                                     ActivityId = fullWorklistItem.ActivityId,
                                     ActivityGuid = fullWorklistItem.ActivityGuid,
                                     ActivityName = fullWorklistItem.ActivityName,
                                     ActivityType = fullWorklistItem.ActivityTypeName,
                                     FailedDateTime = failedWorkListItem.FailedAt,
                                     ProcessModelId = fullWorklistItem.ProcessModelId,
                                     ProcessGuid = fullWorklistItem.ProcessGuid,
                                     ProcessName = fullWorklistItem.ProcessName,
                                     SubProcessId = fullWorklistItem.SubProcessId,
                                     SubProcessGuid = fullWorklistItem.SubProcessGuid,
                                     SubProcessName = fullWorklistItem.SubProcessName
                                 }).Distinct();

            if (!string.IsNullOrWhiteSpace(ProcessName))
            {
                searchResults = searchResults.Where(r => SqlMethods.Like(r.ProcessName, string.Format(ProcessNameFilter, ProcessName)));
            }

            if (!string.IsNullOrWhiteSpace(SubProcessName))
            {
                searchResults = searchResults.Where(r => SqlMethods.Like(r.SubProcessName, string.Format(SubProcessNameFilter, SubProcessName)));
            }

            if (!string.IsNullOrWhiteSpace(ActivityName))
            {
                searchResults = searchResults.Where(r => SqlMethods.Like(r.ActivityName, string.Format(ActivityNameFilter, ActivityName)));
            }

            FailedWorklistItems = searchResults;    
        }

        public void LoadFailedActivities()
        {
            var db = CloudCoreDB.Context;
            var searchResults = from failedWorklistItem in db.Cloudcore_WorklistFailure.Select(wf => new { wf.InstanceId, wf.ActivityId }).Distinct()
                                join activity in db.Cloudcoremodel_VwLiveProcess
                                  on failedWorklistItem.ActivityId equals activity.ActivityId
                                group new { a = activity } by new
                                {
                                    activity.ActivityId,
                                    activity.ActivityGuid,
                                    activity.ActivityName,
                                    activity.ActivityTypeName,
                                    activity.SubProcessId,
                                    activity.SubProcessGuid,
                                    activity.SubProcessName,
                                    activity.ProcessModelId,
                                    activity.ProcessGuid,
                                    activity.ProcessName
                                } into activityGroup
                                select new FailedActivity
                                {
                                    ActivityId = activityGroup.Key.ActivityId,
                                    ActivityGuid = activityGroup.Key.ActivityGuid,
                                    ActivityName = activityGroup.Key.ActivityName,
                                    ActivityType = activityGroup.Key.ActivityTypeName,
                                    SubProcessId = activityGroup.Key.SubProcessId,
                                    SubProcessGuid = activityGroup.Key.SubProcessGuid,
                                    SubProcessName = activityGroup.Key.SubProcessName,
                                    ProcessModelId = activityGroup.Key.ProcessModelId,
                                    ProcessGuid = activityGroup.Key.ProcessGuid,
                                    ProcessName = activityGroup.Key.ProcessName,
                                    TotalFailures = activityGroup.Count(),
                                };

            if (!string.IsNullOrWhiteSpace(ProcessName))
            {
                searchResults = searchResults.Where(r => SqlMethods.Like(r.ProcessName, string.Format(ProcessNameFilter, ProcessName)));
            }

            if (!string.IsNullOrWhiteSpace(SubProcessName))
            {
                searchResults = searchResults.Where(r => SqlMethods.Like(r.SubProcessName, string.Format(SubProcessNameFilter, SubProcessName)));
            }

            if (!string.IsNullOrWhiteSpace(ActivityName))
            {
                searchResults = searchResults.Where(r => SqlMethods.Like(r.ActivityName, string.Format(ActivityNameFilter, ActivityName)));
            }

            FailedActivities = searchResults;
        }
    }
}


