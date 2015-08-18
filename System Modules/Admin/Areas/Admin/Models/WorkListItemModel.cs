using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CloudCore.Admin.Classes.FormObjects;
using CloudCore.Domain.Workflow;
using CloudCore.Web.Core.Security.Authentication;

using CloudCore.Data;

namespace CloudCore.Admin.Models
{

    public class FailedActivityHistory
    {
        public DateTime DateFailed { get; set; }
        public string Reason { get; set; }
        public string ActivityName { get; set; }
    }

    public class WorkListItemModel : WorkListItemForm
    {
        public string StatusTypeName { get; set; }

        [Display(Name = "User")]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string ActivityName { get; set; }
        public string ProcessName { get; set; }
        public string SubProcessName { get; set; }

        [Display(Name = "Priority")]
        [Range(0, byte.MaxValue)]
        public byte Priority { get; set; }

        [Display(Name = "Activate Date")]
        public DateTime ActivationSchedule { get; set; }

        public IEnumerable<FailedActivityHistory> InstanceFailedHistory { get; set; }

        public IEnumerable<AccessPoolModel> AccessPools { get; set; }

        public WorkListItemModel() { }

        public WorkListItemModel(int instanceId)
        {
            InstanceId = instanceId;
        }

        public void LoadInstanceHistory()
        {
            var db = new CloudCoreDB();
            var result = (from af in db.Cloudcore_ActivityFailureHistory
                          join am in db.Cloudcoremodel_ActivityModel on af.ActivityModelId equals am.ActivityModelId
                          join a in db.Cloudcore_Activity on am.ActivityModelId equals a.ActivityModelId
                          join w in db.Cloudcore_Worklist on new { af.KeyValue, a.ActivityId } equals new { w.KeyValue, w.ActivityId }
                          where w.InstanceId == InstanceId
                          orderby af.FailedAt descending
                          select new FailedActivityHistory
                          {
                              DateFailed = af.FailedAt,
                              Reason = af.Reason,
                              ActivityName = am.ActivityName
                          });

            InstanceFailedHistory = result.OrderByDescending(x => x.DateFailed);
        }

        public void LoadModelDataFromActiveUserCache()
        {
            if (ActiveWorkListItem != null)
            {
                InstanceId = ActiveWorkListItem.InstanceId;
                StatusTypeName = ActiveWorkListItem.StatusTypeName;
                UserName = ActiveWorkListItem.UserName;
                ActivityName = ActiveWorkListItem.ActivityName;
                ProcessName = ActiveWorkListItem.ProcessName;
                SubProcessName = ActiveWorkListItem.SubProcessName;
                UserId = ActiveWorkListItem.UserId;
                Priority = ActiveWorkListItem.Priority;
                ActivationSchedule = ActiveWorkListItem.ActivationSchedule;
            }
        }

        public string UpdateUserforWorklistItem()
        {
            var success = "true";
            try
            {
                CloudCoreDB.Context.Cloudcore_WorkItemChangeUser(InstanceId, UserId);
            }
            catch (Exception ex)
            {
                success = ex.Message;
            }
            return success;
        }

        public string UpdatePriorityforWorklistItem()
        {
            var success = "true";
            try
            {
                CloudCoreDB.Context.Cloudcore_WorkItemChangePriority(InstanceId, Priority);
            }
            catch (Exception ex)
            {
                success = ex.Message;
            }
            return success;
        }

        public string CancelWorklistItem()
        {
            var success = "true";
            try
            {
                CloudCoreDB.Context.Cloudcore_WorkItemCancel(InstanceId, CloudCoreIdentity.UserId);
            }
            catch (Exception ex)
            {
                success = ex.Message;
            }
            return success;
        }

        public string ReleaseWorklistItem()
        {
            var success = "true";
            try
            {
                CloudCoreDB.Context.Cloudcore_WorkItemRelease(InstanceId);
            }
            catch (Exception ex)
            {
                success = ex.Message;
            }
            return success;
        }

        public string DelayWorklistItem()
        {
            var success = "true";
            try
            {
                CloudCoreDB.Context.Cloudcore_WorkItemDelay(InstanceId, ActivationSchedule);
            }
            catch (Exception ex)
            {
                success = ex.Message;
            }
            return success;
        }
    }
}