using System;
using System.Configuration;

namespace CloudCore.Configuration.ConfigFile.Elements
{
    public class ApiSettingsElement : ConfigurationElement
    {
        private const short DefaultTokenExpiryValue = 2;

        [ConfigurationProperty("tokenExpiryHours", DefaultValue = DefaultTokenExpiryValue, IsRequired = false)]
        public short TokenExpiry
        {
            get
            {
                short expiry;
                if (Int16.TryParse(this["tokenExpiryHours"].ToString(), out expiry))
                {
                    if (expiry > 0 && expiry < 6)
                    {
                        return expiry;
                    }
                    throw new Exception("Token Expiry must be an integer value ranging from 1 to 5, as hours");
                }
                return DefaultTokenExpiryValue;
            }
            set
            {
                this["tokenExpiryHours"] = value;
            }
        }
    }
}
