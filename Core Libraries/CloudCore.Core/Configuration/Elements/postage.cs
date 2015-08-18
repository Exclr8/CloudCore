using System.Configuration;

namespace CloudCore.Configuration.ConfigFile.Elements
{
    public class PostageElement : ConfigurationElement
    {
        [ConfigurationProperty("apiKey", DefaultValue = "", IsRequired = false)]
        public string ApiKey
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

        [ConfigurationProperty("defaultfromaddress", DefaultValue = "", IsRequired = false)]
        public string DefaultFromAddress
        {
            get
            {
                return this["defaultfromaddress"].ToString();
            }
            set
            {
                this["defaultfromaddress"] = value;
            }
        }
    }
}
