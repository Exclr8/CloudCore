using System;
using CloudCore.VirtualWorker.Threading;

namespace CloudCore.VirtualWorker.Engine
{
    public class WorkerOperationContext 
    {
        public int SleepIntervalTimeInSeconds { get; private set; }
        public string LoggingCategory { get; private set; }
        public Action EngineRevolutionCallBack { get; private set; }
        public IThreadSafeDataAccess ThreadSafeDataAccess { get; private set; }
#if DEBUG
        public Action  EngineRevolutionUnsafeCallback { get; private set; }

        public WorkerOperationContext(int sleepIntervalTimeInSeconds, string loggingCategory, IThreadSafeDataAccess threadSafeDataAccess, ExitStrategy exitStrategy, Action onEngineRevolutionCallBack = null, Action onEngineRevolutionUnsafeCallBack = null)
#else
        public WorkerOperationContext(int sleepIntervalTimeInSeconds, string loggingCategory, IThreadSafeDataAccess threadSafeDataAccess, ExitStrategy exitStrategy, Action onEngineRevolutionCallBack = null)
#endif
        {
            SleepIntervalTimeInSeconds = sleepIntervalTimeInSeconds;
            LoggingCategory = loggingCategory;
            EngineRevolutionCallBack = onEngineRevolutionCallBack;
            ThreadSafeDataAccess = threadSafeDataAccess;
            this.ExitStrategy = exitStrategy;
#if DEBUG
            EngineRevolutionUnsafeCallback = onEngineRevolutionUnsafeCallBack;
#endif
        }

        public ExitStrategy ExitStrategy { get; private set; }
    }
}
