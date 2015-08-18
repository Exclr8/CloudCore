declare @BuildConfigMode varchar(30) = '$(BuildConfiguration)'

if isnull(@BuildConfigMode, 'Debug') = 'Release'
begin
    declare @stringToPrint varchar(50) 
    set @stringToPrint = 'Build Configuration is in ' + @BuildConfigMode + ' mode. Test data will NOT be generated.'
    print @stringToPrint
    set noexec on;
end
go

declare @BuildConfigMode varchar(30) = '$(BuildConfiguration)'
declare @ModeStringToPrint varchar(100)
set @ModeStringToPrint = 'Build Configuration is in ' + @BuildConfigMode + ' Mode'
print @ModeStringToPrint
go



/**************************************************************************************************** TEST USERS ********************************************/
/**************************************************************************************************** TEST USERS ********************************************/
/**************************************************************************************************** TEST USERS ********************************************/

declare @UserId int

insert into [cloudcore].[User] ([Login], PasswordHash, Email, Initials, Firstnames, Surname, IntAccess, Created, CellNo, PasswordChanged) 
    values ('test', 'zaber', 'f1team@frameworkone.co.za', 'FO', 'Framework', 'One', 1, GETDATE(), '0824951496', GETDATE())

set @UserId = SCOPE_IDENTITY()

update  U
set     U.PasswordHash = cloudcore.CreatePasswordHash(U.UserId, 'password')
from    cloudcore.[user] U
where   U.UserId = @UserId

insert into cloudcore.AccessPoolUser (AccessPoolId, UserId)
   values (0, @UserId)
     


/**************************************************************************************************** TEST WORKFLOW PROCESS *********************************/
/**************************************************************************************************** TEST WORKFLOW PROCESS *********************************/
/**************************************************************************************************** TEST WORKFLOW PROCESS *********************************/

print 'Deploying test (demo) processes...'
go


declare @systemmoduleid int
declare @processmodelid int
declare @processrevision int
declare @processrevisionid int
declare @subprocessid int
declare @activitymodelid int
declare @fromactivitymodelid int
declare @toactivitymodelid int
declare @oldprocessrevisionid int
declare @processguid uniqueidentifier 
declare @replacementid int

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

-- create the model if its new
set @processguid = 'b2318944-d545-41e3-9f97-712310a7b53a'
if not exists(select null from [cloudcoremodel].ProcessModel where ProcessGuid = @processguid)
begin
  insert into [cloudcoremodel].[ProcessModel] ([ProcessGuid], [ProcessName])
       values (@processguid, 'Test Process')

  set @processmodelid = SCOPE_IDENTITY()
  set @processrevision = 1
  set @oldprocessrevisionid = null
end else
begin
  select @processmodelid = ProcessModelId  from [cloudcoremodel].ProcessModel where ProcessGuid = @processguid 
  select @processrevision = max(ProcessRevision) from [cloudcoremodel].ProcessRevision where ProcessModelId = @processmodelid
  select @oldprocessrevisionid = ProcessRevisionId from [cloudcoremodel].ProcessRevision where ProcessModelId = @processmodelid and ProcessRevision = @processrevision
  update [cloudcoremodel].ProcessModel set ProcessName = 'Test Process' where ProcessModelId = @processmodelid
  set @processrevision = @processrevision + 1
end

-- create the new revision
insert into [cloudcoremodel].[ProcessRevision] ([ProcessModelId], [ProcessRevision], [CheckSum], [UserId], [ManagerId], [Changed])
     values (@processmodelid, @processrevision, null, 0, 0, getdate())

set @processrevisionid = SCOPE_IDENTITY()

-- create the new subprocess for each one we found
insert into [cloudcoremodel].[SubProcess] ([ProcessRevisionId], [SubProcessGuid], [SubProcessName])
     values (@processrevisionid, '7c293d3f-bad7-445d-8935-ea78a94421cd', 'Test Subprocess 1')
set @subprocessid = SCOPE_IDENTITY()

-- create each activity for that subprocess (repeat with activity)
insert into [cloudcoremodel].[ActivityModel] ([ProcessRevisionId], [ReplacementId], [ActivityGuid], [SubProcessId], [ActivityName], [ActivityTypeId], [CostTypeId], [Startable], [Priority], [DocWait], [OnlyVisibleAtLocation], [LocationRadius])
     values (@processrevisionid, 0, '31ba9bf0-6bdb-4850-9a92-f9b82ae1b008', @subprocessid, 'Some DB Stuff', '2', 0, '1', '0', '0', '0', null)
