using System;
using System.ComponentModel.DataAnnotations;

namespace CloudCore.Admin.Areas.Admin.Models
{
    public class ScheduledTaskModelEnableDisable
    {
        public int ScheduledTaskId { get; set; }

        [Display(Name = "Name")]
        public String ScheduledTaskName { get; set; }

        public bool IsRunning { get; set; }
    }
}