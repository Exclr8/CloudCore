using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudCore.VSExtension.Wizards
{
    [Serializable]
    public class DataColumn : DisplayColumn
    {
        public Type ColumnType { get; set; }
    }

    [Serializable]
    public class BaseContextDataColumn : DataColumn
    {
        public bool DisplayOnPage { get; set; }
        public bool AddAsProperty { get; set; }

    }

    [Serializable]
    public class SearchDataColumn : DataColumn
    {
        public bool DisplayInGrid { get; set; }
        public bool AddToGrid { get; set; }
        public bool AddAsFilter { get; set; }
        public bool IsPrimaryDisplay { get; set; }

    }
}