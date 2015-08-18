CREATE TABLE [cloudcore].[ScheduledTask] (
    [ScheduledTaskId]      INT              IDENTITY (1, 1) NOT NULL,
    [ScheduledTaskGuid]    UNIQUEIDENTIFIER NOT NULL,
    [ScheduledTaskName]    VARCHAR (50)     NOT NULL,
    [ScheduledTaskTypeId]  TINYINT          NOT NULL,
    [ScheduledTaskType]    AS               (case [ScheduledTaskTypeId] when (0) then 'Sql' when (1) then 'CSharp' else 'Unknown' end),
    [Created]              DATETIME         DEFAULT (getdate()) NOT NULL,
    [Started]              DATETIME         NULL,
    [StatusId]             TINYINT          NOT NULL,
    [Status]               AS               (case [StatusId] when (0) then 'Scheduled' when (1) then 'Running' when (101) then 'Failed' when (100) then 'Disabled' when (42) then 'Retry' else 'Unknown' end),
    [Active]               BIT              DEFAULT ((0)) NOT NULL,
    [OnDemand]             BIT              DEFAULT ((0)) NOT NULL,
    [IntervalType]         TINYINT          DEFAULT ((1)) NOT NULL,
    [IntervalTypeName]     AS               (case [IntervalType] when (0) then 'Years' when (1) then 'Months' when (2) then 'Weeks' when (3) then 'Days' when (4) then 'Hours' when (5) then 'Minutes' when (6) then 'Seconds' else 'Days' end),
    [IntervalValue]        INT              NOT NULL,
    [InitDate]             DATETIME         DEFAULT (getdate()) NOT NULL,
    [NextRunDate]          DATETIME         DEFAULT (getdate()) NOT NULL,
    [ScheduledTaskGroupId] INT              NOT NULL,
    [SystemModuleId]       INT              NOT NULL,
	[NotifyEmail]          VARCHAR (255)    CONSTRAINT [DF_Notify_Email] DEFAULT ('') NOT NULL,
	[Retries] int  CONSTRAINT [DF_ScheduledTask_Retries] DEFAULT (0) NOT NULL,
	[MaxRetries] INT CONSTRAINT [DF_ScheduledTask_MaxRetries] DEFAULT (0) NOT NULL,
	[RetryDelayInSeconds] INT CONSTRAINT [DF_ScheduledTask_RetryDelayInSeconds] DEFAULT (0) NOT NULL,
    [KeepAliveDate] DATETIME NOT NULL CONSTRAINT DF_ScheduledTask_KeepAliveDate DEFAULT (0),
    [DateCompleted] DATETIME NULL,
    [TimeTakenInSeconds] as case when isnull([Started], 1) > isnull(DateCompleted, 0) then 'Not Completed Yet' else cast(datediff(second, [Started], DateCompleted) as varchar(20)) end,
    

    CONSTRAINT [PK_ScheduledTask] PRIMARY KEY CLUSTERED ([ScheduledTaskId] ASC),
    CONSTRAINT [CK_ScheduledTask_IntervalType] CHECK ([IntervalType]>=(0) AND [IntervalType]<=(6)),
    CONSTRAINT [CK_ScheduledTask_IntervalValue] CHECK (IntervalValue > 0),
    CONSTRAINT [FK_ScheduledTask_ScheduledTaskGroup] FOREIGN KEY ([ScheduledTaskGroupId]) REFERENCES [cloudcore].[ScheduledTaskGroup] ([ScheduledTaskGroupId]),
    CONSTRAINT [FK_ScheduledTask_SystemModule] FOREIGN KEY ([SystemModuleId]) REFERENCES [cloudcore].[SystemModule] ([SystemModuleId])
);
go

CREATE NONCLUSTERED INDEX [UQ_ScheduledTask_ScheduledTaskGuid_Dates] 
ON [cloudcore].[ScheduledTask] 
(
    [ScheduledTaskGuid]
)
INCLUDE (InitDate, NextRunDate);
GO

create TRIGGER [cloudcore].[ScheduledTaskUpdateTrigger]
    ON [cloudcore].[ScheduledTask]
    FOR UPDATE
    AS 
begin
    if update(StatusId) and exists (select null from DELETED)
    begin
        update  S
        set     S.Retries = 0,
                S.DateCompleted = case when (d.StatusId = 1 OR d.StatusId = 42) then getdate() else NULL end
        from    cloudcore.ScheduledTask S
        inner join inserted i
        on i.ScheduledTaskId = s.ScheduledTaskId
        inner join deleted d
        on d.ScheduledTaskId = i.ScheduledTaskId
        where d.StatusId != i.StatusId
            and i.StatusId = 0

        delete  F
        from    cloudcore.ScheduledTaskFailed F
        inner join inserted i
         on i.ScheduledTaskId = F.ScheduledTaskId
        inner join deleted d
         on d.ScheduledTaskId = F.ScheduledTaskId
         where i.StatusId = 0 -- magic numbers... hmmm, we should move this to the front-end...
         and (d.StatusId = 42 OR d.StatusId = 101) -- magic numbers... hmmm, we should move this to the front-end...
    end
end
go

create TRIGGER [cloudcore].[ScheduledTaskDeleteTrigger]
    ON [cloudcore].[ScheduledTask]
    FOR DELETE
    AS 
begin
    delete  F
    from    cloudcore.ScheduledTaskFailed F
    inner join deleted d
        on d.ScheduledTaskId = F.ScheduledTaskId
end
