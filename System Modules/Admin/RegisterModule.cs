using System.Reflection;
using CloudCore.Core.Modules;

namespace CloudCore.Admin
{
    public class CoreAdminModule : CloudCoreModule
    {
        public CoreAdminModule()
            : base("CloudCore.Admin", CloudCoreModuleType.Web, Assembly.GetExecutingAssembly())
        {
        }
    }
}