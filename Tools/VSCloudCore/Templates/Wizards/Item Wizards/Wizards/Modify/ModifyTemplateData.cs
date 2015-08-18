using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudCore.VSExtension.Wizards
{
    [Serializable]
    public class ModifyTemplateData : TemplateData
    {
        public string ModifyButtonText { get; set; }
        public string KeyFieldPropertyName { get; set; }
    }
}