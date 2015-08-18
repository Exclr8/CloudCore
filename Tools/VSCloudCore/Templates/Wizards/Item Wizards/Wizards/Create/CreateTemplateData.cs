using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;

namespace CloudCore.VSExtension.Wizards
{
    [Serializable]
    public class CreateField : DataColumn
    {
        public bool IsNullable { get; set; }
        public bool IsByReference { get; set; }

    }

    [Serializable]
    public class CreateTemplateData : DBTemplateData
    {
        [NonSerialized]
        private MethodInfo _storedProcInfo;
        public MethodInfo StoredProcInfo { get { return _storedProcInfo; } }

        public List<CreateField> Fields { get; set; }
        public string PageTitle { get; set; }
        public string StoredProcedure { get; set; }
        public CreateField PrimaryKey { get { return Fields.Find(r => r.IsPrimary == true); } }

        public void SetStoredProcedureInfo(MethodInfo storedProcInfo)
        {
            this.StoredProcedure = storedProcInfo.Name;
            this._storedProcInfo = storedProcInfo;
            ParameterInfo[] paraminfo = _storedProcInfo.GetParameters();
            Fields.Clear();
            foreach (var item in paraminfo)
            {
                if (item.ParameterType.FullName.Contains("Nullable"))
                {
                    Fields.Add(new CreateField() { ColumnNameAsVar = item.Name, IsNullable = true, IsByReference = item.ParameterType.IsByRef, ColumnType = Nullable.GetUnderlyingType(item.ParameterType) ?? item.ParameterType.GetGenericArguments()[0], DisplayName = Char.ToUpperInvariant(item.Name[0]) + Regex.Replace(item.Name.Substring(1), "([a-z])([A-Z])", "$1 $2") });
                } 
                else
                {
                    Fields.Add(new CreateField() { ColumnNameAsVar = item.Name, IsNullable = false, IsByReference = item.ParameterType.IsByRef, ColumnType = item.ParameterType, DisplayName = Char.ToUpperInvariant(item.Name[0]) + Regex.Replace(item.Name.Substring(1), "([a-z])([A-Z])", "$1 $2") });
                }
            }
        }

        public CreateTemplateData()
        {
            Fields = new List<CreateField>();   
            this.StoredProcedure = "";
            this.PageTitle = "Create Title";
        }
        
    }
}