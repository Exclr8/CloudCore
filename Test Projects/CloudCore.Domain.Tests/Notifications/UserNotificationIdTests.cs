using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Domain.Tests.Notifications
{
    [TestClass]
    public class UserNotificationIdTests
    {
        int lastRandomValue;
        [TestMethod]
        public void UserNotificationId_DifferentIds_Equals_ReturnFalse()
        {
            UserNotificationId userNotificationId1 = Get_New_Unique_UserNotificationId();
            UserNotificationId userNotificationId2 = Get_New_Unique_UserNotificationId();

            Assert.IsFalse(userNotificationId1.Equals(userNotificationId2));
        }

        private UserNotificationId Get_New_Unique_UserNotificationId()
        {
            var randomizer = new Random();
            var randomValue = randomizer.Next();

            while (randomValue == lastRandomValue)
                randomValue = randomizer.Next();

            lastRandomValue = randomValue;
            return new UserNotificationId(userId: 1, notificationId: randomValue);
        }

        [TestMethod]
        public void UserNotificationId_SameIds_Equals_ReturnTrue()
        {
            var userNotificationId1 = Get_New_NonUnique_UserNotificationId();
            var userNotificationId2 = Get_New_NonUnique_UserNotificationId();

            Assert.IsTrue(userNotificationId1.Equals(userNotificationId2));
        }

        private UserNotificationId Get_New_NonUnique_UserNotificationId()
        {
            return new UserNotificationId(userId: 1, notificationId: 3);
        }

        [TestMethod]
        public void UserNotificationId_ToString_ReturnsCombinedIds()
        {
            var notification = new UserNotificationId(userId: 2287, notificationId: 109876);
            var notificationStringRepresentation = notification.ToString();
            Assert.AreEqual(notificationStringRepresentation, "2287:109876");
        }

        [TestMethod]
        public void UserNotificationId_DifferentObjectTypes_Equals_ReturnFalse()
        {
            var notification = Get_New_NonUnique_UserNotificationId();
            var someOtherObject = new List<int>();

            // ReSharper disable once SuspiciousTypeConversion.Global
            Assert.IsFalse(notification.Equals(someOtherObject));
        }
    }
}
