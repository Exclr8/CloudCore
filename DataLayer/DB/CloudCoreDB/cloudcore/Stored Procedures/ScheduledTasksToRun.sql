CREATE PROCEDURE [cloudcore].[ScheduledTasksToRun]
	@StatusId INT,
    @KeepAliveTimeOutInSeconds int = 900
as
BEGIN
    SET NOCOUNT ON;

    declare @Now DATETIME = getdate()

    declare @Data table
    (
        ScheduledTaskId int not null,
        ScheduledTaskGuid uniqueidentifier not null,
		ScheduledTaskTypeId tinyint not null,
		ScheduledTaskName varchar(50) not null,
		Retries int not null,
		MaxRetries int not null,
		RetryDelayInSeconds int not null
    )

    UPDATE  st
    SET     st.Started = GETDATE(),
	        st.StatusId = 1,
			st.Retries = CASE WHEN st.StatusId = 42
						          THEN st.Retries + 1
						      ELSE st.Retries
						 END,
            st.KeepAliveDate = dateadd(second, @KeepAliveTimeOutInSeconds, getdate())
    OUTPUT  INSERTED.ScheduledTaskId,
            INSERTED.ScheduledTaskGuid,
            INSERTED.ScheduledTaskTypeId,
			inserted.ScheduledTaskName,
			INSERTED.Retries,
			INSERTED.MaxRetries,
			inserted.RetryDelayInSeconds
    INTO    @Data (ScheduledTaskId, ScheduledTaskGuid, ScheduledTaskTypeId, ScheduledTaskName, Retries, MaxRetries, RetryDelayInSeconds)
    FROM    cloudcore.ScheduledTask st WITH (ROWLOCK, READPAST, UPDLOCK) 
    WHERE   (st.NextRunDate < @Now and st.StatusId = @StatusId)
              or 
            (st.OnDemand = 1 and StatusId = 0) -- TODO: Make these hard values parameters for the stored proc (more maintainable)

    SELECT  ScheduledTaskId, 
			ScheduledTaskGuid, 
	        ScheduledTaskTypeId, 
			ScheduledTaskName,
			Retries,
			MaxRetries,
			RetryDelayInSeconds
    FROM    @Data st
end