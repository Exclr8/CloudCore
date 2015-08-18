using CloudCore.Domain.Workflow;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Reflection;

namespace CloudCore.Core.Modules
{
    public interface ICloudCoreModule
    {
        string DefaultNamespace { get; }
        CloudCoreModuleType ModuleType { get; }
        Assembly Assembly { get; }
        void OnRegister();
        void AdditionalIoCConfiguration(IUnityContainer container);
        IEnumerable<ITaskListQuery> GetCustomQueryList();
    }
}