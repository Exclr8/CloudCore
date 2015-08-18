using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;

namespace CloudCore.Core.VirtualWorker.WindowsService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void virtualWorkerServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            if (!EventLog.SourceExists(CloudCore.Logging.Resources.EventLogSourceName))
                EventLog.CreateEventSource(CloudCore.Logging.Resources.EventLogSourceName, CloudCore.Logging.Resources.EventLogName);
        }
    }
}
