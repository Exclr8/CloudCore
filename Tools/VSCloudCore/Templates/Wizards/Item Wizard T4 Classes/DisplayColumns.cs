using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudCore.VSExtension.Wizards
{
    [Serializable]
    public class DisplayColumn
    {
        public bool IsPrimary { get; set; }
        public bool IsRequired { get; set; }
        public string Action { get; set; }
        public string DisplayName { get; set; }
        public string ColumnName { get; set; }
        public string ColumnNameAsVar
        {
            get { return Char.ToLowerInvariant(ColumnName[0]) + ColumnName.Substring(1); }
            set { ColumnName = Char.ToUpperInvariant(value[0]) + value.Substring(1); }
        } 
    }
}