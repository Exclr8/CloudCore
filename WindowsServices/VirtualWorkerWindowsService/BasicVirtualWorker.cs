using System.Collections.Generic;
using CloudCore.Core.Modules;
using CloudCore.Logging;
using CloudCore.Logging.EventLog;

namespace CloudCore.VirtualWorker.WindowsService
{
    public class BasicWindowsWorker : Worker
    {
        protected override IEnumerable<CloudCoreModule> RegisterWorkerModules()
        {
            return new List<CloudCoreModule>
            {
                
            };
        }

        protected override ILogger GetLogger()
        {
            return new EventLogLogger();
        }
    }
}
