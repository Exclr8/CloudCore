CREATE PROCEDURE [cloudcore].[WorkItemChangeUser]
	@InstanceId bigint, @UserId int
AS
begin
   -- Change the user this item is assigned to
   update [cloudcore].Worklist set UserId = @UserId where InstanceId = @InstanceId
end