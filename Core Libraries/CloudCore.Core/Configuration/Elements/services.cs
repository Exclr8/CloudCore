using System.Configuration;

namespace CloudCore.Configuration.ConfigFile.Elements
{
    public class ServicesElement : ConfigurationElement
    {
        [ConfigurationProperty("clickatell", IsRequired = false)]
        public ClickatellElement Clickatell
        {
            get
            {
                return (ClickatellElement)this["clickatell"];
            }
            set
            { this["clickatell"] = value; }
        }


        [ConfigurationProperty("postage", IsRequired = false)]
        public PostageElement Postage
        {
            get
            {
                return (PostageElement)this["postage"];
            }
            set
            { this["postage"] = value; }
        }
    }
}
