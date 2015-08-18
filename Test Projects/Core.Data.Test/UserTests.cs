using System;
using System.Linq;
using System.Security;
using CloudCore.Domain;
using CloudCore.Domain.Specifications.User;
using Frameworkone.UnitTestUtilities;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Data.Tests
{
    [TestClass]
    public class UserTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        [TestMethod]
        public void CanSaveUser()
        {
            var newUser = new User
            {
                Login = Guid.NewGuid().ToString(),
                CellNumber = "00 000 0000",
                Email = Guid.NewGuid() + "@test.co.za",
                Initials = "A",
                FirstName = "A",
                Surname = "B",
                Access = new Access { InternalAccess = false, ExternalAccess = false }
            };

            var id = Repository.Insert(newUser);

            Assert.IsNotNull(id);
            Assert.AreNotEqual(0, id);

            var item = Repository.FindAll<User>(x => x.Id == id);

            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void CanUpdateUser()
        {
            var existingUser = Repository.FindAll<User>(a => a.Id == 0).Single();
            existingUser.CellNumber = "000 000 9999";
            existingUser.Email = "def@test.co.za";
            existingUser.Initials = "V";
            existingUser.FirstName = "Banana";
            existingUser.Surname = "HAHAHAHA";

            Repository.Update(existingUser);

            var result = Repository.FindAll<User>(a => a.Id == 0).Single();

            Assert.AreEqual("000 000 9999", result.CellNumber);
            Assert.AreEqual("def@test.co.za", result.Email);
            Assert.AreEqual("V", result.Initials);
            Assert.AreEqual("Banana", result.FirstName);
            Assert.AreEqual("HAHAHAHA", result.Surname);
        }

        [TestMethod]
        public void CanUpdateUserAccess()
        {
            var existingUser = Repository.FindAll<User>(a => a.Id == 0).Single();

            var originalExternalAccessValue = existingUser.Access.ExternalAccess;

            existingUser.Access.ExternalAccess = !originalExternalAccessValue;
            existingUser.Access.InternalAccess = true;
            existingUser.Access.IsAdministrator = false;

            Repository.Update(existingUser);

            var result = Repository.FindAll<User>(a => a.Id == 0).Single();

            Assert.AreEqual(!originalExternalAccessValue, result.Access.ExternalAccess);
            Assert.IsTrue(result.Access.InternalAccess);
            Assert.IsFalse(result.Access.IsAdministrator);
        }

        [TestMethod]
        public void Repository_User_AddToGroup_RemoveFromGroup()
        {
            var user = Repository.Get<User>(0);
            var group = Repository.Get<Group>(0);
            var userGroups = user.GetGroups(Repository);
            var count = userGroups.Count();

            user.RemoveFromGroup(Repository, (int)group.Id);
            Assert.AreEqual(count - 1, userGroups.Count());

            user.AddToGroup(Repository, (int)group.Id);
            Assert.AreEqual(count, userGroups.Count());
        }

        [TestMethod]
        public void CanFindSpecificUser()
        {
            var user = Repository.FindAll<User>(x => x.Id == 0).FirstOrDefault();
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void CanFindAllUsers()
        {
            var users = Repository.FindAll<User>();
            Assert.AreNotEqual(0, users.Count());
        }

        [TestMethod]
        public void User_PermittedActions_NonEmptyCollection()
        {
            var adminUser = Repository.Get<User>(0);
            var permittedActions = adminUser.PermittedActions(Repository);
            Assert.IsTrue(permittedActions.Any());
        }

        [TestMethod]
        public void User_UpdatePassword_HasNewPasswordHash()
        {
            // arrange
            var user = Repository.Get<User>(0);
            var oldPasswordHash = user.PasswordHash;
            var passwordResetReferenceId = user.RequestPasswordReset(Repository);
            // act
            user.ResetPassword(Repository, passwordResetReferenceId,
                newPassword: GenerateValidPassword());
            // assert
            Assert.IsTrue(user.PasswordHash != oldPasswordHash);
        }

        [TestMethod]
        [ExpectedException(typeof(SecurityException))]
        public void User_UpdatePassword_WithInvalidReference_ExceptionThrown()
        {
            // arrange
            var user = Repository.Get<User>(0);
            var passwordResetReferenceId = user.ClearPasswordResetReference(Repository);
            // act/assert

            user.ResetPassword(Repository, Guid.NewGuid(), newPassword: GenerateValidPassword());
        }

        private static string GenerateValidPassword()
        {
            var guid = Guid.NewGuid().ToString();
            guid = guid.Replace(guid.Substring(3, 16), guid.Substring(3, 16).ToUpper());
            return guid;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void User_GetUserByLoginOrEmail_InvalidLogin_ExceptionThrown()
        {
            var nonExistentUserLogin = Guid.NewGuid().ToString();
            UserExtensions.GetUserByLoginOrEmail(nonExistentUserLogin, Repository);
        }

        [TestMethod]
        public void User_Search_WithSpec_ItemsFound()
        {
            var searchSpec = new UserSearchSpec
            {
                Name = "",
                NameFilter = "%{0}%",
                Active = true,
                Email = "",
                EmailFilter = "%{0}%",
                Login = "",
                LoginFilter = "%{0}%"
            };

            var users = Repository.FindAll<User>(searchSpec);
            Assert.IsTrue(users.Any());
        }
    }
}
