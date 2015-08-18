using System.ComponentModel.DataAnnotations;

namespace CloudCore.Web.Models
{
    public class UserSystemModuleModel
    {
        [Display(Name = "System Module Id")]
        public int SystemModuleId { get; set; }

        [Display(Name = "Assembly Name")]
        public string AssemblyName { get; set; }

        [Display(Name = "AccessPool Name")]
        public string AccessPoolName { get; set; }

        [Display(Name = "UserId")]
        public int UserId { get; set; }

    }

  
}
