using System.ComponentModel.DataAnnotations;

namespace CloudCore.Web.Models
{
    public class AccessPoolModel
    {
        [Display(Name = "AccessPoolId")]
        public int AccessPoolId { get; set; }

        [Display(Name = "Access Pool Name")]
        public string AccessPoolName { get; set; }

        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "ManagerId")]
        public int ManagerId { get; set; }

        [Display(Name = "Manager Name")]
        public string ManagerName { get; set; }
    }
}