set @ActivityModelId = SCOPE_IDENTITY()
-- default to itself on the new model 
update [cloudcoremodel].ActivityModel set ReplacementId = @activitymodelid where ActivityModelId = @activitymodelid

-- create each activity for that subprocess (repeat with activity)
insert into [cloudcoremodel].[ActivityModel] ([ProcessRevisionId], [ReplacementId], [ActivityGuid], [SubProcessId], [ActivityName], [ActivityTypeId], [CostTypeId], [Startable], [Priority], [DocWait], [OnlyVisibleAtLocation], [LocationRadius])
     values (@processrevisionid, 0, 'c9e8e0c2-06ef-4dc1-b51c-9ca6ad1c6d46', @subprocessid, 'CloudcoreUser1', '0', 0, '0', '0', '0', '0', null)
set @ActivityModelId = SCOPE_IDENTITY()
-- default to itself on the new model 
update [cloudcoremodel].ActivityModel set ReplacementId = @activitymodelid where ActivityModelId = @activitymodelid

-- create each flow (repeat)
select @fromactivitymodelid = ActivityModelId from [cloudcoremodel].ActivityModel where ActivityGuid = '31ba9bf0-6bdb-4850-9a92-f9b82ae1b008'
select @toactivitymodelid = ActivityModelId from [cloudcoremodel].ActivityModel where ActivityGuid = 'c9e8e0c2-06ef-4dc1-b51c-9ca6ad1c6d46'

insert into [cloudcoremodel].[FlowModel] ([FlowGuid], [ProcessRevisionId], [FromActivityModelId], [Outcome], [ToActivityModelId], [OptimalFlow], [NegativeFlow], [Storyline])
     values ('e8ea2bed-bfe8-4a45-8b36-c30703348b2a', @processrevisionid, @fromactivitymodelid, '-', @toactivitymodelid, '0', '0', '')

-- create each flow (repeat)
select @fromactivitymodelid = ActivityModelId from [cloudcoremodel].ActivityModel where ActivityGuid = 'c9e8e0c2-06ef-4dc1-b51c-9ca6ad1c6d46'
select @toactivitymodelid = ActivityModelId from [cloudcoremodel].ActivityModel where ActivityGuid = '00000000-0000-0000-0000-000000000000'

insert into [cloudcoremodel].[FlowModel] ([FlowGuid], [ProcessRevisionId], [FromActivityModelId], [Outcome], [ToActivityModelId], [OptimalFlow], [NegativeFlow], [Storyline])
     values ('4cac9e22-77cd-4e25-8183-546e120fc049', @processrevisionid, @fromactivitymodelid, '-', @toactivitymodelid, '0', '0', '')

  -- insert the new ones
  insert into [cloudcore].Activity  ([ActivityModelId]
           ,[ProcessRevisionId]
           ,[SystemModuleId]
           ,[ActivityTypeId]
           ,[OnlyVisibleAtLocation]
		   ,[LocationRadius]
           ,[ActivityGuid]
           ,[SubProcessGuid]
           ,[ProcessGuid])
  select AM.ActivityModelId, AM.ProcessRevisionId, @systemmoduleid,
         AM.ActivityTypeId, AM.OnlyVisibleAtLocation, AM.LocationRadius, AM.ActivityGuid,
		 SP.SubProcessGuid, PM.ProcessGuid

     from [cloudcoremodel].ActivityModel AM
	inner join [cloudcoremodel].SubProcess SP
	  on SP.SubProcessId = AM.SubProcessId
    inner join [cloudcoremodel].ProcessRevision PR
	   on PR.ProcessRevisionId = SP.ProcessRevisionId
    inner join [cloudcoremodel].ProcessModel PM
	   on PM.ProcessModelId = PR.ProcessModelId
	where AM.ActivityGuid not in (select ActivityGuid from [cloudcoremodel].ActivityModel where ProcessRevisionId = @oldprocessrevisionid)
	and AM.ProcessRevisionId = @processrevisionid

