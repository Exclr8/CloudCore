using System.ComponentModel.DataAnnotations;
using System.Linq;
using CloudCore.Domain;
using CloudCore.Web.Core.Security.Authentication;


namespace CloudCore.Web.Models
{
    public class LoggedInUserModel : PersonalDetailsModel
    {



        #region Public Properties
        [Required(ErrorMessage = "Please enter a Password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Passwords must match.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        #endregion

        public LoggedInUserModel()
        {
            Key = UserId;
        }

    }
}