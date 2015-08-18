IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cloudcore].[ScheduledTaskBackup]') AND type in (N'U'))
DROP TABLE [cloudcore].ScheduledTaskBackup
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cloudcore].[ScheduledTaskBackup]') AND type in (N'U'))
BEGIN
CREATE TABLE [cloudcore].[ScheduledTaskBackup](
	[ScheduledTaskId] [int] NOT NULL,
	[ScheduledTaskGuid] [uniqueidentifier] NOT NULL,
	[ScheduledTaskName] [varchar](50) NOT NULL,
	[ScheduledTaskTypeId] [tinyint] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Started] [datetime] NULL,
	[StatusId] [tinyint] NOT NULL,
	[Active] [bit] NOT NULL,
	[OnDemand] [bit] NOT NULL,
	[IntervalType] [tinyint] NOT NULL,
	[IntervalValue] [int] NOT NULL,
	[InitDate] [datetime] NOT NULL,
	[NextRunDate] [datetime] NOT NULL,
	[ScheduledTaskGroupId] [int] NOT NULL,
	[SystemModuleId] [int] NOT NULL,
	[NotifyEmail] [varchar](255) NOT NULL,
	[Retries] [int] NOT NULL,
	[MaxRetries] [int] NOT NULL,
	[RetryDelayInSeconds] [int] NOT NULL
 CONSTRAINT [PK_ScheduledTaskBackup] PRIMARY KEY CLUSTERED 
