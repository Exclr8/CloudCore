using System.Reflection;
using CloudCore.Core.Modules;

// ReSharper disable once CheckNamespace
namespace CloudCore.Web.Core.Modules
{
    public class CoreWebModule : CloudCoreModule
    {
        public CoreWebModule()
            : base("CloudCore.Web", CloudCoreModuleType.Core, Assembly.GetExecutingAssembly())
        {
            
        }
    }
}
