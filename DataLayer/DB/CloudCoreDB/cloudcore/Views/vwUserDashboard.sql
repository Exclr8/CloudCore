CREATE VIEW [cloudcore].[vwUserDashboard]
	AS 	
	SELECT 
		sm.AssemblyName,
		dua.DashboardUserAllocationId,
		dua.UserId,
		dua.DashboardId,
		dua.TilePosition,
		d.SystemModuleId,
		d.[Description],
		d.Title,
		d.DashboardGuid,
		u.NFullname
	FROM cloudcore.DashboardUserAllocation dua
	INNER JOIN cloudcore.Dashboard d ON dua.DashboardId = d.DashboardId
	inner join [cloudcore].SystemModule sm on sm.SystemModuleId = d.SystemModuleId
	inner join cloudcore.[User] u on dua.UserId = u.UserId