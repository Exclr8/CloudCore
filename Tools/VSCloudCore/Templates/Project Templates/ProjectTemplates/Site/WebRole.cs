using CloudCore.Logging;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace $safeprojectname$.Site
{
    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            StartDiagnosticMonitor();

            return base.OnStart();
        }

        private void StartDiagnosticMonitor()
        {
            if (RoleEnvironment.IsAvailable)
            {
                var config = DiagnosticMonitor.GetDefaultInitialConfiguration();
                config.Logs.ScheduledTransferPeriod = System.TimeSpan.FromMinutes(1.0);
                config.Logs.ScheduledTransferLogLevelFilter = LogLevel.Undefined;
                DiagnosticMonitor.Start("Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString",
                    config);
                Logger.Info("Diagnostics Monitor started", "Initialization");
            }
        }
    }
}
