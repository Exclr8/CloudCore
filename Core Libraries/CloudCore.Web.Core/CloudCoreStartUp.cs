using System;
using CloudCore.Configuration.ConfigFile;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.WindowsAzure.ServiceRuntime;
using Owin;

[assembly: OwinStartup(typeof(CloudCore.Web.Core.CloudCoreStartUp))]

namespace CloudCore.Web.Core
{
    public class CloudCoreStartUp
    {
        public void Configuration(IAppBuilder app)
        {
            //Use ServiceBus for deployments and SqlServer for debug.
            //Azure does not support SqlServer backplane. 
            //Emulator does not support ServiceBus backplane.
            if (RoleEnvironment.IsEmulated)
            {
                GlobalHost.DependencyResolver.UseSqlServer(ReadConfig.ConnectionString);
            }
            else
            {
                if (ReadConfig.CommonCloudCoreApplicationSettings.ServiceBus.IsServiceBusDefined())
                {
                    GlobalHost.DependencyResolver.UseServiceBus(ReadConfig.CommonCloudCoreApplicationSettings.ServiceBus.ServiceBusConnectionString, "CloudCore");    
                }
            }
                
            app.MapSignalR();
        }
    }
}