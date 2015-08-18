using System.Configuration;

namespace CloudCore.Configuration.ConfigFile
{
    public class LoginActionElement : ConfigurationElement
    {
        [ConfigurationProperty("area", DefaultValue = "CUI", IsRequired = false)]
        public string Area
        {
            get
            {
                return this["area"].ToString();
            }
            set
            {
                this["area"] = value;
            }
        }

        [ConfigurationProperty("controller", DefaultValue = "Main", IsRequired = false)]
        public string Controller
        {
            get
            {
                return this["controller"].ToString();
            }
            set
            {
                this["controller"] = value;
            }
        }

        [ConfigurationProperty("action", DefaultValue = "Index", IsRequired = false)]
        public string Action
        {
            get { return (string)this["action"]; }
            set { this["action"] = value; }
        }

        [ConfigurationProperty("defaultNamespace", DefaultValue = WebSettingsElement.DefaultControllerNamespace, IsRequired = false)]
        public string Namespace
        {
            get { return (string)this["defaultNamespace"]; }
            set { this["defaultNamespace"] = value; }
        }
    }
}
