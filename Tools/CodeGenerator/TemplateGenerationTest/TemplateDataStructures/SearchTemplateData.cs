using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemplateGenerationTest.TemplateGenerationModels;

namespace TestGenerationTest.TemplateGenerationModels
{
    public class SearchTemplateData : TemplateData
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
