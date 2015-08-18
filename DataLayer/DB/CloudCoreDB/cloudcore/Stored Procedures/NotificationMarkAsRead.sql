CREATE PROCEDURE [cloudcore].[NotificationMarkAsRead]
   @UserId int,
   @NotificationId int
AS
begin
  update [cloudcore].[UserNotification] set HasRead = 1 where UserId = @UserId and NotificationId = @NotificationId
end
