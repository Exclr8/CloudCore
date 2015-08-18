using System;
using CloudCore.Configuration.ConfigFile;

namespace CloudCore.VirtualWorker.WorkflowActivities
{
    [Serializable]
    public abstract class SqlBatchStartActivity : BaseActivity
    {
        public abstract Guid ChildProcessActivityGuid { get; }

        public override sealed void OnVirtualWork()
        {
            if (ChildProcessActivityGuid != Guid.Empty)
            {
                Guid? childactivity = ChildProcessActivityGuid;
                var batchitems = Database.ExecuteQuery<ChildActivity>(string.Format(@"exec [cloudcore].[CCBatchStart_{0}] @InstanceId = {1}, @KeyValue = {2}", 
                                                                                      SqlItemGuid, 
                                                                                      WorkflowData.InstanceId, 
                                                                                      WorkflowData.KeyValue));
                Int64? childInstanceId = null;

                foreach (var item in batchitems)
                {
                    ChildActivity item1 = item; // local copy is necessary
                    ThreadSafeDataAccess.DataAccessOperation(() => Database.Cloudcore_ActivityBatchSpawn(WorkflowData.InstanceId, childactivity, item1.KeyValue,
                        item1.ActivationSchedule, item1.DocWait, item1.Priority, ReadConfig.VirtualWorkerUserId,
                        ref childInstanceId));
                }
            }
            else 
                throw new Exception("The activity guid of the child process is not set."); 
        }


    }
}
