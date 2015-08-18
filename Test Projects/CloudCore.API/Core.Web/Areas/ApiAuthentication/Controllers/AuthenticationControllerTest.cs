using System;
using System.Globalization;
using System.Net.Http;
using System.Security;
using System.Security.Claims;
using System.Threading;
using System.Web;
using CloudCore.Api.Models;
using CloudCore.Core.Data;
using CloudCore.Core.DependencyResolution;
using CloudCore.Data;
using CloudCore.Domain.Security;
using CloudCore.Web.Core.Areas.ApiAuthentication.Controllers;
using CloudCore.Web.Core.Security.Api.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.API.Tests.Core.Web.Areas.ApiAuthentication.Controllers
{
    [TestClass]
    public class AuthenticationControllerTest
    {
        private readonly AuthenticationController apiController = null;
        private const string DefaultAdminPasswordString = "ad135fn:24da30FN_Sw531qe42_7up12_s24_oe135";
        private readonly Password defaultAdminPassword;

        public AuthenticationControllerTest()
        {
            defaultAdminPassword = new Password(DefaultAdminPasswordString);
            var dataModule = new CloudCoreDataModule();
            IoC.Initialize();
            IoC.ScanModule(dataModule);
            IoC.AdditionalConfiguration(dataModule);

            //var mailMan = MockHelper.CreateSimpleGenericMock<IMailMan>();
            //apiController = new AuthenticationController(Repository.Instance, new InMemoryCacheProvider(new CachePolicyFake()), mailMan);
            MockAuthContext(apiController);
            CloudCoreDB.Context.Cloudcore_UserPasswordUpdate(0, defaultAdminPassword.CreatePasswordHash(0));
            FakeIdentity(1, 0);
        }

        private void FakeIdentity(int applicationId, int userId)
        {
            var identity = new CloudCoreApiIdentity();
            identity.AddClaim(new Claim("ApplicationId", applicationId.ToString(CultureInfo.InvariantCulture)));
            identity.AddClaim(new Claim("UserId", userId.ToString(CultureInfo.InvariantCulture)));

            var principal = new ClaimsPrincipal(identity);

            Thread.CurrentPrincipal = principal;
            //MockHttpContext.CreateNewHttpContext();
            HttpContext.Current.User = principal;
        }

        private void MockAuthContext(AuthenticationController controller)
        {
            //var configuration = new HttpConfiguration();
            //var request = new HttpRequestMessage(HttpMethod.Post, @"http://localhost/");
            //controller.Request = request;
            //controller.Request.Properties["MS_HttpConfiguration"] = configuration;
        }

        [TestMethod]
        public void AuthenticationController_Api_Authorize()
        {
            ApiToken appTokenKey = apiController.Authorize(new ApplicationAuthorization { ApplicationKey = @"11000000-0000-0000-0000-000000000001" });
            Guid asGuid = Guid.Parse(appTokenKey.TokenKey);
            Assert.IsFalse(string.IsNullOrEmpty(appTokenKey.TokenKey), "APP_TOKEN_KEY is invalid");
            Assert.IsNotNull(asGuid, "APP_TOKEN_KEY is not a valid Guid");
        }

        [TestMethod]
        public void AuthenticationController_Api_ApplicationDetails()
        {
            ApplicationDetails details = apiController.ApplicationDetails();
            Assert.AreEqual(details.ApplicationName, "Cloudcore Site", "Application Name does not match");
            Assert.AreEqual("Framework One", details.CompanyName, "Company Name does not match");
            Assert.AreEqual("0218139947", details.ContactNumber, "Contact Number does not match");
            Assert.AreEqual("Alexander Mehlhorn", details.ContactPerson, "Contact Person does not match");
        }


        [TestMethod]
        public void AuthenticationController_Api_UserDetails()
        {
            UserDetails details = apiController.UserDetails();
            Assert.AreEqual(details.Firstname, "System", "First name does not match");
            Assert.AreEqual(details.Surname, "System", "Surname does not match");
            Assert.AreEqual(details.CellNo, "", "Cell number does not match");
            Assert.AreEqual(details.Email, "dev@frameworkone.co.za", "Email address does not match");

        }

        [TestMethod]
        [Ignore] // TODO: Fix this test - temperamental / getting interference
        public void AuthenticationController_Api_Login()
        {
            var userTokenKey = apiController.Login(new UserAuthorization { UserName = "sys", Password = DefaultAdminPasswordString });

            Guid asGuid = Guid.Parse(userTokenKey.TokenKey);

            Assert.IsFalse(string.IsNullOrEmpty(userTokenKey.TokenKey), "USER_TOKEN_KEY is invalid");
            Assert.IsNotNull(asGuid, "USER_TOKEN_KEY is not a valid Guid");
        }

        [TestMethod]
        [ExpectedException(typeof(SecurityException), "Old password specified is not correct.")]
        public void AuthenticationController_Api_ChangePassword_OldPasswordDontMatch_Error()
        {
            apiController.ChangePassword(new PasswordChange { OldPassword = "This_Is_Not_The_Password", NewPassword = "Abc12345_" });
        }

        [TestMethod]
        [ExpectedException(typeof(SecurityException), "New password may not be the same as the old password.")]
        public void AuthenticationController_Api_ChangePassword_OldAndNewPasswordMatch_NoPasswordChange()
        {
            apiController.ChangePassword(new PasswordChange { OldPassword = DefaultAdminPasswordString, NewPassword = DefaultAdminPasswordString });
        }

        [TestMethod]
        [Ignore] // Strength not configurable and has been removed.
        [ExpectedException(typeof(SecurityException), "There is a problem with the desired new password: Password does not meet password strength requirements.")]
        public void AuthenticationController_Api_ChangePassword_NoStrongPassword_Error()
        {
            apiController.ChangePassword(new PasswordChange { OldPassword = DefaultAdminPasswordString, NewPassword = "Snoopy" });
        }

        [TestMethod]
        [Ignore] // Test flawed.
        public void AuthenticationController_Api_ChangePassword_OldPasswordMatch_NewPasswordDifferentAndStrong_ChangeAccepted_NewTokenGenerated()
        {
            ApiToken result = apiController.ChangePassword(new PasswordChange { OldPassword = DefaultAdminPasswordString, NewPassword = "Asd12345_" });
            Assert.IsFalse(string.IsNullOrEmpty(result.TokenKey), "A new Api User Token was not generated after the password change.");
            CloudCoreDB.Context.Cloudcore_UserPasswordUpdate(0, defaultAdminPassword.CreatePasswordHash(0));
        }

        [TestMethod]
        [TestCategory("Third Party Integration Over-The-Wire")]
        [TestCategory("Long-running Tests")]
        public void AuthenticationController_Api_ResetPassword_IsMailSent()
        {
            MockAuthContext(apiController);
            apiController.ResetPassword(new ResetPassword { LoginOrEmail = "dev@frameworkone.co.za" });
        }
    }
}