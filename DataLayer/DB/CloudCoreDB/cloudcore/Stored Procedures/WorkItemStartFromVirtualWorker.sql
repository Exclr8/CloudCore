CREATE PROCEDURE [cloudcore].[WorkItemStartFromVirtualWorker]
	@ApplicationId   INT,
	@StatusTypeId	 INT = 0,
    @KeepAliveTimeOutInSeconds int = 900,
    @ActivityGuid    UNIQUEIDENTIFIER OUTPUT,
	@ActivityId      INT OUTPUT,
    @InstanceId      BIGINT OUTPUT,
    @KeyValue        BIGINT OUTPUT,
	@MaxRetries		 INT OUTPUT,
	@Retries		 INT OUTPUT,
    @ActivityName    VARCHAR(100) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    declare @Now DATETIME
    declare @UserId INT = -99 -- Virtual Worker

    SET @Now = GETDATE()

    declare @Data table
    (
        InstanceId      bigint,
        KeyValue        bigint,
        ActivityId      int,
		Retries			int	
    )

    UPDATE  Top (1) wl
    SET     wl.StatusTypeId = 1,
            wl.OpenedBy = @UserId,
            wl.Opened = @Now,
			wl.Retries = CASE WHEN @StatusTypeId = 42
						 THEN wl.Retries + 1
						 ELSE wl.Retries END,
            wl.KeepAliveDate = dateadd(second, @KeepAliveTimeOutInSeconds, getdate())
    OUTPUT  INSERTED.InstanceId,
            INSERTED.KeyValue,
            INSERTED.ActivityId,
			INSERTED.Retries
    INTO    @Data (InstanceId, KeyValue, ActivityId, Retries)
    FROM    cloudcore.Worklist wl 
	WHERE   wl.InstanceId = (
                                SELECT TOP 1 w2.InstanceId
								FROM cloudcore.Worklist w2 WITH (ROWLOCK, READPAST, UPDLOCK, INDEX(IX_Worklist_Priority_Activate))
	                            INNER JOIN cloudcoremodel.vwLiveActivity A with (NOLOCK)
	                                ON A.ActivityId = w2.ActivityId
								WHERE	W2.Activate <= @Now
                                        AND   A.ActivityTypeId != 0 AND A.ActivityTypeId != 1 -- not a user activity 
	                                    AND  (
                                                (@StatusTypeId = 42 and w2.Retries < A.MaxRetries AND w2.StatusTypeId = @StatusTypeId) -- 
                                                
                                                OR 
                                                
                                                (@StatusTypeId != 42 and (w2.StatusTypeId = @StatusTypeId OR w2.StatusTypeId = 3))
                                             )
                           )

    SELECT  @InstanceId = wl.InstanceId, @KeyValue = wl.KeyValue, @ActivityId = A.ActivityId,
            @ActivityGuid = A.ActivityGuid, @MaxRetries = A.MaxRetries, @Retries = wl.Retries,
            @ActivityName = A.ActivityName
    FROM    @Data wl
    INNER JOIN cloudcoremodel.vwLiveActivity A with (NOLOCK)
	   ON A.ActivityId = wl.ActivityId
END
