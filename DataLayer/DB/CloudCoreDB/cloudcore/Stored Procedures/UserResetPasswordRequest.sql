CREATE PROCEDURE [cloudcore].[UserResetPasswordRequest]
    @UserIdentifier varchar(200),
	@ReferenceGuid uniqueidentifier out
as
declare @UserId int
begin
  set @UserId = (select UserId 
                 from   [cloudcore].[User] 
                 where  ([Login] = @UserIdentifier or Email = @UserIdentifier) 
                        and (Active = 1 or not exists(select null 
                                                      from cloudcore.[LoginHistory] 
                                                      where UserId = @UserId)))

  -- create a unique reference id for this request
  update [cloudcore].[User]
    set ReferenceGuid = NEWID() 
    where UserId = @UserId

  select @ReferenceGuid = ReferenceGuid 
    from [cloudcore].[User] 
   where [UserId] = @UserId
end