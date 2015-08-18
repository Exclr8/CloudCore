CREATE PROCEDURE [cloudcore].[NotificationCreateByUser]
	@UserId int,
	@Creator int,
	@Subject varchar(50),	
	@Message varchar(1000),
	@NotificationId int out

AS

begin
  insert into [cloudcore].[Notification] ([Subject], [Message], Creator)
                    values (@Subject, @Message, @Creator)
  
  set @NotificationId = SCOPE_IDENTITY()

  insert into [cloudcore].[UserNotification] (UserId, NotificationId)
                        values (@UserId, @NotificationId)

	return @NotificationId
end