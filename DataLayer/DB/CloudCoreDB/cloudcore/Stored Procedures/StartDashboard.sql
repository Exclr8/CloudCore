CREATE PROCEDURE [cloudcore].[StartDashboard]
	@DashboardGuid UniqueIdentifier
AS
BEGIN
	UPDATE d
	SET d.LastRun = DATEADD(MINUTE, (d.IntervalInMinutes * -1), GETDATE())
	FROM cloudcore.Dashboard d
	WHERE d.DashboardGuid = @DashboardGuid
	  and d.StatusId = 0
END
