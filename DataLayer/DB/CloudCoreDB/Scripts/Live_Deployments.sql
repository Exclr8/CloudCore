ALTER VIEW [cloudcore].[vwActivityAllocationPriority]
	AS
        select distinct 
		CCU.UserId, 
		saa.ApplicationId,
		tao.ActivityId, 
		pm.ProcessGuid,
		ba.ActivityGuid, 
		ba.SubProcessGuid, ba.ActivityTypeId,
		pm.ProcessName,
		SubPM.SubProcessName,
		AM.ActivityName
      from [cloudcore].AccessPoolUser CCU with (nolock)
      inner join [cloudcore].ActivityAllocation tao with (nolock) on tao.AccessPoolId = CCU.AccessPoolId
	  inner join [cloudcore].SystemApplicationAllocation saa with (nolock) on saa.ActivityId =tao.ActivityId
	  inner join [cloudcore].Activity BA with (nolock) on BA.ActivityId = tao.ActivityId and BA.ActivityTypeId = 0  -- only for Pages
	  inner join [cloudcoremodel].ProcessModel PM WITH (NOLOCK) ON BA.ProcessGuid = PM.ProcessGuid
	  inner join [cloudcoremodel].SubProcess SubPM WITH (NOLOCK) ON BA.SubProcessGuid = SubPM.SubProcessGuid
	  inner join [cloudcoremodel].ActivityModel AM WITH (NOLOCK) ON BA.ActivityModelId = AM.ActivityModelId
GO

alter view [cloudcore].vwTasklist as
-- this retrieves the active worklist for the user that is currently logged in
	      select TAP.ActivityId, AL.ActivityTypeId, AL.ActivityTypeName, WL.Assigned, AL.SubProcessName, AL.ProcessRevisionId, WL.Delayed,
				 OpenedBy, WL.UserId AllocatedTo, TAP.UserId, WL.StatusTypeId, TAP.ApplicationId, AL.SubProcessGuid, TAP.ActivityGuid,
				 WL.InstanceId, AL.SubProcessId, AL.ProcessModelId, AL.ProcessName, WL.Activate, WL.Priority, AL.ActivityName, WL.KeyValue, WL.Created, 
				 WL.DocWait
		   from  [cloudcore].vwActivityAllocationPriority AS TAP
			     inner join [cloudcoremodel].vwLiveProcess AL on AL.ActivityId = TAP.ActivityId
				 inner hash join [cloudcore].Worklist WL -- a hash join is used because the work list is usually the larger data set, where the other smaller tables are used as input for the join. In such scenarios this type of join usually works better than the nested loop join.
				    on  WL.ActivityId = TAP.ActivityId 
						and Activate < GETDATE()
				        and ((StatusTypeId = 1 and WL.OpenedBy = TAP.UserId) -- Started
			             or (StatusTypeId = 3 and WL.UserId = TAP.UserId) -- Assigned
			             or (StatusTypeId = 0))
go
