using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudCore.VSExtension.Wizards
{
    [Serializable]
    public class LookupTemplateData : TemplateData
    {
        public List<InputColumn> InputColumns { get; set; }
        public List<DisplayColumn> DisplayColumns { get; set; }
        public string GridDataSourceName { get; set; }
        public string GridTitle { get; set; }
        public string DataContextNamespace { get; set; }
        public string DataContextName { get; set; }
        public string SearchQuery { get; set; }
    }

}
