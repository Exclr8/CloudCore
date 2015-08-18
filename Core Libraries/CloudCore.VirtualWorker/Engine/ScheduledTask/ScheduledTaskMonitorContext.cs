using System;
using System.Collections.Generic;
using CloudCore.VirtualWorker.Threading;

namespace CloudCore.VirtualWorker.Engine.ScheduledTask
{
    public class ScheduledTaskMonitorContext : WorkerOperationContext
    {
        public Dictionary<string, Type> ScheduledTaskTypes { get; private set; }

        public ScheduledTaskMonitorContext(int sleepIntervalTimeInSeconds, Dictionary<string, Type> scheduledTaskTypes, string loggingCategory, 
                                           IThreadSafeDataAccess threadSafeDataAccess, ExitStrategy exitStrategy, Action onEngineRevolutionCallBack = null)
            : base(sleepIntervalTimeInSeconds, loggingCategory, threadSafeDataAccess, exitStrategy, onEngineRevolutionCallBack)
        {
            ScheduledTaskTypes = scheduledTaskTypes;
        }
    }
}
