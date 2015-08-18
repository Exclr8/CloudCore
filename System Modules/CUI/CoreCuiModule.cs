using System.Reflection;
using CloudCore.Core.Modules;
using Microsoft.Owin;

namespace CloudCore.Web
{
    public class CoreCuiModule : CloudCoreModule
    {
        public CoreCuiModule()
            : base("CloudCore.Web", CloudCoreModuleType.Web, Assembly.GetExecutingAssembly())
        {

        }
    }
}
