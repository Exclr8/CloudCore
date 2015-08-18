using System.ComponentModel.DataAnnotations;

namespace CloudCore.Web.Models
{
    public class LogOnModel
    {
        [Required(ErrorMessage = "Please enter Login/Email Address.")]
        [Display(Name = "Login/Email Address")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter Password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}