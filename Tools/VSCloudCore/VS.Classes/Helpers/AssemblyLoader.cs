using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;
using System.IO;
using System.Security.Policy;


namespace CloudCore.VSExtension.Classes.Helpers
{
    [Serializable]
    public class LoadedAssembly : MarshalByRefObject
    {
        public AppDomain Domain { get; set; }
        public Assembly Module { get; set; }
    }

    public class AssemblyLoader
    {

        public static LoadedAssembly Load(String assemblyFilePath)
        {
            string currentExecutingAssemblyPath = Assembly.GetExecutingAssembly().Location;

            if (currentExecutingAssemblyPath.StartsWith("File:"))
                currentExecutingAssemblyPath = currentExecutingAssemblyPath.Substring(9).Replace("/", "\\");
            else if (string.IsNullOrWhiteSpace(currentExecutingAssemblyPath))
                currentExecutingAssemblyPath = Assembly.GetExecutingAssembly().CodeBase.Substring(9).Replace("/", "\\");

            string newAppDomainFolderPath = currentExecutingAssemblyPath.Substring(0, currentExecutingAssemblyPath.LastIndexOf("\\"));
            string tempAppDomainName = Guid.NewGuid().ToString();
            var appDomainSecurity = new Evidence(AppDomain.CurrentDomain.Evidence);

            AppDomain appDomain = AppDomain.CreateDomain(
                friendlyName: tempAppDomainName,
                securityInfo: appDomainSecurity,
                appBasePath: newAppDomainFolderPath,
                appRelativeSearchPath: null,
                shadowCopyFiles: true);

            FileLoader fileLoader = (FileLoader)appDomain.CreateInstanceAndUnwrap(
                Assembly.GetExecutingAssembly().FullName, typeof(FileLoader).FullName);

            Assembly assembly = fileLoader.LoadAssembly(assemblyFilePath);

            return new LoadedAssembly { Module = assembly, Domain = appDomain };
        }
    }


    [Serializable]
    class FileLoader
    {
        public Assembly LoadAssembly(string filePath)
        {
            if (File.Exists(filePath))
            {
                string pdbPath = filePath.ToLower().Replace(".dll", ".pdb");

                byte[] rawAssembly = File.ReadAllBytes(filePath);
                byte[] rawDebugSymbols = null;

                if (File.Exists(pdbPath))
                    rawDebugSymbols = File.ReadAllBytes(pdbPath);

                return Assembly.Load(rawAssembly, rawDebugSymbols);
            }

            throw new FileNotFoundException(string.Format("Could not load Assembly: {0}", filePath), filePath);
        }
    }
}
