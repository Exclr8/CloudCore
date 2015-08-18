using System.Configuration;

namespace CloudCore.Configuration.ConfigFile.Elements
{

    public class CloudCoreApiSection : ConfigurationSection
    {
        [ConfigurationProperty("apiSettings", IsRequired = false)]
        public ApiSettingsElement Api
        {
            get
            {
                return (ApiSettingsElement)this["apiSettings"];
            }
            set
            { this["apiSettings"] = value; }
        }

    }
}
