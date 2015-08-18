using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CloudCore.VirtualWorker.Exceptions;

namespace CloudCore.VirtualWorker.Threading
{
    public class TaskThreadSafeDataAccess : IThreadSafeDataAccess
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
                throw new DataThreadDeadlockException("High contention rate for shared resources of Normal Scheduled Tasks.");

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
