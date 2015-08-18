using System;
using System.ComponentModel.DataAnnotations;
using CloudCore.Web.Core.Security.Authentication;
using CloudCore.Data;
using System.Linq;
using CloudCore.Domain.Security;

namespace CloudCore.Web.Models
{
    public class ChangePasswordModel : PersonalDetailsModel
    {
        [Required(ErrorMessage = "Please enter Old Password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Please enter a New Password.")]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please enter a the Password Confirmation.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "Passwords must match.")]
        public string ConfirmPassword { get; set; }

        public ChangePasswordModel()
        {
            UserId = CloudCoreIdentity.UserId;
        }

        public void ChangePassword()
        {
            IsPasswordValid();

            string passwordHashed = Password.CreatePasswordHash(ActiveUser.UserId, NewPassword);

            Data.CloudCoreDB db = new Data.CloudCoreDB();
            db.Cloudcore_UserPasswordUpdate(ActiveUser.UserId, passwordHashed);
        }

        private void IsPasswordValid()
        {
            if (OldPassword == null || NewPassword == null)
            {
                throw new Exception("Please complete Old Password AND New Password fields!");
            }

            if (OldPassword.Equals("") || NewPassword.Equals(""))
            {
                throw new Exception("Please complete Old Password AND New Password fields!");
            }

            if (!isOldPasswordEqualToPasswordInDatabase())
            {
                OldPassword = string.Empty;

                throw new Exception("Please enter correct Current Password!");
            }

            if (!NewPassword.Equals(ConfirmPassword))
            {
                ClearNewPasswordAndConfirmPasswordFields();

                throw new Exception("New Password and Confirm Password fields do not match!");
            }

            if (NewPassword.Equals(OldPassword))
            {
                ClearNewPasswordAndConfirmPasswordFields();

                throw new Exception("New Password may not be the same as Old Password!");
            }

            if (NewPassword.ToLower().Equals("password"))
            {
                ClearNewPasswordAndConfirmPasswordFields();

                throw new Exception(@"New Password may not be ""password"" !");
            }
        }

        private bool isOldPasswordEqualToPasswordInDatabase()
        {
            var oldPasswordHashed = Password.CreatePasswordHash(CloudCoreIdentity.UserId, OldPassword);

            var db = CloudCoreDB.Context;
            var databaseHasedPassword = (from user in db.Cloudcore_User
                                         where user.UserId == CloudCoreIdentity.UserId
                                         select user.PasswordHash).SingleOrDefault();
            return databaseHasedPassword.Equals(oldPasswordHashed);
        }

        private void ClearNewPasswordAndConfirmPasswordFields()
        {
            NewPassword = string.Empty;
            ConfirmPassword = string.Empty;
        }
    }
}