-- select old revision info
if (@oldprocessrevisionid is not null)
begin
  -- reset failed activities in this process
  delete from [cloudcore].WorklistFailure where ActivityId in (Select ActivityId from [cloudcore].Activity where ProcessRevisionId = @oldprocessrevisionid)
  update [cloudcore].Worklist set StatusTypeId = 0 where StatusTypeId = 101 and ActivityId in (Select ActivityId from [cloudcore].Activity where ProcessRevisionId = @oldprocessrevisionid)

  -- update the ones that remain
  update A 
     set A.ProcessRevisionId = @processrevisionid,
	     A.ActivityModelId = AM.ActivityModelId,
		 A.OnlyVisibleAtLocation = AM.OnlyVisibleAtLocation,
		 A.LocationRadius = AM.LocationRadius,
		 A.ActivityTypeId = AM.ActivityTypeId
    from [cloudcore].Activity A
   inner join [cloudcoremodel].ActivityModel AM
      on AM.ActivityGuid = A.ActivityGuid
	where A.ProcessRevisionId = @oldprocessrevisionid
	  and AM.ProcessRevisionId = @processrevisionid

  -- delete the ones that get removed 
  update W 
     set W.ActivityId = AN.ActivityId
    from [cloudcore].Worklist W
   inner join [cloudcore].Activity A
      on A.ActivityId = W.ActivityId
   inner join [cloudcoremodel].ActivityModel AM
      on AM.ActivityModelId = A.ActivityModelId
   inner join [cloudcore].Activity AN
      on AN.ActivityModelId = AM.ReplacementId
   where A.ProcessRevisionId = @oldprocessrevisionid

   update AL
     set AL.ActivityId = AN.ActivityId
    from [cloudcore].ActivityAllocation AL
   inner join [cloudcore].Activity A
      on A.ActivityId = AL.ActivityId
   inner join [cloudcoremodel].ActivityModel AM
      on AM.ActivityModelId = A.ActivityModelId
   inner join [cloudcore].Activity AN
      on AN.ActivityModelId = AM.ReplacementId
   where A.ProcessRevisionId = @oldprocessrevisionid

   update AL
     set AL.ActivityId = AN.ActivityId
    from [cloudcore].[SystemApplicationAllocation] AL
   inner join [cloudcore].Activity A
      on A.ActivityId = AL.ActivityId
   inner join [cloudcoremodel].ActivityModel AM
      on AM.ActivityModelId = A.ActivityModelId
   inner join [cloudcore].Activity AN
      on AN.ActivityModelId = AM.ReplacementId
   where A.ProcessRevisionId = @oldprocessrevisionid

   update AL
     set AL.ActivityId = AN.ActivityId
    from [cloudcore].ActivityAllocation AL
   inner join [cloudcore].Activity A
      on A.ActivityId = AL.ActivityId
   inner join [cloudcoremodel].ActivityModel AM
      on AM.ActivityModelId = A.ActivityModelId
   inner join [cloudcore].Activity AN
      on AN.ActivityModelId = AM.ReplacementId
   where A.ProcessRevisionId = @oldprocessrevisionid

   update AL
     set AL.ActivityId = AN.ActivityId
    from [cloudcore].[SystemApplicationAllocation] AL
   inner join [cloudcore].Activity A
      on A.ActivityId = AL.ActivityId
   inner join [cloudcoremodel].ActivityModel AM
      on AM.ActivityModelId = A.ActivityModelId
   inner join [cloudcore].Activity AN
      on AN.ActivityModelId = AM.ReplacementId
   where A.ProcessRevisionId = @oldprocessrevisionid

   delete from [cloudcore].Activity where ProcessRevisionId = @oldprocessrevisionid
end
GO


if exists(select null from sys.sysobjects
where type = 'p' and name = 'CCEvent_31ba9bf0_6bdb_4850_9a92_f9b82ae1b008')
begin
    drop procedure [cloudcore].[CCEvent_31ba9bf0_6bdb_4850_9a92_f9b82ae1b008]
end
GO

create procedure [cloudcore].[CCEvent_31ba9bf0_6bdb_4850_9a92_f9b82ae1b008]
    @InstanceId bigint,
    @KeyValue bigint
as
  begin
    print 'A test activity yeaaah.'
    return
  end
  
GO


/**************************************************************************************************** WORKFLOW INSTANCE DATA ********************************/
/**************************************************************************************************** WORKFLOW INSTANCE DATA ********************************/
/**************************************************************************************************** WORKFLOW INSTANCE DATA ********************************/

