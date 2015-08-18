using System.Configuration;
using CloudCore.Configuration.ConfigFile.Elements;
using CloudCore.Configuration.ConfigFile.Validators;
using CloudCore.Core.Configuration.Elements;

namespace CloudCore.Configuration.ConfigFile
{
    public class WebSettingsElement : ConfigurationElement
    {
        public const string DefaultControllerNamespace = "CloudCore.Web.Controllers";
        public const string DefaultJQuerySource = "internal";

        [ConfigurationProperty("siteName", DefaultValue = "CloudCore", IsRequired = false)]
        public string SiteName
        {
            get
            {
                return this["siteName"].ToString();
            }
            set
            {
                this["siteName"] = value;
            }
        }

        [ConfigurationProperty("siteVersion", DefaultValue = "1.0.0.0", IsRequired = false)]
        public string SiteVersion
        {
            get
            {
                return this["siteVersion"].ToString();
            }
            set
            {
                this["siteVersion"] = value;
            }
        }

        [ConfigurationProperty("defaultAction", IsRequired = false)]
        public DefaultActionElement DefaultAction
        {
            get
            {
                return (DefaultActionElement)this["defaultAction"];
            }
            set
            { this["defaultAction"] = value; }
        }


        [ConfigurationProperty("loginAction", IsRequired = false)]
        public LoginActionElement LoginAction
        {
            get
            {
                return (LoginActionElement)this["loginAction"];
            }
            set
            { this["loginAction"] = value; }
        }

        [ConfigurationProperty("redirectToHttps", DefaultValue = false, IsRequired = false)]
        public bool RedirectToHttps
        {
            get
            {
                return (bool)this["redirectToHttps"];
            }
            set
            {
                this["redirectToHttps"] = value;
            }
        }

        [ConfigurationProperty("selfSignedRSA", DefaultValue = true, IsRequired = false)]
        public bool SelfSignedRSA
        {
            get
            {
                return (bool)this["selfSignedRSA"];
            }
            set
            {
                this["selfSignedRSA"] = value;
            }
        }

        [ConfigurationProperty("jQuerySource", DefaultValue = DefaultJQuerySource, IsRequired = false)]
        [JquerySourceValidator()]
        public string JQuerySource
        {
            get
            {
                return (string)this["jQuerySource"];
            }
            set
            {
                this["jQuerySource"] = value;
            }
        }

        [ConfigurationProperty("userSessionTimeout", IsRequired = false)]
        public UserSessionTimeoutElement UserSessionTimeout
        {
            get { return (UserSessionTimeoutElement)this["userSessionTimeout"]; }
            set { this["userSessionTimeout"] = value; }
        }
    }
}
