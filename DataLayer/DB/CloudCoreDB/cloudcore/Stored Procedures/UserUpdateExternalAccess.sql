CREATE PROCEDURE [cloudcore].[UserUpdateExternalAccess]
  @UserId int,
  @Access bit
as
begin
	update [cloudcore].[User] set ExtAccess = @Access where UserId = @UserId
end
