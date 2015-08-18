CREATE PROCEDURE [cloudcore].[DashboardTaskUpdate]
	@DashboardId INT,
	@StatusId TINYINT
AS
BEGIN
	UPDATE  d
	SET     d.StatusId = @StatusId,
            d.LastRun = GETDATE()		    
    FROM    cloudcore.Dashboard d
	WHERE   d.DashboardId = @DashboardId
END
