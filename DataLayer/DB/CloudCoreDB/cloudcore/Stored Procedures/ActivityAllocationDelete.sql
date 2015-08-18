CREATE PROCEDURE [cloudcore].[ActivityAllocationDelete]
	@ActivityId int, @AccessPoolId int
AS


	delete from [cloudcore].ActivityAllocation
	      where ActivityId = @ActivityId and AccessPoolId = @AccessPoolId