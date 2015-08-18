CREATE PROCEDURE [cloudcore].[NotificationRemove]
	@NotificationId int,
	@UserId int
AS
begin
  delete from [cloudcore].[UserNotification] where NotificationId = @NotificationId and UserId = @UserId
end