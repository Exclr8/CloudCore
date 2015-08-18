using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace CloudCore.Core.VirtualWorker.WindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            if (Debugger.IsAttached)
            {
                Console.WriteLine("Debugging Started");
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
                    { 
                        new VirtualWorkerService() 
                    };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
