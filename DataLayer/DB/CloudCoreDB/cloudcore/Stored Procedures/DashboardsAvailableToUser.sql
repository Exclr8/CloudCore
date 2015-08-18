CREATE PROCEDURE [cloudcore].[DashboardsAvailableToUser]
	@userId int = 0
AS
	select d.DashboardId,d.Title, d.[Description]
	from cloudcore.Dashboard d
	inner join cloudcore.DashboardRight dr on d.DashboardId = dr.DashboardId
	inner join cloudcore.AccessPoolUser apu on dr.AccessPoolId = apu.AccessPoolId
	where apu.UserId = @userId
	and d.DashboardId not in (select DashboardId from cloudcore.DashboardUserAllocation dua where UserId = @userId)
