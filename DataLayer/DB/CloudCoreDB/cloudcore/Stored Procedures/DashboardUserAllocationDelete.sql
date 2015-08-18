CREATE PROCEDURE [cloudcore].[DashboardUserAllocationDelete]
	@UserId int,
	@TilePosition int
AS
	delete
	from cloudcore.DashboardUserAllocation
	where UserId = @UserId
	and TilePosition = @TilePosition
