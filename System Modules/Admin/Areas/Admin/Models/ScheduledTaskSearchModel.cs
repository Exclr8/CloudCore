using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using CloudCore.Domain;
//using CloudCore.Domain.SchedulesTasks;
using CloudCore.Web.Core.BaseModels;

using CloudCore.Data;
using System.Data.Linq.SqlClient;

namespace CloudCore.Admin.Models
{

    public class ScheduledTaskSearchModel : BaseSearchModel<ScheduledTaskSearchItemModel>
    {
        public string ScheduledTaskTypeFilter { get; set; }
        public string ScheduledTaskNameFilter { get; set; }
        public string IntervalTypeNameFilter { get; set; }

        [Display(Name = "Scheduled Task Type")]
        public string ScheduledTaskType { get; set; }

        [Display(Name = "Name")]
        public String ScheduledTaskName { get; set; }

        [Display(Name = "Interval Type")]
        public string IntervalTypeName { get; set; }

        public override void Search()
        {
            CloudCoreDB database = CloudCoreDB.Context;

            var result = (from scheduledtask in database.Cloudcore_ScheduledTask
                          select new ScheduledTaskSearchItemModel
                          {
                              ScheduledTaskId = scheduledtask.ScheduledTaskId,
                              ScheduledTaskName = scheduledtask.ScheduledTaskName,
                              ScheduledTaskType = scheduledtask.ScheduledTaskType,
                              IntervalTypeName = scheduledtask.IntervalTypeName,
                              IntervalValue = scheduledtask.IntervalValue,
                              InitDate = scheduledtask.NextRunDate
                          });

            if (!string.IsNullOrEmpty(ScheduledTaskName))
            {
                result = result.Where(r => SqlMethods.Like(r.ScheduledTaskName, string.Format(ScheduledTaskNameFilter, ScheduledTaskName)));
            }
            if (!string.IsNullOrEmpty(IntervalTypeName))
            {
                result = result.Where(r => SqlMethods.Like(r.IntervalTypeName, string.Format(IntervalTypeNameFilter, IntervalTypeName)));
            }
            if (!string.IsNullOrEmpty(ScheduledTaskType))
            {
                result = result.Where(r => SqlMethods.Like(r.ScheduledTaskType, string.Format(ScheduledTaskTypeFilter, ScheduledTaskType)));
            }

            SearchResults = result;
        }

        public List<SelectListItem> ScheduledTaskTypes
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem { Text = "Any", Value = string.Empty },
                    new SelectListItem { Text = "Sql", Value = "Sql" },
                    new SelectListItem { Text = "C#", Value = "CSharp" }
                };
            }
        }
    }
}
