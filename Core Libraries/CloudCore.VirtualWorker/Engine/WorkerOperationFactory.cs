using System;
using System.Collections.Generic;

namespace CloudCore.VirtualWorker.Engine
{
    public static class WorkerOperationFactory<TEngineClassType> 
        where TEngineClassType : WorkerOperation 
    {
        public static IEnumerable<WorkerTask> Construct(WorkerOperationContext context)
        {
            var engine = (TEngineClassType)Activator.CreateInstance(typeof(TEngineClassType), context);
            var tasks = engine.CreateTaskThreads();
            return tasks;
        }
    }
}
