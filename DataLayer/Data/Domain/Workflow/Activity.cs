using System;
using System.Collections.Generic;
using System.Linq;



namespace CloudCore.Domain.Workflow
{
    public class Activity
    {
        public Int64? InstanceId { get; set; }
        public int ActivityID { get; set; }
        public int ProcessID { get; internal set; }
        public string ActivityName { get; internal set; }
        public Guid ActivityGuid { get; internal set; }
        public Guid ProcessGuid { get; internal set; }
        public string ActivityTypeName { get; internal set; }
        public int ActivityTypeId { get; internal set; }
        public string ProcessName { get; internal set; }
        public int ProcessModelId { get; internal set; }
        public Guid SubProcessGuid { get; internal set; }
        public int SubProcessId { get; internal set; }
        public int ProcessRevisionId { get; internal set; }
        public string SubProcessName { get; internal set; }
        public int Priority { get; internal set; }
        public bool DocWait { get; internal set; }

        public Activity(int ActivityId)
        {
            GetActivity(ActivityId);
        }

        private void GetActivity(int ActivityId)
        {
            Data.CloudCoreDB db = new Data.CloudCoreDB();

            var q = (from lp in db.Cloudcoremodel_VwLiveProcess
                     where lp.ActivityId == ActivityID
                     select new
                     {
                         lp.ActivityId,
                         lp.ActivityName,
                         lp.ActivityTypeId,
                         lp.ActivityTypeName,
                         lp.SubProcessGuid,
                         lp.SubProcessId,
                         lp.SubProcessName,
                         lp.ProcessRevisionId,
                         lp.ProcessModelId,
                         lp.ProcessGuid,
                         lp.ProcessName,
                         lp.ActivityPriority,
                         lp.ActivityDocWait,
                         lp.ActivityGuid
                     }).SingleOrDefault();

            this.ActivityID = ActivityId;
            this.ActivityGuid = q.ActivityGuid;
            this.ActivityTypeId = q.ActivityTypeId;
            this.ActivityTypeName = q.ActivityTypeName;
            this.SubProcessId = q.SubProcessId;
            this.SubProcessName = q.SubProcessName;
            this.SubProcessGuid = q.SubProcessGuid;
            this.DocWait = q.ActivityDocWait;
            this.ProcessModelId = q.ProcessModelId;
            this.ProcessRevisionId = q.ProcessRevisionId;
            this.ProcessName = q.ProcessName;
            this.Priority = q.ActivityPriority;
            this.ProcessGuid = q.ProcessGuid;
        }

        internal long Start(int UserID, Int64 KeyValue)
        {
            // check here if the viewstate instid = instid and the current command = the page url
            long? InstID = null;
            // Guid? _activityGuid = null;

            Data.CloudCoreDB.Context.Cloudcore_ActivityStart(ActivityGuid, KeyValue, UserID, ref InstID);
            InstanceId = InstID;

            return Convert.ToInt64(InstanceId);
        }
    }

   
}
