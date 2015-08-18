
using System;

namespace CloudCore.VirtualWorker.ScheduledTasks
{
    public abstract class ScheduledTask : IScheduledTask, IDisposable
    {
        public abstract void Execute();
        public virtual void Dispose() { }
    }
}
