using System.Configuration;

namespace CloudCore.Configuration.ConfigFile.Elements
{
    public class KeysElement : ConfigurationElement
    {
        [ConfigurationProperty("applicationKey", DefaultValue = "11000000 - 0000 - 0000 - 0000 - 000000000001", IsRequired = false)]
        public string ApplicationKey
        {
            get
            {
                return this["applicationKey"].ToString();
            }
        }

        [ConfigurationProperty("encryptionKey", DefaultValue = "4566783456788904", IsRequired = false)]
        public string EncryptionKey
        {
            get
            {
                return this["encryptionKey"].ToString();
            }
            set
            {
                this["encryptionKey"] = value;
            }
        }
    }
}
