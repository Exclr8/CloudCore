using System.Diagnostics;
using System.Reflection;
using CloudCore.Core.Modules;

namespace CloudCore.ProcessTest
{
    public class CloudCoreProcessTestModule : CloudCoreModule
    {
        public CloudCoreProcessTestModule()
            : base("CloudCore.ProcessTest", CloudCoreModuleType.Process, Assembly.GetExecutingAssembly())
        {

        }
    }
}