CREATE PROCEDURE [cloudcore].[ActivityAllocationCreate]
	@ActivityId int,
	@AccessPoolId int
AS
begin
	if exists (select null from cloudcore.ActivityAllocation where AccessPoolId = @AccessPoolId and ActivityId = @ActivityId)
	begin
		raiserror(N'The access pool has already been allocated to this activity',18, 1) 	
		return
	end

	insert into [cloudcore].ActivityAllocation (ActivityId, AccessPoolId) values (@ActivityId,  @AccessPoolId)
end