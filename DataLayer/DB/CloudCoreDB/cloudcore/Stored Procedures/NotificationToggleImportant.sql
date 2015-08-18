CREATE PROCEDURE [cloudcore].[NotificationToggleImportant]
   @UserId int,
   @NotificationId int,
   @Important int out
AS
begin	

  update [cloudcore].[UserNotification] 
  set Important = 
				case
					when Important = 1 then 0
					else 1
                end				
  where UserId = @UserId and NotificationId = @NotificationId

  SET @Important = (select Important from [cloudcore].[UserNotification] where UserId = @UserId and NotificationId = @NotificationId)
end