(
	[ScheduledTaskId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cloudcore].[ScheduledTaskFailedBackup]') AND type in (N'U'))
DROP TABLE [cloudcore].[ScheduledTaskFailedBackup]
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cloudcore].[ScheduledTaskFailedBackup]') AND type in (N'U'))
BEGIN
CREATE TABLE [cloudcore].[ScheduledTaskFailedBackup](
	[ScheduledTaskFailedId] [bigint] NOT NULL,
	[ScheduledTaskId] [int] NOT NULL,
	[FailedAt] [datetime] NOT NULL,
	[Reason] [varchar](max) NOT NULL,
 CONSTRAINT [PK_ScheduledTaskFailedBackup] PRIMARY KEY CLUSTERED 
(
	[ScheduledTaskFailedId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cloudcore].[ScheduledTaskGroupBackup]') AND type in (N'U'))
DROP TABLE [cloudcore].[ScheduledTaskGroupBackup]
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cloudcore].[ScheduledTaskGroupBackup]') AND type in (N'U'))
BEGIN
CREATE TABLE [cloudcore].[ScheduledTaskGroupBackup](
	[ScheduledTaskGroupId] [int] NOT NULL,
	[ScheduledTaskGroupGuid] [uniqueidentifier] NOT NULL,
	[SystemModuleId] [int] NOT NULL,
	[ScheduledTaskGroupName] [varchar](50) NOT NULL,
	[ManagerUserId] [int] NOT NULL,
 CONSTRAINT [PK_ScheduledTaskGroupBackup] PRIMARY KEY CLUSTERED 
(
	[ScheduledTaskGroupId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO

insert into [cloudcore].[ScheduledTaskGroupBackup] (ScheduledTaskGroupId, [ScheduledTaskGroupGuid], [SystemModuleId], [ScheduledTaskGroupName], [ManagerUserId])
    select  ScheduledTaskGroupId, [ScheduledTaskGroupGuid], [SystemModuleId], [ScheduledTaskGroupName], [ManagerUserId]
    from    [cloudcore].[ScheduledTaskGroup]
go

insert into [cloudcore].ScheduledTaskBackup (ScheduledTaskId, [ScheduledTaskGuid], [ScheduledTaskName], [ScheduledTaskTypeId], [Created], [Started], [StatusId], 
                                         [Active], [OnDemand], [IntervalType], [IntervalValue],[InitDate], [NextRunDate], [ScheduledTaskGroupId], [SystemModuleId], 
                                         NotifyEmail, Retries, MaxRetries, RetryDelayInSeconds)
     
     select ScheduledTaskId, [ScheduledTaskGuid], [ScheduledTaskName], [ScheduledTaskTypeId], [Created], [Started], [StatusId], 
            [Active], [OnDemand], [IntervalType], [IntervalValue], [InitDate], [NextRunDate], [ScheduledTaskGroupId], [SystemModuleId], 
            NotifyEmail, Retries, MaxRetries, RetryDelayInSeconds
    from    cloudcore.[ScheduledTask]
go

insert into [cloudcore].ScheduledTaskFailedBackup (ScheduledTaskFailedId, FailedAt, Reason, ScheduledTaskId)
    select  ScheduledTaskFailedId, FailedAt, Reason, ScheduledTaskId
    from    cloudcore.ScheduledTaskFailed
go

delete from cloudcore.ScheduledTaskFailed
go
delete from cloudcore.ScheduledTask
go
delete from cloudcore.ScheduledTaskGroup
go

declare @systemmoduleid int
declare @scheduledtaskgroupguid uniqueidentifier = 'd2ba6fb1-832d-4d5f-b561-09fd5d5b7545'
declare @scheduledtaskgroupid int

if exists(select null from [cloudcore].SystemModule where SystemModuleGuid = '6135587c-d2c4-4fe3-bfc6-5d5427a7720f')
    begin
      select @systemmoduleid = SystemModuleId
      from    cloudcore.SystemModule
      where SystemModuleGuid = '6135587c-d2c4-4fe3-bfc6-5d5427a7720f'
    end
else
    begin
      insert into [cloudcore].SystemModule(AssemblyName, SystemModuleGuid)
      values('CloudCore.ProcessTest', '6135587c-d2c4-4fe3-bfc6-5d5427a7720f')

      set @systemmoduleid = scope_identity()
    end

-- create or update scheduled task group
if not exists(select null from [cloudcore].[ScheduledTaskGroup] where [ScheduledTaskGroupGuid] = @scheduledtaskgroupguid)
begin
  insert into [cloudcore].[ScheduledTaskGroup] ([ScheduledTaskGroupGuid], [SystemModuleId], [ScheduledTaskGroupName], [ManagerUserId])
  values (@scheduledtaskgroupguid, @systemmoduleid, 'Test', 0)
  set @scheduledtaskgroupid = SCOPE_IDENTITY()
end else
begin
  select @scheduledtaskgroupid = ScheduledTaskGroupId from [cloudcore].[ScheduledTaskGroup] where ScheduledTaskGroupGuid = @scheduledtaskgroupguid
  update [cloudcore].[ScheduledTaskGroup] set ScheduledTaskGroupName = 'Test' where ScheduledTaskGroupId = @scheduledtaskgroupid
end

-- insert (only!) newly created scheduled tasks
insert into [cloudcore].[ScheduledTask] ([ScheduledTaskGuid], [ScheduledTaskName], [ScheduledTaskTypeId], [Created], [Started], [StatusId], [Active], [OnDemand], [IntervalType], [IntervalValue]
           ,[InitDate], [NextRunDate], [ScheduledTaskGroupId], [SystemModuleId])
     VALUES
           ('d37e5a1e-0983-4892-869f-60b00baf722f', 'SqlScheduledTask1', '0', getdate(), getdate() - 365, 1, 1, 0, 6, '3', getdate() - 365, getdate() - 365, @scheduledtaskgroupid, @systemmoduleid)

-- insert (only!) newly created scheduled tasks
insert into [cloudcore].[ScheduledTask] ([ScheduledTaskGuid], [ScheduledTaskName], [ScheduledTaskTypeId], [Created], [Started], [StatusId], [Active], [OnDemand], [IntervalType], [IntervalValue]
           ,[InitDate], [NextRunDate], [ScheduledTaskGroupId], [SystemModuleId])
     VALUES
           ('092dbe81-ac1e-4ad2-8e84-700dfa18fc11', 'CSharpScheduledTask1', '1', getdate(), getdate() - 365, 1, 1, 0, 6, '5', getdate() - 365, getdate() - 365, @scheduledtaskgroupid, @systemmoduleid)

GO
