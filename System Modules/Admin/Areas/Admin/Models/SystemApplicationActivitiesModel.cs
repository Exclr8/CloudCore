using System.Collections.Generic;
using System.Linq;
using CloudCore.Domain;

using CloudCore.Data;

namespace CloudCore.Admin.Models
{
    public class SystemApplicationActivitiesModel : SystemApplicationContext
    {

        public List<SystemApplicationActivity> ApplicationActivities { get; set; }

        public void GetApplicationActivities()
        {
            CloudCoreDB db = new CloudCoreDB();
            var query = (from appact in db.Cloudcore_SystemApplicationAllocation
                         join act in db.Cloudcore_Activity on appact.ActivityId equals act.ActivityId
                         join actmod in db.Cloudcoremodel_ActivityModel on new { act.ProcessRevisionId, act.ActivityModelId } equals new { actmod.ProcessRevisionId, actmod.ActivityModelId }
                         join mod in db.Cloudcore_SystemModule on act.SystemModuleId equals mod.SystemModuleId
                         join subp in db.Cloudcoremodel_SubProcess on new { act.SubProcessGuid, act.ProcessRevisionId } equals new { subp.SubProcessGuid, subp.ProcessRevisionId }
                         join pro in db.Cloudcoremodel_ProcessModel on act.ProcessGuid equals pro.ProcessGuid
                         where appact.ApplicationId == this.ApplicationId
                         select new SystemApplicationActivity
                         {
                             ActivityId = appact.ActivityId,
                             ActivityName = actmod.ActivityName,
                             ModuleName = mod.AssemblyName,
                             SubProcessName = subp.SubProcessName,
                             ProcessName = pro.ProcessName
                         });

            this.ApplicationActivities = query.Distinct().ToList();
        }
    }
}