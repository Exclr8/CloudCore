CREATE PROCEDURE [cloudcore].[AccessPoolUserRemove]
	@AccessPoolId int, 
	@UserId int
AS
Begin
	Delete from cloudcore.AccessPoolUser where AccessPoolId = @AccessPoolId and UserId = @UserId
End