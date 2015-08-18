delete from cloudcore.ActivityAllocation
go

delete from cloudcore.SystemApplicationAllocation
go

delete from cloudcore.WorklistFailure
go

delete from cloudcore.CostLedger
go

delete from cloudcore.Worklist
go

delete from cloudcoremodel.FlowModel
go

delete from cloudcore.ActivityFailureHistory
go

delete from cloudcore.ActivityHistory
go

delete from cloudcore.ProcessHistory
go

delete from cloudcore.Activity where ActivityId != 0
go

-- select * from cloudcoremodel.ActivityModel
delete from cloudcoremodel.ActivityModel where ActivityGuid != '00000000-0000-0000-0000-000000000000'
go

-- select * from cloudcoremodel.SubProcess
delete from cloudcoremodel.SubProcess where SubProcessGuid != '00000000-0000-0000-0000-000000000000'
go

-- select * from cloudcoremodel.ProcessRevision
delete from cloudcoremodel.ProcessRevision where ProcessRevisionId != 0
go

-- select * from cloudcoremodel.ProcessModel
delete from cloudcoremodel.ProcessModel where ProcessGuid != '00000000-0000-0000-0000-000000000000'
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
insert into [cloudcoremodel].[ActivityModel] ([ProcessRevisionId], [ReplacementId], [ActivityGuid], [SubProcessId], [ActivityName], [ActivityTypeId], [CostTypeId], [Startable], [Priority], [DocWait], [IsLocationAware])
     values (@processrevisionid, 0, '31ba9bf0-6bdb-4850-9a92-f9b82ae1b008', @subprocessid, 'Some DB Stuff', '2', 0, '1', '0', '0', '0')
set @ActivityModelId = SCOPE_IDENTITY()
-- default to itself on the new model 
update [cloudcoremodel].ActivityModel set ReplacementId = @activitymodelid where ActivityModelId = @activitymodelid

-- create each activity for that subprocess (repeat with activity)
insert into [cloudcoremodel].[ActivityModel] ([ProcessRevisionId], [ReplacementId], [ActivityGuid], [SubProcessId], [ActivityName], [ActivityTypeId], [CostTypeId], [Startable], [Priority], [DocWait], [IsLocationAware])
     values (@processrevisionid, 0, 'c9e8e0c2-06ef-4dc1-b51c-9ca6ad1c6d46', @subprocessid, 'CloudcoreUser1', '0', 0, '0', '0', '0', '0')
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
           ,[IsLocationAware]
           ,[ActivityGuid]
           ,[SubProcessGuid]
           ,[ProcessGuid])
  select AM.ActivityModelId, AM.ProcessRevisionId, @systemmoduleid,
         AM.ActivityTypeId, AM.IsLocationAware, AM.ActivityGuid,
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
		 A.IsLocationAware = AM.IsLocationAware,
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
insert into cloudcore.ActivityAllocation (ActivityId, AccessPoolId)
	select	a.ActivityId, p.AccessPoolId
	from	cloudcore.Activity a
	cross join cloudcore.AccessPool p
	where	a.ActivityTypeId in (0, 1)
			and not exists (select null from cloudcore.ActivityAllocation where ActivityId = a.ActivityId and AccessPoolId = p.AccessPoolId);
go

insert into cloudcore.SystemApplicationAllocation (ApplicationId, ActivityId)
	select	ap.ApplicationId, ac.ActivityId
	from	cloudcore.SystemApplication ap
	cross join cloudcore.Activity ac
	where	ac.ActivityTypeId in (0, 1)
			and not exists (select null from cloudcore.SystemApplicationAllocation where ActivityId = ac.ActivityId and ApplicationId = ap.ApplicationId);
go
