using System;
using System.ComponentModel.DataAnnotations;

namespace CloudCore.Admin.Models
{
    public class PagesSearchItemModel
    {
        [Display(Name = "Action Id")]
        public long ActionId { get; set; }

        [Display(Name = "Action Guid")]
        public Guid ActionGuid { get; set; }

        [Display(Name = "Action Type")]
        public String ActionType { get; set; }

        [Display(Name = "Action Title")]
        public String ActionTitle { get; set; }

        [Display(Name = "Area")]
        public string Area { get; set; }

        [Display(Name = "Controller")]
        public string Controller { get; set; }

        [Display(Name = "Action")]
        public string Action { get; set; }

        [Display(Name = "System Module")]
        public string SystemModule { get; set; }
    }
}


