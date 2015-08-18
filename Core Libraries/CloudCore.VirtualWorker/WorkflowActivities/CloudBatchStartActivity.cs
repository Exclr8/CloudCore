using System;
using System.Collections.Generic;
using CloudCore.Configuration.ConfigFile;

namespace CloudCore.VirtualWorker.WorkflowActivities
{
    [Serializable]
    public class ChildActivity
    {
        public long KeyValue { get; set; }
        public byte Priority { get; set; }
        public Int32 DocWait { get; set; }
        public DateTime ActivationSchedule { get; set; }
    }

    [Serializable]
    public abstract class CloudBatchStartActivity : BaseActivity
    {
        public abstract Guid ChildProcessActivityGuid { get; }
        public abstract IEnumerable<ChildActivity> Execute();

        public override sealed void OnVirtualWork()
        {
            if (ChildProcessActivityGuid != Guid.Empty)
            {
                Guid? childactivity = ChildProcessActivityGuid;
                var items = Execute();

                Int64? childInstanceId = null;

                foreach (var item in items)
                {
                    Database.Cloudcore_ActivityBatchSpawn(WorkflowData.InstanceId, childactivity, item.KeyValue, item.ActivationSchedule, item.DocWait, item.Priority, ReadConfig.VirtualWorkerUserId, ref childInstanceId);
                }
            }
            else 
                throw new Exception("The activity guid of the child process is not set.");
        }

    }
}
