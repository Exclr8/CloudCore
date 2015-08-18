using System.Reflection;

namespace CloudCore.Core.Modules
{
    public class CoreCommonModule : CloudCoreModule
    {
        public CoreCommonModule()
            : base("CloudCore.Core", CloudCoreModuleType.Core, Assembly.GetExecutingAssembly())
        {
            
        }
    }
}
