using System.Collections.Generic;
using System.Linq;
using CloudCore.Domain;
using Frameworkone.UnitTestUtilities.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Data.Tests
{
    [TestClass]
    public class NotificationTests : CloudCoreRepositoryRollbackDatabaseTestContext
    {
        const int RecipientId = 1;
        const int GroupId = 0;

        private Notification notification;

        [TestInitialize]
        public void Init()
        {
            notification = new Notification
            {
                CreatedBy = 0,
                Message = "this is a test message",
                Subject = "test",
            };
        }

        [TestMethod]
        public void CanCreateUserNotification()
        {
            var notificationId = notification.SendToUser(RecipientId, Repository);
            var userNotification = Repository.FindAll<UserNotification>(x => x.Id.UserId == RecipientId && x.Id.NotificationId == notificationId).SingleOrDefault();

            Assert.IsNotNull(userNotification);
            var originalNotification = GetNotification(notificationId);

            AssertOriginalMessageCorrect(originalNotification);
        }

        [TestMethod]
        public void Notification_SendToUser_UserHasNotifications_ReturnsTrue()
        {
            notification.SendToUser(RecipientId, Repository);
            var userHasNotifications = NotificationExtensions.UserHasNotifications(Repository, RecipientId);
            Assert.IsTrue(userHasNotifications);            
        }

        [TestMethod]
        public void CanCreateGroupNotification()
        {
            var notificationId = notification.SendToGroup(GroupId, Repository);

            var userNotifications = Repository.FindAll<UserNotification>(x => x.Id.NotificationId == notificationId);

            Assert.AreNotEqual(0, userNotifications.Count());

            var group = Repository.Get<Group>(GroupId);
            var userCount = @group.GetUsers(Repository).Count(x => x.Access.InternalAccess);

            Assert.AreEqual(userCount, userNotifications.Count());

            var originalNotification = GetNotification(notificationId);

            foreach (var notify in userNotifications)
            {
                Assert.AreEqual(notify.Id.NotificationId, notificationId);
                AssertOriginalMessageCorrect(originalNotification);
            }
        }

        private void AssertOriginalMessageCorrect(Notification originalNotification)
        {
            Assert.AreEqual(notification.CreatedBy, originalNotification.CreatedBy);
            Assert.AreEqual(notification.Subject, originalNotification.Subject);
            Assert.AreEqual(notification.Message, originalNotification.Message);
        }

        [TestMethod]
        public void CanMarkNotificationAsRead()
        {
            var notificationId = notification.SendToUser(RecipientId, Repository);

            var userNotification = Repository.Get<UserNotification>(x => x.Id.NotificationId == notificationId && x.Id.UserId == RecipientId);

            userNotification.MarkAsRead(Repository);

            var updatedNotification = Repository.Get<UserNotification>(x => x.Id.NotificationId == notificationId && x.Id.UserId == RecipientId);

            Assert.AreEqual(true, updatedNotification.HasRead);
        }

        [TestMethod]
        public void CanDeleteNotification()
        {
            var notificationId = notification.SendToUser(RecipientId, Repository);
            var originalNotification = GetNotification(notificationId);

            originalNotification.Delete(Repository);

            var deletedNotification = GetNotification(notificationId);

            Assert.IsNull(deletedNotification);
        }

        [TestMethod]
        public void CanDeleteUserNotification()
        {
            var notificationId = notification.SendToUser(RecipientId, Repository);
            var userNotification = Repository.Get<UserNotification>(x => x.Id.NotificationId == notificationId && x.Id.UserId == RecipientId);

            userNotification.Delete(Repository);

            var deletedNotification = Repository.Get<UserNotification>(x => x.Id.NotificationId == notificationId && x.Id.UserId == RecipientId);

            Assert.IsNull(deletedNotification);
        }


        private Notification GetNotification(int notificationId)
        {
            return Repository.Get<Notification>(x => x.Id == notificationId);
        }
    }
}
