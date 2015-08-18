using System;
using CloudCore.Configuration.ConfigFile;
using CloudCore.Data;
using CloudCore.VirtualWorker.Engine.Workflow;
using CloudCore.VirtualWorker.Threading;

namespace CloudCore.VirtualWorker.WorkflowActivities
{
    public interface IActivity : IDisposable
    {
        void OnVirtualWork();
    }

    [Serializable]
    public abstract class BaseActivity : IActivity
    {
        internal string Outcome { get; set; }

        private bool _shouldDelay;

        protected CloudCoreDB Database = new CloudCoreDB();

        protected IThreadSafeDataAccess ThreadSafeDataAccess { get; set; }

        public WorklistItem WorkflowData { get; private set; }

        public string SqlItemGuid
        {
            get { return WorkflowData.ActivityGuid.ToString().Replace("-", "_").ToLower(); }
        }

        public abstract void OnVirtualWork();

        internal void SetThreadSafeDataAccessObject(IThreadSafeDataAccess threadSafeDataAccess)
        {
            ThreadSafeDataAccess = threadSafeDataAccess;
        }

        protected internal void SetWorkItemData(WorklistItem worklistItem)
        {
            WorkflowData = worklistItem;
        }

        /// <summary>
        /// NOTE: Do not call this within derivatives! It is called internally by the workflow engine.
        /// </summary>
        internal void ExecuteActivity()
        {

            Outcome = null;
            OnVirtualWork();

            if (!_shouldDelay)
            {
                ThreadSafeDataAccess.DataAccessOperation(() => Database.Cloudcore_WorkItemFlow(WorkflowData.InstanceId, ReadConfig.VirtualWorkerUserId, Outcome));
            }
        }

        protected internal void DelayWorkItem(int delayInMinutes)
        {
            if (delayInMinutes > 0)
            {
                _shouldDelay = true;
                ThreadSafeDataAccess.DataAccessOperation(() => Database.Cloudcore_WorkItemDelay(WorkflowData.InstanceId, DateTime.Now.AddMinutes(delayInMinutes)));
            }
        }

        public virtual void Dispose()
        {
            Database.Dispose();
            Database = null;
        }
    }
}
