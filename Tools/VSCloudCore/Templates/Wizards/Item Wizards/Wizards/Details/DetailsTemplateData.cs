using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudCore.VSExtension.Wizards
{
    [Serializable]
    public class DetailsTemplateData : TemplateData
    {
        public string PageTitle { get; set; }

        public DetailsTemplateData()
        {
            this.Title = "";
            this.PageTitle = "Page Title";
            
        }
    }
}