

alter table [cloudcore].[ScheduledTask]
	drop  column [Status]
GO

alter table [cloudcore].[ScheduledTask]
	add [Status] AS (case [StatusId] when (0) then 'Scheduled' when (1) then 'Running' when (101) then 'Failed' when (100) then 'Disabled' else 'Unknown' end)
GO

alter table [cloudcore].[Worklist]
	add [Retries] INT CONSTRAINT [DF_Worklist_Retries] DEFAULT 0 NOT NULL
GO

alter table [cloudcore].[ScheduledTask]
	add [Retries] INT CONSTRAINT [DF_ScheduledTask_Retries] DEFAULT (0) NOT NULL,
		[MaxRetries] INT CONSTRAINT [DF_ScheduledTask_MaxRetries] DEFAULT (0) NOT NULL,
		[RetryDelayInSeconds] INT CONSTRAINT [DF_ScheduledTask_RetryDelayInSeconds] DEFAULT (0) NOT NULL
GO

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
GO

DROP INDEX [IX_Worklist_KeyValue] on [cloudcore].[Worklist]
GO

DROP INDEX [IX_Worklist_Priority_Activate] on [cloudcore].[Worklist]
GO

CREATE NONCLUSTERED INDEX [IX_Worklist_KeyValue]
    ON [cloudcore].[Worklist]([KeyValue] ASC)
    INCLUDE([UserId], [OpenedBy], [StatusTypeId], [ActivityId]);
GO

CREATE NONCLUSTERED INDEX [IX_Worklist_Priority_Activate]
    ON [cloudcore].[Worklist]([Priority] DESC, [Activate] ASC)
    INCLUDE([UserId], [OpenedBy], [ActivityId], [StatusTypeId], [DocWait], [KeyValue]);
GO

drop table [cloudcore].[WorklistFailure]
GO

CREATE TABLE [cloudcore].[WorklistFailure] (
    [WorklistFailureId] BIGINT        IDENTITY (1, 1) NOT NULL,
    [InstanceId]        BIGINT        NOT NULL,
    [ActivityId]        INT           NOT NULL,
    [KeyValue]          BIGINT        NOT NULL,
    [FailedAt]          DATETIME      CONSTRAINT [DF_ActivityFailed_FailedAt] DEFAULT (getdate()) NOT NULL,
    [UserId]            INT           NOT NULL,
    [Reason]            VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_ActivityFailed] PRIMARY KEY CLUSTERED ([WorklistFailureId] ASC),
    CONSTRAINT [FK_ActivityFailed_Activity] FOREIGN KEY ([ActivityId]) REFERENCES [cloudcore].[Activity] ([ActivityId]),
    CONSTRAINT [FK_ActivityFailed_User] FOREIGN KEY ([UserId]) REFERENCES [cloudcore].[User] ([UserId]),
    CONSTRAINT [FK_WorklistFailure_Worklist] FOREIGN KEY ([InstanceId]) REFERENCES [cloudcore].[Worklist] ([InstanceId])
);
GO

CREATE TRIGGER [cloudcore].[WorklistFailureInsert]
    ON [cloudcore].[WorklistFailure]
    FOR INSERT
    AS
    BEGIN
        
		insert into cloudcore.ActivityFailureHistory (ActivityModelId, FailedAt, UserId, Reason, KeyValue)
		select a.ActivityModelId, ins.FailedAt, ins.UserId, ins.Reason, ins.KeyValue
		  from cloudcore.Activity a
		 inner join inserted ins on a.ActivityId = ins.ActivityId

    END
GO

alter table [cloudcoremodel].[ActivityModel]
	add [MaxRetries] INT CONSTRAINT [DF_ActivityModel_MaxRetries] DEFAULT (0) NOT NULL,
		[RetryDelayInSeconds] INT CONSTRAINT [DF_ActivityModel_RetryDelayInSeconds] DEFAULT (0) NOT NULL
GO

