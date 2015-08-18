using System;
using System.Collections.Generic;
using CloudCore.Configuration.ConfigFile.Location;
using CloudCore.VirtualWorker.Threading;

namespace CloudCore.VirtualWorker.Engine.Workflow
{
    public class WorkflowContext : WorkerOperationContext
    {
        public int ParallelThreadCount { get; private set; }

        public WorkflowContext(int sleepIntervalTimeInSeconds, 
                               ILocationConfig locationConfig, 
                               Dictionary<string, Type> activityTypes,
                               string loggingCategory,
                               IThreadSafeDataAccess threadSafeDataAccess,
                               ExitStrategy exitStrategy,
                               Action onEngineRevolutionCallBack = null,
                               int parallelThreadCount = -1)

            : base(sleepIntervalTimeInSeconds, loggingCategory, threadSafeDataAccess, exitStrategy, onEngineRevolutionCallBack)
        {
            LocationConfig = locationConfig;
            ActivityTypes = activityTypes;
            ParallelThreadCount = parallelThreadCount;
        }

#if DEBUG
        public WorkflowContext(int sleepIntervalTimeInSeconds,
                               ILocationConfig locationConfig,
                               Dictionary<string, Type> activityTypes,
                               string loggingCategory,
                               IThreadSafeDataAccess threadSafeDataAccess,
                               ExitStrategy exitStrategy,
                               Action onEngineRevolutionCallBack = null,
                               Action onEngineRevolutionUnsafeCallBack = null,
                               int parallelThreadCount = -1)

            : base(sleepIntervalTimeInSeconds, loggingCategory, threadSafeDataAccess, exitStrategy, onEngineRevolutionCallBack, onEngineRevolutionUnsafeCallBack)
        {
            LocationConfig = locationConfig;
            ActivityTypes = activityTypes;
            ParallelThreadCount = parallelThreadCount;
        }

#endif
        public Dictionary<string, Type> ActivityTypes { get; private set; }

        private ILocationConfig _locationConfig;
        public ILocationConfig LocationConfig
        {
            get { return _locationConfig ?? (_locationConfig = new LocationConfig()); }

            private set
            {
                _locationConfig = value;
            }
        }
    }
}
