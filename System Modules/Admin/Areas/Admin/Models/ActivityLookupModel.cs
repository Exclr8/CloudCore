using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CloudCore.Domain.Workflow;
using CloudCore.Web.Core.BaseModels;

using CloudCore.Data;
using System.Data.Linq.SqlClient;

namespace CloudCore.Admin.Models
{
    public class ActivityLookupModel
    {
        public int ApplicationId { get; set; }

        [Display(Name = "Activity Name")]
        public string ActivityName { get; set; }
        public string ActivityNameFilter { get; set; }

        [Display(Name = "Module Name")]
        public string ModuleName { get; set; }
        public string ModuleNameFilter { get; set; }

        [Display(Name = "Sub-Process Name")]
        public string SubProcessName { get; set; }
        public string SubProcessNameFilter { get; set; }

        [Display(Name = "Process Name")]
        public string ProcessName { get; set; }
        public string ProcessNameFilter { get; set; }

        public IEnumerable<ActivityItem> Activities = Enumerable.Empty<ActivityItem>();

        public void LoadActivities(int ApplicationId)
        {
            var db = CloudCoreDB.Context;

            var result = (from act in db.Cloudcore_Activity
                          join actmod in db.Cloudcoremodel_ActivityModel on act.ActivityModelId equals actmod.ActivityModelId
                          join mod in db.Cloudcore_SystemModule on act.SystemModuleId equals mod.SystemModuleId
                          join subp in db.Cloudcoremodel_SubProcess on new { act.SubProcessGuid, act.ProcessRevisionId } equals new { subp.SubProcessGuid, subp.ProcessRevisionId }
                          join pro in db.Cloudcoremodel_ProcessModel on act.ProcessGuid equals pro.ProcessGuid
                          join acttype in db.Cloudcoremodel_ActivityType on act.ActivityTypeId equals acttype.ActivityTypeId
                          where acttype.ActivityTypeName != "Stop" && !
                            (from sa in db.Cloudcore_SystemApplicationAllocation
                             where sa.ApplicationId == ApplicationId
                             select new
                             {
                                 sa.ActivityId
                             }).Contains(new { act.ActivityId })
                          select new ActivityItem
                          {
                              ActivityId = act.ActivityId,
                              ActivityName = actmod.ActivityName,
                              ModuleName = mod.AssemblyName,
                              SubProcessName = subp.SubProcessName,
                              ProcessName = pro.ProcessName
                          });

            if (!string.IsNullOrEmpty(ActivityName))
            {
                result = result.Where(r => SqlMethods.Like(r.ActivityName, string.Format(ActivityNameFilter, ActivityName)));
            }
            if (!string.IsNullOrEmpty(ModuleName))
            {
                result = result.Where(r => SqlMethods.Like(r.ModuleName, string.Format(ModuleNameFilter, ModuleName)));
            }
            if (!string.IsNullOrEmpty(SubProcessName))
            {
                result = result.Where(r => SqlMethods.Like(r.SubProcessName, string.Format(SubProcessNameFilter, SubProcessName)));
            }
            if (!string.IsNullOrEmpty(ProcessName))
            {
                result = result.Where(r => SqlMethods.Like(r.ProcessName, string.Format(ProcessNameFilter, ProcessName)));
            }

            Activities = result;
        }
    }
}