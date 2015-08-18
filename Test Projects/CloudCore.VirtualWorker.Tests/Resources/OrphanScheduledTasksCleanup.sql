delete from cloudcore.ScheduledTaskFailed
go
delete from cloudcore.ScheduledTask
go
delete from cloudcore.ScheduledTaskGroup
go

set identity_insert cloudcore.ScheduledTaskGroup on

insert into [cloudcore].[ScheduledTaskGroup] (ScheduledTaskGroupId, [ScheduledTaskGroupGuid], [SystemModuleId], [ScheduledTaskGroupName], [ManagerUserId])
    select  ScheduledTaskGroupId, [ScheduledTaskGroupGuid], [SystemModuleId], [ScheduledTaskGroupName], [ManagerUserId]
    from    [cloudcore].[ScheduledTaskGroupBackup]

set identity_insert cloudcore.ScheduledTaskGroup off

set identity_insert cloudcore.ScheduledTask on

insert into [cloudcore].[ScheduledTask] (ScheduledTaskId, [ScheduledTaskGuid], [ScheduledTaskName], [ScheduledTaskTypeId], [Created], [Started], [StatusId], 
                                         [Active], [OnDemand], [IntervalType], [IntervalValue],[InitDate], [NextRunDate], [ScheduledTaskGroupId], [SystemModuleId], KeepAliveDate)
     
    select  ScheduledTaskId, [ScheduledTaskGuid], [ScheduledTaskName], [ScheduledTaskTypeId], [Created], [Started], [StatusId], 
            [Active], [OnDemand], [IntervalType], [IntervalValue], [InitDate], [NextRunDate], [ScheduledTaskGroupId], [SystemModuleId], getdate() + 1
    from    cloudcore.ScheduledTaskBackup

set identity_insert cloudcore.ScheduledTask off

set identity_insert cloudcore.ScheduledTaskFailed on

insert into [cloudcore].ScheduledTaskFailed (ScheduledTaskFailedId, FailedAt, Reason, ScheduledTaskId)
     
     select ScheduledTaskFailedId, FailedAt, Reason, ScheduledTaskId
    from    cloudcore.ScheduledTaskFailedBackup

set identity_insert cloudcore.ScheduledTaskFailed off

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cloudcore].[ScheduledTaskBackup]') AND type in (N'U'))
DROP TABLE [cloudcore].ScheduledTaskBackup
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cloudcore].[ScheduledTaskFailedBackup]') AND type in (N'U'))
DROP TABLE [cloudcore].[ScheduledTaskFailedBackup]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cloudcore].[ScheduledTaskGroupBackup]') AND type in (N'U'))
DROP TABLE [cloudcore].[ScheduledTaskGroupBackup]
GO

