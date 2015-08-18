using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudCore.VSExtension.Wizards
{
    [Serializable]
    public class SearchTemplateData : DBTemplateData
    {
        public List<SearchDataColumn> Columns { get; set; }
        public string PageTitle { get; set; }
        public string Query { get; set; }
        public SearchDataColumn PrimaryKey { get { return Columns.Find(r => r.IsPrimary == true); } }
        public SearchDataColumn PrimaryDisplay { get { return Columns.Find(r => r.IsPrimaryDisplay == true); } }

        public SearchTemplateData()
        {
            Columns = new List<SearchDataColumn>();   
            this.Query = "";
            this.PageTitle = "Page Title";
        }
    }
}
