using System.Collections.Generic;
namespace CloudCore.Core.Modules
{
    public interface IModuleHost
    {
        List<CloudCoreModule> RegisterModules();

        void OnAllModulesRegistered(List<CloudCoreModule> loadedModules);
    } 
}
