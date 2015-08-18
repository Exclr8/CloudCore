CREATE PROCEDURE [cloudcore].[ApplicationAllocationDelete]
	@ApplicationId Int,
	@ActivityId Int
AS
	delete from  [cloudcore].SystemApplicationAllocation
	where ActivityId = @ActivityId and ApplicationId = @ApplicationId

