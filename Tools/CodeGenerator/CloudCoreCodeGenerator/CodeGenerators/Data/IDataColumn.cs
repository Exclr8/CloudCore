using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Data
{
    public interface IDataColumn
    {
        string ColumnName { get; set; }
        string VariableType { get; set; }
        bool IsSelected { get; set; }
    }
}
