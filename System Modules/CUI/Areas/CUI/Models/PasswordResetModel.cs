using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CloudCore.Domain;

using CloudCore.Data;

namespace CloudCore.Web.Models
{
    public class PasswordResetModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please provide a New Password.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "At least {2} characters required.", MinimumLength = 6)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please confirm the New Password.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "At least {2} characters required.", MinimumLength = 6)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "Passwords must match.")]
        public string ConfirmPassword { get; set; }

        public string ReferenceId { get; set; }

        public string FullName { get; private set;  }

        public bool IsValid { get; private set; }

        public void GetUserDetails( Guid referenceId)
        {

            var user = CloudCoreDB.Context.Cloudcore_User.Where(r => r.ReferenceGuid == referenceId).SingleOrDefault();
     

            if (user != null)
            {
                IsValid = true;
                UserId = (int)user.UserId;
                FullName = user.Fullname;
            }
            else
                IsValid = false;

        }
    }
}