ALTER VIEW [cloudcoremodel].[vwLiveActivity]
as
  select LA.ActivityId, 
		 LA.ActivityModelId, 
         MA.ActivityTypeId, 
		 AT.ActivityTypeName, 
		 MA.ActivityName, 
		 MA.Startable, 
		 MA.[Priority], 
		 MA.DocWait, 
		 MA.ActivityGuid, 
		 SM.SystemModuleId, 
		 SM.AssemblyName as SystemAssemblyName,
		 MA.SubProcessId, 
		 MA.ProcessRevisionId, 
		 SP.SubProcessName, 
		 MA.MaxRetries, 
		 MA.RetryDelayInSeconds,
		 MA.IsLocationAware
    from [cloudcore].Activity LA with (nolock)
   inner join [cloudcoremodel].ActivityModel MA with (nolock)
      on MA.ActivityModelId = LA.ActivityModelId
   inner join [cloudcoremodel].SubProcess SP with (nolock)
      on SP.SubProcessId = MA.SubProcessId
   inner join [cloudcore].SystemModule SM with (nolock)
      on sm.SystemModuleId = LA.SystemModuleId
   inner join [cloudcoremodel].ActivityType AT with (nolock)
      on AT.ActivityTypeId = MA.ActivityTypeId
GO

ALTER PROCEDURE [cloudcore].[RestartFailedWorklistItemByActivity]
	@ActivityId int	
AS
begin
	update w
	   set StatusTypeId = 0
	  from cloudcore.Worklist w
	 inner join cloudcoremodel.StatusType st on w.StatusTypeId = st.StatusTypeId
	 where st.StatusTypeName = 'Failed'
end
GO

ALTER PROCEDURE [cloudcore].[ScheduledTaskExecutionFailed]
	@ScheduledTaskId int,
	@Reason varchar(max),
	@StatusId int
as
  begin

	if (@StatusId not in (42,101))
	BEGIN
		Raiserror('Invalid status type specified for scheduled task failure update',16,1)
		RETURN
	END
	insert into cloudcore.ScheduledTaskFailed (ScheduledTaskId, Reason)
         values (@ScheduledTaskId, @Reason)

	if (@@ROWCOUNT > 0)
	  begin
		update cloudcore.ScheduledTask
		   set StatusId = @StatusId
		 where ScheduledTaskId = @ScheduledTaskId
	  end
  end
GO

ALTER PROCEDURE [cloudcore].[ScheduledTaskListGet]

	@StatusId INT
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
						 END
    OUTPUT  INSERTED.ScheduledTaskId,
            INSERTED.ScheduledTaskGuid,
            INSERTED.ScheduledTaskTypeId,
			inserted.ScheduledTaskName,
			INSERTED.Retries,
			INSERTED.MaxRetries,
			inserted.RetryDelayInSeconds
    INTO    @Data (ScheduledTaskId, ScheduledTaskGuid, ScheduledTaskTypeId, ScheduledTaskName, Retries, MaxRetries, RetryDelayInSeconds)
    FROM    cloudcore.ScheduledTask st WITH (ROWLOCK, READPAST, UPDLOCK) 
    WHERE  (st.NextRunDate < @Now or st.OnDemand = 1) and st.StatusId = @StatusId

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

ALTER PROCEDURE [cloudcore].[WorkItemFail]
	@InstanceId bigint,
	@Reason varchar(max),
	@StatusTypeId int
as
  begin
	
	if (@StatusTypeId not in (42, 101))
	begin
		raiserror('Invalid status type specified for work list failure update',16,1)
		return
	end
	
	insert into cloudcore.WorklistFailure(InstanceId, KeyValue, UserId, ActivityId, Reason)
	select @InstanceId, WL.KeyValue, WL.UserId, WL.ActivityId, @Reason
	  from cloudcore.Worklist WL
	 where WL.InstanceId = @InstanceId

	if (@@ROWCOUNT > 0)
	  begin
		update W
		   set StatusTypeId = @StatusTypeId,
			   Activate = CASE WHEN @StatusTypeId = 42
						  THEN dateadd(second,AV.RetryDelayInSeconds, Getdate())
						  ELSE Activate						  
						  END
		   from cloudcore.Worklist as W 
		   inner join cloudcoremodel.vwLiveActivity as AV 
			  on AV.ActivityId = W.ActivityId  
		 where InstanceId = @InstanceId
	  end
  end
GO

