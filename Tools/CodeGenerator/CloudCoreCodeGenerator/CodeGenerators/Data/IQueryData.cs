using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Data
{
    public interface IQueryData : IData
    {
        string ContextName { get; set; }
        string Query { get; set; }
        List<IDataColumn> Columns { get; set; }

        List<IDataColumn> GetSelectedColumns();
    }
}
