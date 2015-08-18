CREATE PROCEDURE [cloudcore].[NotificationCreateByAccessPool]
	@AccessPoolId int,
	@Creator int,
	@Subject varchar(50),	
	@Message varchar(1000),
	@NotificationId int out

AS

begin
  insert into [cloudcore].[Notification] ([Subject], [Message], Creator)
                    values (@Subject, @Message, @Creator)
  
  set @NotificationId = SCOPE_IDENTITY()

    declare @UserId int

    declare UserNotificationCursor cursor FAST_FORWARD for
    select apu.UserId
	  from [cloudcore].AccessPoolUser apu
	  join cloudcore.[User] u on apu.UserId = u.UserId
	where AccessPoolId = @AccessPoolId
	  and u.IntAccess = 1 
      and not exists (select null from cloudcore.UserNotification where UserId = u.UserId and NotificationId = @NotificationId)

    open UserNotificationCursor

    fetch next from UserNotificationCursor
        into @UserId

    while @@FETCH_STATUS = 0
    begin
        
        insert into [cloudcore].UserNotification (UserId, NotificationId)
            select @UserId, @NotificationId
	        where not exists (select null from cloudcore.UserNotification where UserId = @UserId and NotificationId = @NotificationId)

        fetch next from UserNotificationCursor
            into @UserId
    end

    close UserNotificationCursor
    deallocate UserNotificationCursor

end