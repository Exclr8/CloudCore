CREATE PROCEDURE [cloudcore].[DashboardTasksToRun]
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Now DATETIME = GETDATE()

    DECLARE @Data TABLE
    (
		DashboardId INT NOT NULL, 
		DashboardGuid UNIQUEIDENTIFIER NOT NULL, 
		SystemModuleId INT NOT NULL, 
		Title VARCHAR(100) NOT NULL, 
		[Description] VARCHAR(MAX) NOT NULL
    )

    UPDATE  d
    SET     d.StatusId = 1
    OUTPUT  INSERTED.DashboardId,
            INSERTED.DashboardGuid,
            INSERTED.SystemModuleId,
			INSERTED.Title,
			INSERTED.[Description]
    INTO    @Data (DashboardId, DashboardGuid, SystemModuleId, Title, [Description])
    FROM    cloudcore.Dashboard d WITH (ROWLOCK, READPAST, UPDLOCK) 
    WHERE   d.NextRun < @Now and d.StatusId = 0


    SELECT  DashboardId, 
			DashboardGuid, 
			SystemModuleId, 
			Title, 
			[Description]
    FROM @Data
END