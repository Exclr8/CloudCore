create procedure [cloudcore].[WorkItemRelease]
	@InstanceId bigint
as
begin
   -- cancel the workitem
   update [cloudcore].Worklist set UserId = 0, StatusTypeId = 0, OpenedBy = 0 where InstanceId = @InstanceId
end