using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace CloudCore.Core.Configuration.Elements
{
    public class ServiceBusElement : ConfigurationElement
    {

        [ConfigurationProperty("serviceBusConnectionString", IsRequired = false)]
        public string ServiceBusConnectionString
        {
            get
            {
                return this["serviceBusConnectionString"].ToString();
            }
            set
            {
                this["serviceBusConnectionString"] = value;
            }
        }

        public bool IsServiceBusDefined()
        {
            if (RoleEnvironment.IsEmulated)
                return true;

            return !String.IsNullOrWhiteSpace(ServiceBusConnectionString);
        }
    }
}
