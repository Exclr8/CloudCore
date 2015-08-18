CREATE PROCEDURE [cloudcore].[AccessPoolUserCreate]
	@AccessPoolId int, 
	@UserId int
AS
Begin
	if exists (select null from cloudcore.AccessPoolUser where AccessPoolId = @AccessPoolId and UserId = @UserId)
	begin
		raiserror(N'The access pool has already been allocated to this user',18, 1) 	
		return
	end

	Insert into cloudcore.AccessPoolUser (AccessPoolId, UserId) values( @AccessPoolId , @UserId )
End