ALTER PROCEDURE [cloudcore].[WorkItemStartFromVirtualWorker]
	@ApplicationId   INT,
	@StatusTypeId	 INT = 0,
    @ActivityGuid    UNIQUEIDENTIFIER OUTPUT,
	@ActivityId      INT OUTPUT,
    @InstanceId      BIGINT OUTPUT,
    @KeyValue        BIGINT OUTPUT,
	@MaxRetries		 INT OUTPUT,
	@Retries		 INT OUTPUT
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
						 ELSE wl.Retries END 
    OUTPUT  INSERTED.InstanceId,
            INSERTED.KeyValue,
            INSERTED.ActivityId,
			INSERTED.Retries
    INTO    @Data (InstanceId, KeyValue, ActivityId, Retries)
    FROM    cloudcore.Worklist wl WITH (ROWLOCK, READPAST, UPDLOCK, INDEX(IX_Worklist_Priority_Activate)) 
	INNER JOIN cloudcoremodel.vwLiveActivity A with (NOLOCK)
	   ON A.ActivityId = wl.ActivityId
	WHERE  wl.Activate < @Now 
      AND  A.ActivityTypeId not in (0, 1) -- not a user activity 
      AND  (wl.StatusTypeId = @StatusTypeId)
	  AND  ((@StatusTypeId = 42 and wl.Retries < A.MaxRetries) or (@StatusTypeId != 42))


    SELECT  @InstanceId = wl.InstanceId, @KeyValue = wl.KeyValue, @ActivityId = A.ActivityId,
            @ActivityGuid = A.ActivityGuid, @MaxRetries = A.MaxRetries, @Retries = wl.Retries
    FROM    @Data wl
    INNER JOIN cloudcoremodel.vwLiveActivity A with (NOLOCK)
	   ON A.ActivityId = wl.ActivityId
end
GO

ALTER PROCEDURE [cloudcore].[WorkItemStartFromVirtualWorkerByLocation]
	@ApplicationId   INT,
	@StatusTypeId	 INT = 0,
	@ActivityGuid    UNIQUEIDENTIFIER OUTPUT,
	@ActivityId      INT OUTPUT,
    @InstanceId      BIGINT OUTPUT,
    @KeyValue        BIGINT OUTPUT,
	@Latitude		 DECIMAL(13,10),
	@Longitude		 DECIMAL(13,10),
	@RadiusInMeters  INT,
	@MaxRetries		 INT OUTPUT,
	@Retries		 INT OUTPUT
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
						 ELSE wl.Retries END 
    OUTPUT  INSERTED.InstanceId,
            INSERTED.KeyValue,
            INSERTED.ActivityId,
			INSERTED.Retries
    INTO    @Data (InstanceId, KeyValue, ActivityId, Retries)
    FROM    cloudcore.Worklist wl WITH (ROWLOCK, READPAST, UPDLOCK, INDEX(IX_Worklist_Priority_Activate)) 
	INNER JOIN cloudcoremodel.vwLiveActivity A with (NOLOCK)
	   ON A.ActivityId = wl.ActivityId
    WHERE  wl.Activate < @Now 
      AND  A.ActivityTypeId not in (0, 1) -- not a user activity
	  AND  A.IsLocationAware = 1
      AND  (wl.StatusTypeId = @StatusTypeId)
	  AND  ((@StatusTypeId = 42 and wl.Retries < A.MaxRetries) or (@StatusTypeId != 42))
	  AND  @LocationPoint.STDistance(wl.Location) * 100000 <= @RadiusInMeters


    SELECT  @InstanceId = wl.InstanceId, @KeyValue = wl.KeyValue, @ActivityId = A.ActivityId,
            @ActivityGuid = A.ActivityGuid, @MaxRetries = A.MaxRetries, @Retries = wl.Retries
    FROM    @Data wl
    INNER JOIN cloudcoremodel.vwLiveActivity A with (NOLOCK)
	   ON A.ActivityId = wl.ActivityId
	   
END
GO

CREATE PROCEDURE [cloudcore].[ActivityRetryUpdate]

 @ActivityId int,
 @MaxRetries int,
 @RetryDelayInSeconds int

AS
BEGIN

	Update AM
	set 
		MaxRetries = @MaxRetries,
		RetryDelayInSeconds = @RetryDelayInSeconds
	from cloudcoremodel.ActivityModel as AM
	inner join cloudcore.Activity as A
		on A.ActivityModelId = AM.ActivityModelId
	where
		A.ActivityId = @ActivityId

END
GO