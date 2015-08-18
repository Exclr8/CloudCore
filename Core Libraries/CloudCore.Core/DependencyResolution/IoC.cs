using System;
using System.Collections.Generic;
using System.Linq;
using CloudCore.Configuration.ConfigFile;
using CloudCore.Core.Modules;
using Frameworkone.ThirdParty.Clickatell;
using Frameworkone.ThirdParty.PostageApp;
using Microsoft.Practices.Unity;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace CloudCore.Core.DependencyResolution
{
    public sealed class IoC
    {
        private static IUnityContainer container;

        public static IUnityContainer Container
        {
            get { return container; }
        }
        public static void Initialize()
        {
            container = new UnityContainer();
        }

        public static void AdditionalConfiguration(CloudCoreModule module)
        {
            module.AdditionalIoCConfiguration(container);
        }

        

    }

    public static class UnityExtensions
    {
        //internal static void Scan(this IUnityContainer container, IEnumerable<Type> assemblyTypes, Type type)
        //{
        //    var implementations = assemblyTypes.Where(x => x.IsAssignableToGenericType(type) && !x.IsInterface);

        //    foreach (var implementation in implementations)
        //    {
        //        container.RegisterType(type, implementation, implementation.Name);
        //    }
        //}

        //internal static bool IsAssignableToGenericType(this Type givenType, Type genericType)
        //{
        //    var interfaceTypes = givenType.GetInterfaces();

        //    if (interfaceTypes.Any(it => it.IsGenericType && it.GetGenericTypeDefinition() == genericType))
        //    {
        //        return true;
        //    }

        //    if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
        //        return true;

        //    var baseType = givenType.BaseType;
        //    return baseType != null && IsAssignableToGenericType(baseType, genericType);
        //}

    }
}
