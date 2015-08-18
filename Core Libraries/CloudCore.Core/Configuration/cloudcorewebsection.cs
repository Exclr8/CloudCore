using System.Configuration;
using CloudCore.Configuration.ConfigFile.Elements;

namespace CloudCore.Configuration.ConfigFile
{
    public class CloudCoreWebSection : CloudCoreCommonSection
    {
        [ConfigurationProperty("webSettings", IsRequired = false)]
        public WebSettingsElement WebSettings
        {
            get
            {
                return (WebSettingsElement)this["webSettings"];
            }
            set
            { this["webSettings"] = value; }
        }

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
