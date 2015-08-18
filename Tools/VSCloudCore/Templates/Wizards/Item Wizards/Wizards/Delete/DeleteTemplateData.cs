using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudCore.VSExtension.Wizards
{
    [Serializable]
    public class DeleteTemplateData : TemplateData
    {
        public string DeleteConfirmMessage { get; set; }
        public string KeyFieldPropertyName { get; set; }
    }
}