

drop PROCEDURE [cloudcore].[ScheduledTaskActivate]
go

drop PROCEDURE [cloudcore].[ScheduledTaskExecutionFailed]
go

drop PROCEDURE [cloudcore].[ScheduledTaskFinish]
go

drop PROCEDURE [cloudcore].[ScheduledTaskListGet]
go

drop PROCEDURE [cloudcore].[ScheduledTaskUpdate]
go

alter table cloudcore.ScheduledTask add
    [KeepAliveDate]        DATETIME         CONSTRAINT [DF_ScheduledTask_KeepAliveDate] DEFAULT (0) NOT NULL,
    [DateCompleted]        DATETIME         NULL,
    [TimeTakenInSeconds]   AS               case when isnull([Started], 1) > isnull(DateCompleted, 0) then 'Not Completed Yet' else cast(datediff(second, [Started], DateCompleted) as varchar(20)) end
go


alter table cloudcore.ScheduledTask add CONSTRAINT [CK_ScheduledTask_IntervalValue] CHECK (IntervalValue > 0)
go

alter table cloudcore.Worklist alter column PInstanceId BIGINT NOT NULL
go

alter table cloudcore.Worklist add
    [KeepAliveDate]      DATETIME         CONSTRAINT [DF_Worklist_KeepAliveDate] DEFAULT (0) NOT NULL,
    [DateCompleted]      DATETIME         NULL,
    [TimeTakenInSeconds] AS               case when isnull(Opened, 1) > isnull(DateCompleted, 0) then 'Not Completed Yet' else cast(datediff(second, Opened, DateCompleted) as varchar(20)) end
go

alter TRIGGER [cloudcore].[WorkItemUpdate]
    ON [cloudcore].[Worklist]
    FOR UPDATE
    AS 
begin
   SET NOCOUNT ON
   
   if update(StatusTypeId)
   begin
    
 	  insert into [cloudcore].[ActivityHistory]
 	         (InstanceId, ActivityModelId, Assigned, Activate, Opened, Priority, StatusTypeId, UserId,FlowModelId,PInstanceId) 
      select distinct WL.InstanceId, WL.ActivityModelId, WL.Assigned, WL.Activate, WL.Opened, 0, 99, 0, FM.FlowModelId,WL.PInstanceId
        from [cloudcore].vwWorklist WL
        INNER JOIN cloudcoremodel.ActivityModel AM ON WL.ActivityGuid = AM.ActivityGuid
		INNER JOIN cloudcoremodel.FlowModel FM ON AM.ActivityModelId = FM.FromActivityModelId
        inner join inserted INS on INS.InstanceId = WL.InstanceId
	   where INS.StatusTypeId = 99


	  insert into [cloudcore].[ProcessHistory] (InstanceId, PInstanceId, ProcessModelId, [KeyValue], [Started], StatusId) 
	  select WL.InstanceId, WL.PInstanceId, WL.ProcessModelId, WL.KeyValue, WL.Created, 99
        from [cloudcore].vwWorklist WL
       inner join inserted INS on INS.InstanceId = WL.InstanceId
	   where INS.StatusTypeId = 99

      if exists (select null from DELETED)
	  begin
		  -- To Clean Up Worklist Failure on Retry
		  delete af
		  from [cloudcore].WorklistFailure af
		  inner join deleted del on af.InstanceId = del.InstanceId
		  inner join inserted ins on af.InstanceId = ins.InstanceId
		  where del.StatusTypeId in (42, 101) and ins.StatusTypeId = 0

		  update wl
		  set    wl.Retries = 0
		  from  cloudcore.Worklist wl
		  inner join deleted del on wl.InstanceId = del.InstanceId
		  inner join inserted ins on wl.InstanceId = ins.InstanceId
		  where del.StatusTypeId in (42, 101) and ins.StatusTypeId = 0
	  end

	  -- To Clean Up Worklist Failure on Cancel
	  delete af
	  from [cloudcore].WorklistFailure af
	  inner join inserted ins on af.InstanceId = ins.InstanceId
	  where ins.StatusTypeId = 99
  
    -- now remove the records
	delete WL
       from [cloudcore].Worklist WL
      inner join INSERTED INS
         on INS.InstanceId = WL.InstanceId
      where INS.StatusTypeId = 99
   end
end
go

