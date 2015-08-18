using System.Collections.Generic;
using CloudCore.Core.Modules;
using CloudCore.VirtualWorker;
using CloudCore.Data;

namespace CloudCore.Deployment.VirtualWorker
{
    public class BasicVirtualWorker : Worker
    {
        protected override IEnumerable<CloudCoreModule> RegisterWorkerModules()
        {
            return new List<CloudCoreModule>();
        }
    }
}
