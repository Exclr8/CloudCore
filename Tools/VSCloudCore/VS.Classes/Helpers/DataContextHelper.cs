using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;

namespace CloudCore.VSExtension.Classes.Helpers
{
    public class DBContextReference
    {
        public Assembly AssemblyReference { get; set; }
        public Type DBContextClass { get; set; }
        public string FullPath { get; set; }

    }

    public class DBContextReferenceList : List<DBContextReference> { }

    public class DataContextHelper
    {
        private static List<LoadedAssembly> _LoadedAssemblies = new List<LoadedAssembly>();

        public static void UnloadDataContextsFromMemory()
        {
            while (_LoadedAssemblies.Count > 0)
            {
                LoadedAssembly loadedAssembly = _LoadedAssemblies[0];

                string tempAppDomainName = loadedAssembly.Domain.FriendlyName;

                AppDomain.Unload(loadedAssembly.Domain);
                loadedAssembly.Domain = null;
                loadedAssembly.Module = null;
                _LoadedAssemblies.RemoveAt(0);
            }
        }

        public static DBContextReferenceList GetAllDBContexts()
        {
            List<string> referencedAssemblyPaths = DTEWrapper.GetAllReferencesEx();
            DBContextReferenceList dbcList = new DBContextReferenceList();

            try
            {
                referencedAssemblyPaths = IgnoreNetFrameworkLibraries(referencedAssemblyPaths);
                UnloadDataContextsFromMemory();
                
                foreach (string referencedAssemblyFile in referencedAssemblyPaths)
                {
                    LoadedAssembly loadedAssembly = AssemblyLoader.Load(referencedAssemblyFile);
                    _LoadedAssemblies.Add(loadedAssembly);

                    try
                    {
                        Assembly module = loadedAssembly.Module;

                        var classes = ( from  type in module.GetTypes()
                                        where type.IsClass 
                                              && !type.IsAbstract 
                                              && type.BaseType.IsSubclassOf(typeof(DataContext))
                                        select type).ToList();

                        foreach (Type dbcontextitem in classes)
                        {
                            if (!dbcList.Exists(r => r.AssemblyReference.FullName.Equals(module.FullName)))
                            {
                                dbcList.Add(new DBContextReference() { AssemblyReference = module, DBContextClass = dbcontextitem, FullPath = referencedAssemblyFile });
                            }
                        }
                    }
                    catch
                    {
                        // weird loader exception for types
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return dbcList;
        }

        private static List<string> IgnoreNetFrameworkLibraries(List<string> referencedAssemblyPaths)
        {
            referencedAssemblyPaths.RemoveAll(r => r.ToLower().Contains("\\mscorlib."));
            referencedAssemblyPaths.RemoveAll(r => r.ToLower().Contains("\\system.")); // remove system libs
            referencedAssemblyPaths.RemoveAll(r => r.ToLower().Contains("\\microsoft.")); // remove microsoft libs
            referencedAssemblyPaths = referencedAssemblyPaths.Select(r => r.ToLower()).Where(r => r != "").Distinct().ToList();
            return referencedAssemblyPaths;
        }

        public static List<MethodInfo> getProcedures(Type dbContext)
        {
            List<MethodInfo> methodInfoList = new List<MethodInfo>();

            var contextMethods = dbContext.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                .Where(a => a.GetCustomAttributes(typeof(FunctionAttribute), false) != null).ToList()
                .Where(a => (a.ReturnType.IsPublic && !a.ReturnType.IsSealed) || (a.ReturnType.IsPublic && a.ReturnType.IsValueType)).ToList();

            foreach (MethodInfo method in contextMethods)
            {
                methodInfoList.Add(method);
            }

            return methodInfoList;
        }

        public static PropertyInfo[] GetQueryColumns(object[] list)
        {
            if (list.Count() == 0)
                throw new Exception("The query returns no data.");

            var properties = list.First().GetType().GetProperties();
            var propertyCount = properties.Count();
            PropertyInfo[] returnProperties = new PropertyInfo[propertyCount];

            for (int i = 0; i < propertyCount; i++)
            {
                returnProperties[i] = properties[i];
            }

            return returnProperties;
        }

        public static List<ParameterInfo> getParameters(MethodInfo method)
        {
            return method.GetParameters().ToList();
        }

        public static bool ConnectionTest(DBContextReference reference, string connectionString)
        {
                var type = reference.AssemblyReference.GetType(reference.DBContextClass.FullName);
                dynamic db = Activator.CreateInstance(type, new string[] { connectionString });
                return db != null;
        }
    }

    public class AssemblyLoaderProxy : MarshalByRefObject
    {
        public AssemblyLoaderProxy() { }
        
        public Assembly LoadAssembly(string assemblyFullPath)
        {
            return Assembly.LoadFrom(assemblyFullPath);
        }
    }
}
