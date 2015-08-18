using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using CloudCore.Admin.Classes.FormObjects;
using CloudCore.Domain;
//using CloudCore.Domain.SchedulesTasks;


using CloudCore.Data;

namespace CloudCore.Admin.Models
{
    public class ScheduledTaskModel : ScheduledTaskForm
    {
        [Required]
        [Display(Name = "Name")]
        public String ScheduledTaskName { get; set; }

        [Display(Name = "Interval Type")]
        public byte IntervalType { get; set; }

        [Display(Name = "Interval Type Name")]
        public string IntervalTypeName { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Interval Value")]
        public int IntervalValue { get; set; }

        [Display(Name = "Next Run Date")]
        public DateTime NextRunDate { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [Required]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "Not a valid email address")]
        [Display(Name="Failure Notify Email")]
        public string NotifyEmail { get; set; }

        public List<SelectListItem> LstIntervalTypes { get; set; }

        public void LoadModelDataFromActiveUserCache()
        {
            if (ActiveScheduledTaskDetails != null)
            {
                ScheduledTaskName = ActiveScheduledTaskDetails.ScheduledTaskName;
                IntervalType = ActiveScheduledTaskDetails.IntervalType;
                IntervalValue = ActiveScheduledTaskDetails.IntervalValue;
                IntervalTypeName = ActiveScheduledTaskDetails.IntervalTypeName;
                NextRunDate = ActiveScheduledTaskDetails.NextRunDate;
                ScheduledTaskId = ActiveScheduledTaskDetails.ScheduledTaskId;
                IsActive = ActiveScheduledTaskDetails.Active;
                NotifyEmail = ActiveScheduledTaskDetails.NotifyEmail;
            }
        }

        public void UpdateScheduledTask()
        {
            GetIntervalTypes();
            CloudCoreDB.Context.Cloudcore_ScheduledTaskUpdateConfig(ScheduledTaskId, ScheduledTaskName, IntervalValue,
                IntervalType, NextRunDate, NotifyEmail, IsActive);
               
            ActiveScheduledTaskDetails.ForceRefresh();
        }

        public void GetIntervalTypes()
        {
            LstIntervalTypes = new List<SelectListItem>{
                    new SelectListItem {Text = "Years", Value = "0"},
                    new SelectListItem {Text = "Months", Value = "1"},
                    new SelectListItem {Text = "Weeks", Value = "2"},
                    new SelectListItem {Text = "Days", Value = "3"},
                    new SelectListItem {Text = "Hours", Value = "4"},
                    new SelectListItem {Text = "Minutes", Value = "5"},
                    new SelectListItem {Text = "Seconds", Value = "6"}
            };
        }
    }
}