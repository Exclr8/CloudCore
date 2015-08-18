using CloudCore.Modules;
using System.Reflection;

namespace CloudCore.Modules
{
    public static class CoreWebModule
    {
        public static void Register()
        {
            ModuleEnvironment.RegisterModule(new CloudCoreModule("CloudCore", CloudCoreModuleType.Web, Assembly.GetExecutingAssembly()));
        }
    }
}
