using System;
using System.Threading;
using CloudCore.VirtualWorker.Exceptions;

namespace CloudCore.VirtualWorker.Threading.ScheduledTask
{
    public class OrphanScheduledTaskThreadSafeDataAccess : IThreadSafeDataAccess
    {
        private volatile object _syncRoot = new object();

        public object SyncRoot
        {
            get
            {
                return _syncRoot;
            }
        }

        public void DataAccessOperation(Action actionToTake)
        {
            if (!Monitor.TryEnter(SyncRoot, LockTimeout.Value))
                throw new DataThreadDeadlockException("High contention rate for shared resources of Orphan Scheduled Tasks.");

            try
            {
                actionToTake();
            }
            finally
            {
                Monitor.Exit(SyncRoot);
            }
        }
    }
}
