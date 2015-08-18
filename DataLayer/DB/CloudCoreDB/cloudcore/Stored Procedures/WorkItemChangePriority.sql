CREATE PROCEDURE [cloudcore].[WorkItemChangePriority]
	@InstanceId int,
	@Priority tinyint
AS
begin
	update [cloudcore].Worklist
	   set Priority = @Priority
	 where InstanceId = @InstanceId
end