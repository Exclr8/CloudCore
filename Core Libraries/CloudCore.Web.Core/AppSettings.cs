using System.Configuration;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace CloudCore.Web.Core
{
    public class AppSettings
    {
        public static string GetConfiguration(string configurationSettingName, string defaultValue = "")
        {
            try
            {
                if (RoleEnvironment.IsAvailable)
                    return RoleEnvironment.GetConfigurationSettingValue(configurationSettingName);

                return ConfigurationManager.AppSettings[configurationSettingName];
            }
            catch
            {
                return defaultValue;
            }
        }               
    }
}
