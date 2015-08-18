using System.Collections.Generic;
using CloudCore.Admin;
using CloudCore.Core.Data;
using CloudCore.Core.Hosting.VirtualFiles;
using CloudCore.Core.Modules;
using CloudCore.Web.Core.Modules;
using CloudCore.WebModuleTest;
using CloudCore.Data;

namespace CloudCore.Web.Core.Tests.Hosting
{
    public class MockModuleHost : IModuleHost
    {
        public CloudCoreResourcePathProvider<EmbeddedResourceVirtualFile> PathProvider { get; private set; }
        private readonly List<CloudCoreModule> modules = new List<CloudCoreModule>();

        public MockModuleHost()
        {
            AddModulesToList();
            ConfigureIocWithAllModules();
            Environment.InitializeModuleHost(this);
        }

        public void ConfigureIocWithAllModules()
        { }

        private void AddModulesToList()
        {
            modules.AddRange(new List<CloudCoreModule>
            {
                new CloudCoreDataModule(),
                new CoreCommonModule(),
                new CoreWebModule(),
                new CoreCuiModule(),
                new CoreAdminModule(),
                new CloudCoreWebTestModule()
            });
        }

        void IModuleHost.RegisterModules()
        {
            foreach (var module in modules)
            {
                Environment.RegisterModule(module);
            }
        }

        void IModuleHost.OnAllModulesRegistered()
        {
            PathProvider = new CloudCoreResourcePathProvider<EmbeddedResourceVirtualFile>();
            PathProvider.LoadAllModuleResources();
        }
    }
}
