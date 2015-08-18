using CloudCore.Configuration.SettingsProviders;
using Frameworkone.Domain;
using Frameworkone.ThirdParty.Clickatell;

namespace Clickatell.Database.Tests
{
    public class ClickatellDatabaseSettings : DbSettingsProvider<ClickatellSettings>, IClickatellSettingsProvider
    {
        public ClickatellDatabaseSettings(IRepository repository) : base(repository) { }

        public ClickatellSettings GetSettings()
        {
            return Load();
        }
    }
}
