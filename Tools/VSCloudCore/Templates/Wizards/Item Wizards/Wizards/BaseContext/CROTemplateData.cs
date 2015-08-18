using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudCore.VSExtension.Classes.Helpers;

namespace CloudCore.VSExtension.Wizards
{


    [Serializable]
    public class BaseContextTemplateData : DBTemplateData
    {
        public List<BaseContextDataColumn> Columns { get; set; }
        public string PageTitle { get; set; }
        public string Query { get; set; }
        public BaseContextDataColumn PrimaryKey { get { return Columns.Find(r => r.IsPrimary == true); } }

        public BaseContextTemplateData()
        {
            Columns = new List<BaseContextDataColumn>();   
            this.Query = "";
            this.PageTitle = "Page Title";
        }

        
    }
}
