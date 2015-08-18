using System;
using System.ComponentModel.DataAnnotations;
using CloudCore.Domain.Workflow;

namespace CloudCore.Admin.Models
{
    public class WorklistSearchItemModel
    {
        [Display(Name = "Key")]
        public Int64 KeyValue {get; set;}

        [Display(Name = "Process Model Id")]
        public int ProcessModelId {get; set;}

        [Display(Name = "Process Name")]
        public string ProcessName {get; set;}

        [Display(Name = "Sub Process Id")]
        public int SubProcessId {get; set;}

        [Display(Name = "Sub Process Name")]
        public string SubProcessName {get; set;}

        [Display(Name = "Activity Id")]
        public int ActivityId {get; set;}

        [Display(Name = "Activity Name")]
        public string ActivityName {get; set;}

        [Display(Name = "User Id")]
        public int UserId {get; set;}

        [Display(Name = "User Name")]
        public string UserName {get; set;}

        [Display(Name = "Status Id")]
        public int StatusTypeId {get; set;}

        [Display(Name = "Status")]
        public string StatusTypeName {get; set;}

        [Display(Name = "Instance Id")]
        public Int64 InstanceId {get; set;}

        [Display(Name = "Doc Wait")]
        public string DocWait { get; set; }

        public WorklistSearchItemModel Populate(WorkItem workItem)
        {
            UserId = workItem.UserId;
            KeyValue = workItem.KeyValue;
            UserName = workItem.UserName;
            StatusTypeId = workItem.Status.Id;
            StatusTypeName = workItem.Status.Name;
            InstanceId = workItem.InstanceId;

            return this;
        }
    }
}