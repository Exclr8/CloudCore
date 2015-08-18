using System;
using System.Collections.Generic;
using CloudCore.VirtualWorker.Threading;

namespace CloudCore.VirtualWorker.Engine.DashboardTask
{
    public class DashboardTaskOperationContext : WorkerOperationContext
    {
        public readonly Dictionary<string, Type> DashboardTaskClassTypes;

        public DashboardTaskOperationContext(int sleepIntervalTimeInSeconds, string loggingCategory, IThreadSafeDataAccess threadSafeDataAccess,
            ExitStrategy exitStrategy, Dictionary<string, Type> dashboardTaskClassTypes, Action onEngineRevolutionCallBack = null, Action onEngineRevolutionUnsafeCallBack = null) 
            : base(sleepIntervalTimeInSeconds, loggingCategory, threadSafeDataAccess, exitStrategy, onEngineRevolutionCallBack)
        {
            DashboardTaskClassTypes = dashboardTaskClassTypes;
        }
    }
}
