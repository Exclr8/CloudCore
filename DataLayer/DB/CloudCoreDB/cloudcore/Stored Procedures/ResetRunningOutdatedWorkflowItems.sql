CREATE PROCEDURE [cloudcore].[ResetRunningOutdatedWorkflowItems]
    @KeepAliveTimeOutInSeconds INT,
    @RunningStatusId TINYINT,
    @RetryStatusId TINYINT,
    @PendingStatusId TINYINT
AS
BEGIN    
    DECLARE @Orphans TABLE (
        InstanceId BIGINT PRIMARY KEY NOT NULL,
        ActivityId INT NOT NULL
    )

    DECLARE @TimeOutLimitDate DATETIME = DATEADD(SECOND, (@KeepAliveTimeOutInSeconds * -1), GETDATE())

    UPDATE  W
    SET     W.StatusTypeId = @PendingStatusId
    OUTPUT  INSERTED.InstanceId, INSERTED.ActivityId
    INTO    @Orphans (InstanceId, ActivityId)
    FROM    cloudcore.Worklist W WITH (READPAST)
    INNER JOIN cloudcore.vwWorklistEx v WITH (NOLOCK)
        ON  v.InstanceId = w.InstanceId
    WHERE   w.[KeepAliveDate] <= @TimeOutLimitDate
            AND (w.[StatusTypeId] = @RunningStatusId OR w.StatusTypeId = @RetryStatusId)
            AND v.ActivityTypeName != 'Custom User Activity' 
            AND v.ActivityTypeName != 'CloudCore User Activity'

    SELECT  InstanceId, ActivityId
    FROM    @Orphans
END
