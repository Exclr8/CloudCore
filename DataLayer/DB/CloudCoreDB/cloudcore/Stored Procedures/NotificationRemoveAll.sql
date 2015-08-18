CREATE PROCEDURE [cloudcore].[NotificationRemoveAll]
	@UserId int
AS
begin
  delete from [cloudcore].[UserNotification] where UserId = @UserId
end