print 'Deploying test (demo) process workflow instance test data...'
go

declare @BuildConfigMode varchar(30) = '$(BuildConfiguration)'
declare @NumberOfInstancesDesired bigint = 2500
declare @ActivityGuidToStartWith uniqueidentifier = '31BA9BF0-6BDB-4850-9A92-F9B82AE1B008'

declare @KeyValue bigint = 1, @UserId int = 0, @InstanceId bigint

while @KeyValue <= @NumberOfInstancesDesired
begin
	exec cloudcore.ActivityStart @ActivityGuidToStartWith, @KeyValue, @UserId, @InstanceId out
	set @KeyValue = @KeyValue + 1
end
go



/***************************************************************** SCHEDULED TASKS ******************************************/
/***************************************************************** SCHEDULED TASKS ******************************************/
/***************************************************************** SCHEDULED TASKS ******************************************/

print 'Deploying test (demo) scheduled tasks...'
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

if exists(select null from sys.sysobjects
where type = 'p' and name = 'CCScheduledTask_d37e5a1e_0983_4892_869f_60b00baf722f')
begin
    drop procedure [cloudcore].[CCScheduledTask_d37e5a1e_0983_4892_869f_60b00baf722f]
end
GO

create procedure [cloudcore].[CCScheduledTask_d37e5a1e_0983_4892_869f_60b00baf722f]
as
begin
    declare @SecondsToRun int = 4,
            @EndDateTime datetime

    select @EndDateTime = dateadd(second, @SecondsToRun, getdate())
    while getdate() < @EndDateTime
    begin
        print 'Simulating time passing for test scheduled task...'
    end
end
go



/***************************************************************** SYSTEM VALUES ********************************************/
/***************************************************************** SYSTEM VALUES ********************************************/
/***************************************************************** SYSTEM VALUES ********************************************/

set identity_insert [cloudcore].SystemValueCategory on
go

insert into [cloudcore].SystemValueCategory(CategoryId, [CategoryName])
values
(5, 'ClickatellSettings'),
(6, 'MySettingsWithIntegers'),
(7, 'MySettingsWithDateTime'),
(8, 'MySettingsWithTypeDouble'),
(9, 'MySettingsUpdated'),
(10, 'MySettingsSave')

go

set identity_insert [cloudcore].SystemValueCategory off
go

insert into [cloudcore].SystemValue ([CategoryId], [ValueName], [ValueData], [ValueDescription])
values
(5, 'Username', 'myusername', 'Clicaktell Username'),
(5, 'Password', 'mypassword', 'Clicaktell Password'),
(5, 'ApiKey', 'myapikey', 'Clicaktell ApiKey'),
(6, 'NumberValue', '2', 'NumberValue'),
(7, 'DateTimeValue', '2009-10-17 14:31:27', 'DateTimeValue'),
(8, 'DoubleValue', '2.7', 'DoubleValue'),
(9, 'CanBeUpdated', 'TestValue', 'TestValue'),
(10, 'A', '1', 'A'),
(10, 'B', '2', 'B'),
(10, 'C', '3', 'C')
go



/**************************************************************** SYSTEM ACTIONS ********************************************/
/**************************************************************** SYSTEM ACTIONS ********************************************/
/**************************************************************** SYSTEM ACTIONS ********************************************/

--insert into [cloudcore].SystemAction (ActionGuid, SystemModuleId, ActionType, Area, Controller, [Action], ActionTitle) values
--('622A2620-769B-416B-B16A-57B93098BFD4' , 1 ,'Create', 'Area51', 'Controller51', 'Action51', 'Title51')



/**************************************************************** NOTIFICATIONS *********************************************/
/**************************************************************** NOTIFICATIONS *********************************************/
/**************************************************************** NOTIFICATIONS *********************************************/

declare @NotificationId int
insert into cloudcore.[Notification] ([Subject], [Message], Creator)
    values ('Welcome', 'Welcome to CloudCore. Enjoy your stay.', 0)

set @NotificationId = SCOPE_IDENTITY()

insert into cloudcore.UserNotification (UserId, NotificationId)
    select  UserId, @NotificationId
    from    cloudcore.[User]
go



/************************************************************ END OF TEST DATA **********************************************/
/************************************************************ END OF TEST DATA **********************************************/
/************************************************************ END OF TEST DATA **********************************************/

set noexec off;
go
