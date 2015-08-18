CREATE PROCEDURE [cloudcore].[LoginUpdate]
@UserId INT,
@ApplicationId INT,
@LastLogin datetime out
AS
begin
  if not exists(select 1 from cloudcore.[User] where UserId = @UserId and Active = 1)
  begin
    raiserror('Cannot create audit entry for login. Invalid user specified.', 16, 1)
  end

  SET @LastLogin = getdate()

  -- create history
  insert into [cloudcore].LoginHistory (UserId, ApplicationId) values (@UserId, @ApplicationId)
  update U set LastLogin = @LastLogin from [cloudcore].[User] U where U.UserId = @UserId 
end