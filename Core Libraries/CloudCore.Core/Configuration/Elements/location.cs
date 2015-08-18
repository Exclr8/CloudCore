using System.Configuration;
using CloudCore.Configuration.ConfigFile.Location;

namespace CloudCore.Configuration.ConfigFile.Elements
{
    public class LocationElement : ConfigurationElement, ILocationConfig
    {
        [ConfigurationProperty("latitude", DefaultValue = "0", IsRequired = false)]
        public decimal Latitude
        {
            get
            {
                decimal latitude;
                bool parsed = decimal.TryParse(this["latitude"].ToString(), out latitude);

                if (parsed)
                    return latitude;

                return 0;
            }
        }

        [ConfigurationProperty("longitude", DefaultValue = "0", IsRequired = false)]
        public decimal Longitude
        {
            get
            {
                decimal longitude;
                bool parsed = decimal.TryParse(this["longitude"].ToString(), out longitude);
                
                if (parsed)
                    return longitude;

                return 0;
            }
        }

        [ConfigurationProperty("radiusInMeters", DefaultValue = "0", IsRequired = false)]
        public int RadiusInMeters
        {
            get
            {
                int radiusInmeters;
                bool parsed = int.TryParse(this["radiusInMeters"].ToString(), out radiusInmeters);

                if (parsed)
                    return radiusInmeters;

                return 0;
            }
        }

        [ConfigurationProperty("locationAware", DefaultValue = "false", IsRequired = false)]
        public bool LocationAware 
        {
            get
            {
                bool locationAware;
                bool parsed = bool.TryParse(this["locationAware"].ToString(), out locationAware);

                if (parsed)
                    return locationAware;

                return false;
            }
        }
    }
}
