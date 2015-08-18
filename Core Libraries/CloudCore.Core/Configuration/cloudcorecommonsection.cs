using System.Configuration;
using CloudCore.Configuration.ConfigFile.Elements;
using CloudCore.Core.Configuration.Elements;

namespace CloudCore.Configuration.ConfigFile
{
    public class CloudCoreCommonSection : ConfigurationSection
    {
        [ConfigurationProperty("encrypted", DefaultValue = false, IsRequired = false)]
        public bool Encrypted
        {
            get { return (bool)this["encrypted"]; }
            set { this["encrypted"] = value; }
        }

        [ConfigurationProperty("productSupportContactAddress", DefaultValue = "http://frameworkone.atlassian.net/", IsRequired = false)]
        public string ProductSupportContactAddress
        {
            get
            {
                return this["productSupportContactAddress"].ToString();
            }
            set
            {
                this["productSupportContactAddress"] = value;
            }
        }
      
        [ConfigurationProperty("keys", IsRequired = false)]
        public KeysElement Keys
        {
            get
            {
                return (KeysElement)this["keys"];
            }
            set
            { this["keys"] = value; }
        }

        [ConfigurationProperty("services", IsRequired = false)]
        public ServicesElement Services
        {
            get
            {
                return (ServicesElement)this["services"];
            }
            set
            { this["services"] = value; }
        }

        [ConfigurationProperty("logging", IsRequired = false)]
        public LoggingElement Logging
        {
            get
            {
                var loggingConfig = (this["logging"] as LoggingElement);

                return loggingConfig ?? new LoggingElement();
            }
            set
            {
                this["logging"] = value;
            }
        }

        [ConfigurationProperty("location", IsRequired = false)]
        public LocationElement Location
        {
            get 
            {
                var locationConfig = (this["location"] as LocationElement);
                return locationConfig;
            }
            set 
            { 
                this["location"] = value; 
            }
        }

        [ConfigurationProperty("storage", IsRequired = false)]
        public StorageElement Storage
        {
            get
            {
                return (StorageElement)this["storage"];
            }
            set { this["storage"] = value; }
        }

        [ConfigurationProperty("serviceBus", IsRequired = false)]
        public ServiceBusElement ServiceBus
        {
            get
            {
                return (ServiceBusElement)this["serviceBus"];
            }
            set { this["serviceBus"] = value; }
        }

        [ConfigurationProperty("exceptionRecipients", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ExceptionRecipientCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public ExceptionRecipientCollection ExceptionRecipients
        {
            get
            {
                return (ExceptionRecipientCollection)base["exceptionRecipients"];
            }
        }
    }
}
