using System;
using CloudCore.Api.Models;

namespace CloudCore.Api.Client
{
    public abstract class UserApiClientBase : ApplicationApiClientBase
    {
        public abstract string GetUsername();
        public abstract string GetPassword();

        public ApiToken UserToken { get; private set; }

        protected void InitializeForUserCall()
        {
            InitializeForApplicationCall();
            if ((UserToken == null) || (UserToken.ExpiryLocal < DateTime.Now))
            {
                UserToken = Authenticate(new UserAuthorization { UserName = GetUsername(), Password = GetPassword() }
                                            , ApplicationToken.TokenKeyName
                                            , ApplicationToken.TokenKey);
            }
        }

        public UserDetails UserDetails()
        {
            InitializeForUserCall();
            return DownloadFromWeb<UserDetails>(ApiPaths.User.Details);
        }

        public void ResetPassword(string loginOrEmail)
        {
            InitializeForApplicationCall();
            var resetPasswordData = new ResetPassword { LoginOrEmail = loginOrEmail };
            UploadToWeb(ApiPaths.Application.UserResetPassword, resetPasswordData);
        }

        public void ChangePassword(string oldPassword, string newPassword)
        {
            InitializeForUserCall();
            var changePasswordData = new PasswordChange { OldPassword = oldPassword, NewPassword = newPassword };
            UploadToWeb(ApiPaths.User.ChangePassword, changePasswordData);
        }
    }
}
