using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using CloudCore.Domain.Workflow;
using CloudCore.Web.Core.BaseModels;

using System.Data.Linq.SqlClient;
using CloudCore.Data;

namespace CloudCore.Admin.Models
{
    public class WorklistSearchModel : BaseSearchModel<WorklistSearchItemModel>
    {
        [Display(Name = "Reference/Key Value")]
        [Range(1, long.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public string KeyValue { get; set; }
        public string KeyValueFilter { get; set; }

        [Display(Name = "Process Name")]
        public string ProcessName { get; set; }
        public string ProcessNameFilter { get; set; }

        [Display(Name = "Sub Process Name")]
        public string SubProcessName { get; set; }
        public string SubProcessNameFilter { get; set; }

        [Display(Name = "Activity Name")]
        public string ActivityName { get; set; }
        public string ActivityNameFilter { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string UserNameFilter { get; set; }

        [Display(Name = "System Module")]
        public string SystemModule { get; set; }

        [Display(Name = "Status")]
        public int Status { get; set; }

        [Display(Name = "Waiting For Documentation")]
        public bool? DocWait { get; set; }

        public List<SelectListItem> LstStatusTypes { get; set; }
        
        public List<SelectListItem> LstDocWait { get; set; }

        public WorklistSearchModel()
        {
            GetListDocWait();
        }

        private void GetListDocWait()
        {
            LstDocWait = new List<SelectListItem>
            {
                new SelectListItem {Text = "Any", Value = ""},
                new SelectListItem {Text = "No", Value = "false"},
                new SelectListItem {Text = "Yes", Value = "true"}
            };
        }

        public void GetListStatusTypes()
        {
            var statusTypes = WorkItemStatus.All;

            var statusDropDownItems = statusTypes.Select(
                status => new SelectListItem
                {
                    Text = status.Name,
                    Value = status.Id.ToString()
                }).ToList();

            statusDropDownItems.Insert(0, new SelectListItem {Text = "Any", Value = "-1" });
            LstStatusTypes = statusDropDownItems;
        }

        public override void Search()
        {

            CloudCoreDB database = CloudCoreDB.Context;

            var result = from wl in database.Cloudcore_VwWorklistEx
                         select new WorklistSearchItemModel
                         {
                             KeyValue = wl.KeyValue,
                             ProcessModelId = wl.ProcessModelId,
                             ProcessName = wl.ProcessName,
                             SubProcessId = wl.SubProcessId,
                             SubProcessName = wl.SubProcessName,
                             ActivityId = wl.ActivityId,
                             ActivityName = wl.ActivityName,
                             UserId = wl.UserId,
                             UserName = wl.UserName,
                             StatusTypeId = wl.StatusTypeId,
                             StatusTypeName = wl.StatusTypeName,
                             InstanceId = wl.InstanceId,
                             DocWait = wl.DocWait == true ? "Yes" : "No",
                         };

            if (!String.IsNullOrEmpty(KeyValue)) { result = result.Where(r => r.KeyValue.ToString() == KeyValue); }
            if (!String.IsNullOrEmpty(ProcessName)) { result = result.Where(r => SqlMethods.Like(r.ProcessName, string.Format(ProcessNameFilter, ProcessName))); }
            if (!String.IsNullOrEmpty(SubProcessName)) { result = result.Where(r => SqlMethods.Like(r.SubProcessName, string.Format(SubProcessNameFilter, SubProcessName))); }
            if (!String.IsNullOrEmpty(ActivityName)) { result = result.Where(r => SqlMethods.Like(r.ActivityName, string.Format(ActivityNameFilter, ActivityName))); }
            if (!String.IsNullOrEmpty(UserName)) { result = result.Where(r => SqlMethods.Like(r.UserName, string.Format(UserNameFilter, UserName))); }
          //  if (!String.IsNullOrEmpty(SelectedStatus)) { result = result.Where(r => r.StatusTypeId == Convert.ToInt32(SelectedStatus)); }
          //  if (!String.IsNullOrEmpty(SelectedDocWait)) { result = result.Where(r => r.DocWait == SelectedDocWait); }

            SearchResults = result;
        }
    }

    public class PositiveWholeNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            if (string.IsNullOrWhiteSpace(value.ToString()))
                return true;

            long num;
            
            if (long.TryParse(value.ToString(), out num))
            {
                if (num <= 0)
                    return false;

                if (num > 0)
                    return true;
            }
            
            return false;
        }
    }
}