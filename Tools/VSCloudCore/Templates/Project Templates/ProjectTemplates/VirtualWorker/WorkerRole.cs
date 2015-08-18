using CloudCore.Core.VirtualWorker;

namespace $safeprojectname$.VirtualWorker
{
    public class WorkerRole : Microsoft.WindowsAzure.ServiceRuntime.RoleEntryPoint
    {
        private readonly $safeprojectname$VirtualWorker _virtualWorker = new $safeprojectname$VirtualWorker();

        public override bool OnStart()
        {
            return _virtualWorker.OnStart();
        }

        public override void Run()
        {
            _virtualWorker.Run();
        }

        public override void OnStop()
        {
            _virtualWorker.Stop();
        }
    }
}