alter PROCEDURE [cloudcore].[WorkItemStartFromVirtualWorker]
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
                                        AND   A.ActivityTypeId not in (0, 1) -- not a user activity 
	                                    AND  (
                                                (@StatusTypeId = 42 and w2.Retries < A.MaxRetries AND w2.StatusTypeId = @StatusTypeId) -- 
                                                
                                                OR 
                                                
                                                (@StatusTypeId != 42 and w2.StatusTypeId in (@StatusTypeId, 3))
                                             )
                           )

    SELECT  @InstanceId = wl.InstanceId, @KeyValue = wl.KeyValue, @ActivityId = A.ActivityId,
            @ActivityGuid = A.ActivityGuid, @MaxRetries = A.MaxRetries, @Retries = wl.Retries,
            @ActivityName = A.ActivityName
    FROM    @Data wl
    INNER JOIN cloudcoremodel.vwLiveActivity A with (NOLOCK)
	   ON A.ActivityId = wl.ActivityId
END
GO

alter PROCEDURE [cloudcore].[WorkItemStartFromVirtualWorkerByLocation]
    @ApplicationId   INT,
	@StatusTypeId	 INT = 0,
    @KeepAliveTimeOutInSeconds int = 900,
	@ActivityGuid    UNIQUEIDENTIFIER OUTPUT,
	@ActivityId      INT OUTPUT,
    @InstanceId      BIGINT OUTPUT,
    @KeyValue        BIGINT OUTPUT,
	@Latitude		 DECIMAL(13,10),
	@Longitude		 DECIMAL(13,10),
	@RadiusInMeters  INT,
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

	if(@Latitude = null)
	BEGIN
		set @Latitude = 0
	END
	if(@Longitude = null)
	BEGIN
		set @Longitude = 0
	END
	
	DECLARE @LocationPoint as geometry = geometry::Point(@Latitude,@Longitude,0);
	

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
                                        AND   A.ActivityTypeId not in (0, 1) -- not a user activity 
	                                    AND  @LocationPoint.STDistance(w2.Location) * 100000 <= @RadiusInMeters
                                        AND  (
                                                (@StatusTypeId = 42 and w2.Retries < A.MaxRetries AND w2.StatusTypeId = @StatusTypeId) -- 
                                                
                                                OR 
                                                
                                                (@StatusTypeId != 42 and w2.StatusTypeId in (@StatusTypeId, 3))
                                             )
                           )
	 
    SELECT  @InstanceId = wl.InstanceId, @KeyValue = wl.KeyValue, @ActivityId = A.ActivityId,
            @ActivityGuid = A.ActivityGuid, @MaxRetries = A.MaxRetries, @Retries = wl.Retries,
            @ActivityName = A.ActivityName
    FROM    @Data wl
    INNER JOIN cloudcoremodel.vwLiveActivity A with (NOLOCK)
	   ON A.ActivityId = wl.ActivityId
END
GO

CREATE PROCEDURE [cloudcore].[ResetRunningOutdatedScheduledTasks]
    @KeepAliveTimeOutInSeconds int,
    @RunningStatusId tinyint,
    @RetryStatusId tinyint,
    @PendingStatusId tinyint
AS
BEGIN    
    declare @Orphans table (
        ScheduledTaskGuid uniqueidentifier primary key not null
    )

    declare @TimeOutLimitDate datetime = dateadd(second, (@KeepAliveTimeOutInSeconds * -1), getdate())

    update  S
    set     S.StatusId = @PendingStatusId
    OUTPUT  INSERTED.ScheduledTaskGuid
    INTO    @Orphans (ScheduledTaskGuid)
    from    cloudcore.ScheduledTask S with (readpast)
    where   [StatusId] in (@RunningStatusId, @RetryStatusId)
            and [KeepAliveDate] <= @TimeOutLimitDate

    select  ScheduledTaskGuid 
    from    @Orphans
END
GO

CREATE PROCEDURE [cloudcore].[ResetRunningOutdatedWorkflowItems]
    @KeepAliveTimeOutInSeconds int,
    @RunningStatusId tinyint,
    @RetryStatusId tinyint,
    @PendingStatusId tinyint
