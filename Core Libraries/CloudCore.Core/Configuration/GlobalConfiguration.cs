using System.Configuration;

namespace CloudCore.Configuration.ConfigFile
{
    public static class ReadConfig
    {
        public static CloudCoreWebSection SettingsOnWebApplication
        {
            get { return ConfigurationManager.GetSection("cloudcore") as CloudCoreWebSection; }
        }

        public static CloudCoreWorkerSection SettingsOnWorkerApplication
        {
            get {return ConfigurationManager.GetSection("cloudcore") as CloudCoreWorkerSection; }
        }

        public static CloudCoreCommonSection CommonCloudCoreApplicationSettings
        {
            get { return ConfigurationManager.GetSection("cloudcore") as CloudCoreCommonSection; }
        }

        public static string ConnectionString
        {
            get
            {
                var config = ConfigurationManager.ConnectionStrings["cloudcore"];
                return config == null ? string.Empty : config.ConnectionString;
            }
        }
         
        public const int VirtualWorkerUserId = -99;
        public const int SystemAccountUserId = 0;
    }
}
