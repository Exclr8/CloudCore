CREATE PROCEDURE [cloudcore].[WorkItemCancel]
	@InstanceId bigint, @UserId int
AS
begin
   -- cancel the workitem
   update [cloudcore].Worklist set UserId = @UserId, StatusTypeId = 99 where InstanceId = @InstanceId
end