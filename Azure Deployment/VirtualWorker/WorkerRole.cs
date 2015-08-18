namespace CloudCore.Deployment.VirtualWorker
{
    public class TestWorker : Microsoft.WindowsAzure.ServiceRuntime.RoleEntryPoint
    {
        private readonly BasicVirtualWorker _worker = new BasicVirtualWorker();
      
        public override bool OnStart()
        {
            return _worker.OnStart();
        }

        public override void Run()
        {
            _worker.Run();
        }

        public override void OnStop()
        {
            _worker.Stop();
        }
    }
}
