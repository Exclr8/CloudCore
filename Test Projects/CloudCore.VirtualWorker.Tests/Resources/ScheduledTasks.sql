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
           ('d37e5a1e-0983-4892-869f-60b00baf722f', 'SqlScheduledTask1', '0', getdate(), null, 0, 1, 0, 6, '3', getdate(), getdate(), @scheduledtaskgroupid, @systemmoduleid)

-- insert (only!) newly created scheduled tasks
insert into [cloudcore].[ScheduledTask] ([ScheduledTaskGuid], [ScheduledTaskName], [ScheduledTaskTypeId], [Created], [Started], [StatusId], [Active], [OnDemand], [IntervalType], [IntervalValue]
           ,[InitDate], [NextRunDate], [ScheduledTaskGroupId], [SystemModuleId])
     VALUES
           ('092dbe81-ac1e-4ad2-8e84-700dfa18fc11', 'CSharpScheduledTask1', '1', getdate(), null, 0, 1, 0, 6, '5', getdate(), getdate(), @scheduledtaskgroupid, @systemmoduleid)

GO

