using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;

namespace CloudCore.VSExtension.Classes.Helpers
{
    public class CompiledExecution : IDisposable
    {
        public CompiledExecution()
        {
            this.MetaDataMembers = new List<PropertyInfo>();
        }



        public string Query { get; set; }
        public string ConnectionString { get; set; }
        public string DataAssemblyLocation { get; set; }
        public string DataContextClassName { get; set; }
        public List<PropertyInfo> MetaDataMembers { get; private set; }
        public string ContextName { get; private set; }

        public IQueryable Execute()
        {
            var executeAssembly = ExecuteAssembly();


            Type t = executeAssembly.GetType("FrameworkOne.DynamicCompiler.Execute");
            dynamic executionInstance = Activator.CreateInstance(t);

            var dataAsQueryable = executionInstance.ExecuteQuery(this.ConnectionString);

            MetaDataMembers.Clear();
            if (executionInstance.MetaData != null)
            {
                MetaDataMembers.AddRange(executionInstance.MetaData);
            }

            this.ContextName = executionInstance.ElementName;

            return dataAsQueryable;
        }

        private Assembly ExecuteAssembly()
        {
            if (this.Query == null)
            {
                throw new ArgumentNullException("QueryText");
            }

            CodeDomProvider codeDomProvider = new CSharpCodeProvider();
            CompilerParameters compilerParameters = new CompilerParameters();
            compilerParameters.GenerateExecutable = false;
            compilerParameters.GenerateInMemory = false;
            compilerParameters.IncludeDebugInformation = false;
            compilerParameters.WarningLevel = 3;
            compilerParameters.TreatWarningsAsErrors = false;
            compilerParameters.CompilerOptions = "/optimize";

            List<string> list = new List<string>
			{
				"mscorlib.dll",
				"System.dll",
				"System.Core.dll",
                "System.Data.dll",
                "System.Data.Linq.dll",
                "System.Data.DataSetExtensions.dll",
                "System.Xml.dll",
                "Microsoft.CSharp.dll",
                "System.Xml.Linq.dll",
                this.DataAssemblyLocation
			};

            list.ForEach(i => compilerParameters.ReferencedAssemblies.Add(i));
      

            string execString = @"using System;
                using System.Collections;
                using System.Collections.Generic;
                using System.Linq;
                using System.Data.Linq;
                using System.Text;
                using System.Reflection;
                using Microsoft.CSharp;
                using System.Linq.Expressions;
                using System.ComponentModel;
                using System.Data.Linq.Mapping;
                            
                namespace FrameworkOne.DynamicCompiler
                {{
                    public class Execute
                    {{
                        public List<System.Reflection.PropertyInfo> MetaData;
                        public String ElementName;

                        public IQueryable ExecuteQuery(string connectionstring)
                        {{
                           var db = new {0}(connectionstring);
                           var q = ({1}).Select(a => a);
                           ElementName = q.ElementType.Name;
                           if (ElementName.IndexOf(""_"") > 0) 
                           {{ 
                               ElementName = ElementName.Substring(ElementName.IndexOf(""_"")+1); 
                           }}
                           MetaData = q.ElementType.GetProperties().Where(a => a.GetCustomAttributes(typeof(System.Data.Linq.Mapping.ColumnAttribute), true).Length > 0).ToList();
                           return q.AsQueryable();
                        }}
                    }}
                }}";


            string text = string.Format(execString, this.DataContextClassName, this.Query);

            CompilerResults compilerResults = codeDomProvider.CompileAssemblyFromSource(compilerParameters, new string[] { text });
            if (compilerResults.Errors.Count > 0)
            {
                throw new Exception(compilerResults.Errors[0].ErrorText);
            }
            return compilerResults.CompiledAssembly;
        }
       



        public void Dispose()
        {
            this.MetaDataMembers.Clear();
            this.MetaDataMembers = null;
        }
    }
}
