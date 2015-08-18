using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestGenerationTest.TemplateGenerationModels;

namespace TemplateGenerationTest.TemplateGenerationModels
{
    public class TemplateData
    {
        public string PageTitle { get; set; }
        public string Namespace { get; set; }
        public string ContextName { get; set; }

        public IEnumerable<PropertyItem> ModelProperties { get; set; }
    }
}