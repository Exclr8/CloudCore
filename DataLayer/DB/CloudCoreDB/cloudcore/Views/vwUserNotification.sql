CREATE VIEW [cloudcore].[vwUserNotification]
	AS 
	select UN.UserId, N.Creator CreatorId, U.Fullname CreatorName, UN.NotificationId, UN.Important, HasRead, N.[Subject], N.[Message], N.Created   
	  from [cloudcore].UserNotification UN
	 inner join [cloudcore].[Notification] N
	    on N.NotificationId = UN.NotificationId
     inner join [cloudcore].[User] U
	    on U.UserId = N.Creator
