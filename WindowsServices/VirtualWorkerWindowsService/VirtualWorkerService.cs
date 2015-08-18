using System.ServiceProcess;
using System.Timers;
using CloudCore.VirtualWorker;
using CloudCore.VirtualWorker.WindowsService;

namespace CloudCore.Core.VirtualWorker.WindowsService
{
    public partial class VirtualWorkerService : ServiceBase
    {
        private readonly Worker _worker;

        public VirtualWorkerService()
        {
            InitializeComponent();
            _worker = new BasicWindowsWorker();
        }

        private Timer _timer;
        protected override void OnStart(string[] args)
        {
            const int timerDelay = 10000; 
            _timer = new Timer(timerDelay);
            _timer.Elapsed += timer_Elapsed;
            _worker.OnStart();
            _timer.Start();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            _worker.Run();
        }

        protected override void OnStop()
        {
            _worker.Stop();
        }
    }
}
