using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace CloudCore.Core.Configuration.Elements
{
    public class RecipientElement : ConfigurationElement
    {
        [ConfigurationProperty("recipientAddress", IsRequired = false)]
        public string RecipientAddress
        {
            get
            {
                return this["recipientAddress"].ToString();
            }
            set
            {
                this["recipientAddress"] = value;
            }
        }
    }
}
