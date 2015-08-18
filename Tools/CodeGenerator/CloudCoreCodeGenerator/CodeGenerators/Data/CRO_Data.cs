using System.Collections.Generic;

namespace FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Data
{
    public class CRO_Data : BaseData, IClassData, IQueryData
    {
        public CRO_Data() 
        {
            Columns = new List<IDataColumn>();
        }

        public string ContextName { get; set; }
        public string Query { get; set; }
        public List<IDataColumn> Columns { get; set; }
        public string ClassName { get; set; }
        public string NameSpace { get; set; }

        public List<IDataColumn> GetSelectedColumns()
        {
            return Columns.FindAll(c => c.IsSelected);
        }

        public override void ResetAllData()
        {
            Columns.Clear();
        }
    }

    public interface ICRO_DataColumn : IDataColumn
    {
        string DisplayName { get; set; }
        bool IsPrimary { get; set; }
    }

    public class CRO_DataColumn : ICRO_DataColumn
    {
        public string DisplayName { get; set; }
        public string ColumnName { get; set; }
        public string VariableType { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsSelected { get; set; }
    }

    public class CRO_DataColumn_Email : CRO_DataColumn
    {
        public string EmailColumn { get; set; }
    }

    public class CRO_DataColumn_Url : CRO_DataColumn
    {
        public string UrlColumn { get; set; }
    }

    public enum CRO_RenderType
    {
        HtmlContent,
        AddEmailContent,
        UrlContent
    }
}
