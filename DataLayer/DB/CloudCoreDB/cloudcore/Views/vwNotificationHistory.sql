 create view [cloudcore].vwNotificationHistory as
      select n.NotificationId, n.Created, n.Creator, u.NFullname, n.[Subject], n.[Message],
              (select count(UserId) from [cloudcore].UserNotification un where un.NotificationId = n.NotificationId and HasRead = 0) as TotalUnread
         from [cloudcore].[Notification] n
       inner join [cloudcore].[User] u on n.Creator = u.UserId