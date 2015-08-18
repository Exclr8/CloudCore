using System.Configuration;

namespace CloudCore.Configuration.WebConfigElements
{
 
    public class CloudCoreSection : ConfigurationSection
    {
      
        [ConfigurationProperty("application", IsRequired = true)]
        public ApplicationElement Application
        {
            get
            {
                return (ApplicationElement)this["application"];
            }
            set
            { this["application"] = value; }
        }

        [ConfigurationProperty("internalUI", IsRequired = false)]
        public InternalUiElement InternalUi
        {
            get
            {
                return (InternalUiElement)this["internalUI"];
            }
            set
            { this["internalUI"] = value; }
        }

        [ConfigurationProperty("defaultAction", IsRequired = true)]
        public DefaultActionElement DefaultAction
        {
            get
            {
                return (DefaultActionElement)this["defaultAction"];
            }
            set
            { this["defaultAction"] = value; }
        }

        [ConfigurationProperty("database", IsRequired = true)]
        public DatabaseElement Database
        {
            get
            {
                return (DatabaseElement)this["database"];
            }
            set
            { this["database"] = value; }
        }

        [ConfigurationProperty("cache", IsRequired = false)]
        public CacheElement Cache
        {
            get
            {
                return (CacheElement)this["cache"];
            }
            set
            { this["cache"] = value; }
        }
        
        [ConfigurationProperty("encrypted", DefaultValue = false, IsRequired = true)]
        public bool Encrypted
        {
            get { return (bool)this["encrypted"]; }
            set { this["encrypted"] = value; }
        }

        [ConfigurationProperty("runtime", DefaultValue = true, IsRequired = false)]
        public bool Runtime
        {
            get { return (bool)this["runtime"]; }
            set { this["runtime"] = value; }
        }

        [ConfigurationProperty("licenceKey", DefaultValue = "", IsRequired = false)]
        public string LicenceKey
        {
            get
            {
                return this["licenceKey"].ToString();
            }
            set
            {
                this["licenceKey"] = value;
            }
        }

        [ConfigurationProperty("ApplicationKey",IsRequired= true)]
        public string ApplicationKey
        {
            get 
            {
                return this["ApplicationKey"].ToString();
            }
        }

        [ConfigurationProperty("smsService", IsRequired = false)]
        public SMSServiceElement SmsService
        {
            get
            {
                return (SMSServiceElement)this["smsService"];
            }
            set
            { this["smsService"] = value; }
        }


        [ConfigurationProperty("webService", IsRequired = false)]
        public WebServiceElement WebService
        {
            get
            {
                return (WebServiceElement)this["webService"];
            }
            set
            { this["webService"] = value; }
        }


        [ConfigurationProperty("mailService", IsRequired = false)]
        public MailServiceElement MailService
        {
            get
            {
                return (MailServiceElement)this["mailService"];
            }
            set
            { this["mailService"] = value; }
        }
     
    }
}
