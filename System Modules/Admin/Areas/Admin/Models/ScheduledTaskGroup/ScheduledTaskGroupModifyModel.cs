using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using CloudCore.Admin.Areas.Admin.Models;
using CloudCore.Admin.Classes.FormObjects;
using CloudCore.Data;
using CloudCore.Data.Buildbase;


namespace CloudCore.Admin.Models.ScheduledTaskGroup
{
    public class ScheduledTaskGroupModifyModel : ScheduledTaskGroupForm
    {
        [Display(Name = "Custom time picker control")]
        [DataType(DataType.DateTime)]
        public DateTime TimePicker { get; set; }

        [Required(ErrorMessage = "Please enter Scheduled Task Group Name.")]
        [Display(Name = "Scheduled Task Group Name")]
        public string ScheduledTaskGroupName { get; set; }

        [Display(Name = "User Manager")]
        public string UserName { get; set; }

        [Display(Name = "User Manager")]
        public int UserId { get; set; }

        public List<ScheduledTaskModelEnableDisable> ScheduledTasks { get; set; }

        public void LoadModelDataFromActiveUserCache()
        {
            if (ActiveScheduledTaskGroupDetails != null)
            {
                ScheduledTaskGroupId = ActiveScheduledTaskGroupDetails.ScheduledTaskGroupId;
                ScheduledTaskGroupName = ActiveScheduledTaskGroupDetails.ScheduledTaskGroupName;
                UserName = ActiveScheduledTaskGroupDetails.UserName;
                UserId = ActiveScheduledTaskGroupDetails.UserId;
            }
        }

        public void LoadScheduledTaskGroupScheduledTasks(int scheduledTaskGroupId)
        {
            var context = new CloudCoreDB();
            var data = context.Cloudcore_ScheduledTasksPerGroupId(scheduledTaskGroupId);

            ScheduledTasks = new List<ScheduledTaskModelEnableDisable>();

            foreach (var item in data)
            {
                var task = new ScheduledTaskModelEnableDisable
                {
                    ScheduledTaskId = item.ScheduledTaskId ?? 0,
                    ScheduledTaskName = item.ScheduledTaskName,
                    IsRunning = item.StatusId == 0 || item.StatusId == 1
                };
                ScheduledTasks.Add(task);
            }

            context.Dispose();
        }

        public void UpdateScheduledGroupTask()
        {
            CloudCoreDB.Context.Cloudcore_ScheduledTaskGroupUpdate(ScheduledTaskGroupId, ScheduledTaskGroupName, UserId);
            
            ActiveScheduledTaskGroupDetails.ForceRefresh();
        }

        public static void UpdateScheduledTask(int scheduledTaskId, int statusId)
        {
            using (var context = new CloudCoreDB())
            {
                context.Cloudcore_ScheduledTaskUpdateStatus(scheduledTaskId, statusId);
            }
        }
    }
}