using System;
using System.Reflection;
using CloudCore.Configuration.ConfigFile;
using CloudCore.Core.Modules;
using Microsoft.Practices.Unity;

namespace CloudCore.Data
{
    public class CloudCoreDataModule : CloudCoreModule
    {
        public CloudCoreDataModule()
            : base("CloudCore.Core.Data", CloudCoreModuleType.Data, Assembly.GetExecutingAssembly())
        {
        }

        public override void AdditionalIoCConfiguration(IUnityContainer container)
        {
            ThrowIfConnectionStringNotDefined();

        //    container.RegisterType<IDataProvider, CloudCoreDB>(new InjectionConstructor());
            base.AdditionalIoCConfiguration(container);
        }

        private void ThrowIfConnectionStringNotDefined()
        {
            if (string.IsNullOrEmpty(ReadConfig.ConnectionString))
                throw new Exception(@"You are missing the ""cloudcore"" Connectionstring within your config file.");
        }
    }
}
