CREATE PROCEDURE [cloudcore].[NotificationDelete]
	@NotificationId int
AS
begin
  delete from [cloudcore].[UserNotification] where NotificationId  = @NotificationId
  delete from [cloudcore].[Notification] where NotificationId = @NotificationId
end