using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCore.Core.Configuration.Elements
{
    public class UserSessionTimeoutElement : ConfigurationElement
    {
        [ConfigurationProperty("timeoutValueInMinutes", IsRequired = false, DefaultValue = 120)]
        public int TimeoutValueInMinutes
        {
            get
            {
                int intervalInMinutes;
                if (!Int32.TryParse(this["timeoutValueInMinutes"].ToString(), out intervalInMinutes))
                    throw new InvalidCastException(String.Format("Configuration UserSessionTimeoutElement cannot convert timeoutValueinMinutes from {0} to an interger.", this["timeoutValueInMinutes"].ToString()));

                return intervalInMinutes;
            }
            set
            {
                this["timeoutValueInMinutes"] = value;
            }
        }
    }
}
