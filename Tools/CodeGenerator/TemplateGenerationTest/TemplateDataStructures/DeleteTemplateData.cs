using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemplateGenerationTest.TemplateGenerationModels;

namespace TestGenerationTest.TemplateGenerationModels
{
    public class DeleteTemplateData : TemplateData
    {
        public string DeleteConfirmMessage { get; set; }
        public string KeyFieldPropertyName { get; set; }
    }
}