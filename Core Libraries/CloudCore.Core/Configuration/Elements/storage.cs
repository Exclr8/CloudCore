using System.Configuration;

namespace CloudCore.Configuration.ConfigFile.Elements
{
    public class StorageElement : ConfigurationElement
    {

        [ConfigurationProperty("storageConnectionString", DefaultValue = "UseDevelopmentStorage=true;DevelopmentStorageProxyUri=http://127.0.0.1", IsRequired = false)]
        public string StorageConnectionString
        {
            get
            {
                return this["storageConnectionString"].ToString();
            }
            set
            {
                this["storageConnectionString"] = value;
            }
        }
    }
}
