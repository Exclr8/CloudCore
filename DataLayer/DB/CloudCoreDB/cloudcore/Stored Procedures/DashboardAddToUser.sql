CREATE PROCEDURE [cloudcore].[DashboardAddToUser]
	@DashboardId int,
	@UserId int,
	@TilePosition int
AS
	insert into cloudcore.DashboardUserAllocation(DashboardId, UserId, TilePosition)
	values (@DashboardId, @UserId, @TilePosition)
