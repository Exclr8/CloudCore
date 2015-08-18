using System.Collections.Generic;
using System.Web.Mvc;

namespace CloudCore.Web.Core.BaseModels
{
    public class FilterEditModel
    {
        public List<SelectListItem> FilterOptions
        {
            get
            {
                return new List<SelectListItem> 
                       {
                            new SelectListItem {Text = @"contains", Value = "%{0}%"},
                            new SelectListItem {Text = @"starts with", Value = "{0}%"},
                            new SelectListItem {Text = @"matches", Value = "{0}"},
                       };
            }
        }
    }
}
