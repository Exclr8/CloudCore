CREATE PROCEDURE [cloudcore].[ResetRunningOutdatedScheduledTasks]
    @KeepAliveTimeOutInSeconds INT,
    @RunningStatusId TINYINT,
    @RetryStatusId TINYINT,
    @PendingStatusId TINYINT
AS
BEGIN    
    DECLARE @Orphans TABLE
    (
        ScheduledTaskGuid UNIQUEIDENTIFIER PRIMARY KEY NOT NULL
    )

    DECLARE @TimeOutLimitDate DATETIME = DATEADD(SECOND, (@KeepAliveTimeOutInSeconds * -1), GETDATE())

    UPDATE  S
    SET     S.StatusId = @PendingStatusId
    OUTPUT  INSERTED.ScheduledTaskGuid
    INTO    @Orphans (ScheduledTaskGuid)
    FROM    cloudcore.ScheduledTask S WITH (READPAST)
    WHERE   (StatusId = @RunningStatusId OR StatusId = @RetryStatusId)
            AND KeepAliveDate <= @TimeOutLimitDate

    SELECT  ScheduledTaskGuid 
    FROM    @Orphans
END
