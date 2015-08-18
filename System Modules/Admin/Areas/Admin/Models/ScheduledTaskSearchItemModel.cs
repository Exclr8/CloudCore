using System;
using System.ComponentModel.DataAnnotations;

namespace CloudCore.Admin.Models
{
    public class ScheduledTaskSearchItemModel
    {
        [Display(Name = "Scheduled Task Id")]
        public long ScheduledTaskId { get; set; }

        [Display(Name = "Name")]
        public String ScheduledTaskName { get; set; }

        [Display(Name = "Task Type")]
        public String ScheduledTaskType { get; set; }

        [Display(Name = "Interval Type")]
        public string IntervalTypeName { get; set; }

        [Display(Name = "Interval Value")]
        public int IntervalValue { get; set; }

        [Display(Name = "Next Run Date")]
        public DateTime InitDate { get; set; }
    }
}