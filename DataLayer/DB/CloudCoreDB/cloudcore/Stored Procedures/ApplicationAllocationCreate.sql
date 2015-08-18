CREATE PROCEDURE [cloudcore].[ApplicationAllocationCreate]
	@ApplicationId Int,
	@ActivityId Int
AS
	insert into [cloudcore].SystemApplicationAllocation(ActivityId,ApplicationId)
	values(@ActivityId,@ApplicationId)

