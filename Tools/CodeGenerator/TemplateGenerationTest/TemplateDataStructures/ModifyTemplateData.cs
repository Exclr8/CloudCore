using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemplateGenerationTest.TemplateGenerationModels;

namespace TestGenerationTest.TemplateGenerationModels
{
    public class ModifyTemplateData : TemplateData
    {
        public string ModifyButtonText { get; set; }
        public string KeyFieldPropertyName { get; set; }
    }
}