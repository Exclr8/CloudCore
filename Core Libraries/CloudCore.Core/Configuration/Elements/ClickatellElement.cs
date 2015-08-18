using System.Configuration;

namespace CloudCore.Configuration.ConfigFile.Elements
{
    public class ClickatellElement : ConfigurationElement
    {

        [ConfigurationProperty("username", DefaultValue = "", IsRequired = false)]
        public string Username
        {
            get
            {
                return (string)this["username"];
            }
            set
            {
                this["username"] = value;
            }
        }

        [ConfigurationProperty("password", DefaultValue = "", IsRequired = false)]
        public string Password
        {
            get
            {
                return (string)this["password"];
            }
            set
            {
                this["password"] = value;
            }
        }

        [ConfigurationProperty("apiKey", DefaultValue = "", IsRequired = false)]
        public string APIKey
        {
            get
            {
                return this["apiKey"].ToString();
            }
            set
            {
                this["apiKey"] = value;
            }
        }

        

    }
}
