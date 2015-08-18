using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Domain.Tests.Users
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void User_FirstNameAndSurame_FullNameShouldBeFirstNameAndSurname()
        {
            var user = new User { FirstName = "yellow", Surname = "World" };
            Assert.AreEqual(user.FullName, "yellow World");
        }

        [TestMethod]
        public void User_FirstNameOnly_FullNameShouldBeFirstNameWithoutTrailingSpaces()
        {
            var user = new User { FirstName = "yellow" };
            Assert.AreEqual(user.FullName, "yellow");
        }

        [TestMethod]
        public void User_LastNameOnly_FullNameShouldBeLastNameWithoutLeadingSpaces()
        {
            var user = new User { Surname = "World" };
            Assert.AreEqual(user.FullName, "World");
        }
    }
}
