using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Data
{
    public interface IClassData : IData
    {
        string ClassName { get; set; }
        string NameSpace { get; set; }
    }
}
