using System;

namespace CloudCore.VirtualWorker.Threading
{
    public interface IThreadSafeDataAccess
    {
        object SyncRoot { get; }
        void DataAccessOperation(Action actionToTake);
    }
}
