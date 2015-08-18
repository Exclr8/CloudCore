using System.Reflection;
using CloudCore.Core.Modules;

namespace CloudCore.WebModuleTest
{
    public class CloudCoreWebTestModule : CloudCoreModule
    {
        public CloudCoreWebTestModule()
            : base("CloudCore.WebModuleTest", CloudCoreModuleType.Web, Assembly.GetExecutingAssembly())
        {

        }

    }
}