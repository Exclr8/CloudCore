using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemplateGenerationTest.TemplateGenerationModels
{
    public class DisplayColumn
    {
        public bool IsIdentifier { get; set; }
        public string Action { get; set; }
        public string DisplayProperty { get; set; }
        public string ColumnName { get; set; }
        public string ValueProperty { get; set; }
    }
}