AS
BEGIN    
    declare @Orphans table (
        InstanceId bigint primary key not null,
        ActivityId int not null
    )

    declare @TimeOutLimitDate datetime = dateadd(second, (@KeepAliveTimeOutInSeconds * -1), getdate())

    update  W
    set     W.StatusTypeId = @PendingStatusId
    OUTPUT  INSERTED.InstanceId, INSERTED.ActivityId
    INTO    @Orphans (InstanceId, ActivityId)
    from    cloudcore.Worklist W with (readpast)
    inner join cloudcore.vwWorklistEx v with (nolock)
        on  v.InstanceId = w.InstanceId
    where   w.[StatusTypeId] in (@RunningStatusId, @RetryStatusId)
            and w.[KeepAliveDate] <= @TimeOutLimitDate
            and v.ActivityTypeName not in ('Custom User Activity', 'CloudCore User Activity')

    select  InstanceId, ActivityId
    from    @Orphans
END
GO

CREATE PROCEDURE [cloudcore].[ScheduledTaskKeepAlive]
    @ScheduledTaskId int
AS
BEGIN
    update  S
    set     S.KeepAliveDate = getdate()
    from    cloudcore.ScheduledTask S
    where   S.ScheduledTaskId = @ScheduledTaskId
END
GO

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
GO

CREATE PROCEDURE [cloudcore].[ScheduledTaskToggleActiveStatus]
    @ScheduledTaskId int
as
  begin
    update  cloudcore.ScheduledTask
       set  StatusId = case when Active = 0 then 
                                case when StatusId = 101 then 0 else StatusId end
                            else 
                                100
                       end,
            Active = case when Active = 1 then 0 else 1 end
     where  ScheduledTaskId = @ScheduledTaskId
  end
GO

CREATE PROCEDURE [cloudcore].[ScheduledTaskUpdateConfig]
	@ScheduledTaskId int, 
	@ScheduledTaskName varchar(50),
	@IntervalValue int,
	@IntervalType tinyint,
	@NextRunDate datetime = null,
    @NotifyEmail varchar(255),
	@IsActive bit
as
  begin
	
	if exists (select null from cloudcore.ScheduledTask where ScheduledTaskName = @ScheduledTaskName and ScheduledTaskId <> @ScheduledTaskId)
	  begin
		raiserror('A Scheduled Task with the selected name already exists!',16,1)
		return
	  end

	update cloudcore.ScheduledTask
	set ScheduledTaskName = @ScheduledTaskName,
	    IntervalValue = @IntervalValue,
		IntervalType = @IntervalType,
		NextRunDate = isnull(@NextRunDate,NextRunDate),
		Active = @IsActive,
        StatusId = case when @IsActive = 1 then 
                            case when StatusId = 101 then 0 else StatusId end
                        else 
                            100
                   end,
        NotifyEmail = @NotifyEmail
	where ScheduledTaskId = @ScheduledTaskId

  end
GO

CREATE PROCEDURE [cloudcore].[ScheduledTaskUpdateOutcome]
	@ScheduledTaskId int,
	@StatusId int, 
	@Reason varchar(max) = null
as
begin
	if @StatusId not in (0, 42, 101)
    begin
        raiserror('Invalid status ID specified for "ScheduledTaskUpdateOutcome". Allowed values are: 0 (Pending), 42 (Retry) and 101 (Failed).', 16, 1)
        return
    end

    if @StatusId in (42,101)
	BEGIN
        if len(isnull(rtrim(@Reason), '')) = 0
        begin
            raiserror('The @Reason parameter is required when using "ScheduledTaskUpdateOutcome" to indicate @StatusId of Retry (42) or Failure (101).', 16, 1)
            return
        end

	    insert into cloudcore.ScheduledTaskFailed (ScheduledTaskId, Reason)
             values (@ScheduledTaskId, @Reason)
	END

	update  ST
	set     ST.StatusId = @StatusId,
            ST.OnDemand = 0,
	        ST.NextRunDate = case when @StatusId = 0 then [cloudcore].CalculateNextRunDate(ST.InitDate, ST.IntervalType, ST.IntervalValue) else ST.NextRunDate end,
		    ST.InitDate = case when @StatusId = 0 then [cloudcore].CalculateNextInitDate(ST.InitDate, ST.IntervalType, ST.IntervalValue) else ST.InitDate end -- shifting along
    from    cloudcore.ScheduledTask ST
	where   ST.ScheduledTaskId = @ScheduledTaskId
end
GO

CREATE PROCEDURE [cloudcore].[WorkflowKeepAlive]
    @InstanceId bigint
AS
BEGIN
    update  W
    set     W.KeepAliveDate = getdate()
    from    cloudcore.Worklist W
    where   W.InstanceId = @InstanceId
END
GO
