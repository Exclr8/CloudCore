using System;
using System.Collections.Generic;
using System.Threading;
using CloudCore.VirtualWorker.Threading;

namespace CloudCore.VirtualWorker.Engine
{
    public abstract class WorkerOperation
    {
        protected WorkerOperationContext OperationContext { get; private set; }

        protected WorkerOperation(WorkerOperationContext context)
        {
            OperationContext = context;
        }

        public ExitStrategy ExitStrategy
        {
            get
            {
                return OperationContext.ExitStrategy;
            }
        }

        public abstract IEnumerable<WorkerTask> CreateTaskThreads();

        protected void DoCallback()
        {
            if (OperationContext.EngineRevolutionCallBack != null)
            {
                OperationContext.EngineRevolutionCallBack.Invoke();
            }
        }
#if DEBUG

        protected void DoUnsafeCallback()
        {
            if (OperationContext.EngineRevolutionUnsafeCallback != null)
                OperationContext.EngineRevolutionUnsafeCallback.Invoke();
        }
#endif

        public void Sleep(int seconds)
        {
            var delayedUntil = DateTime.Now.AddSeconds(seconds);
            while (DateTime.Now < delayedUntil && !ExitStrategy.Quitting)
            {
                Thread.Sleep(100);
            }
        }
    }
}
