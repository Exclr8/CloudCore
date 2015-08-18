create view [cloudcore].vwTasklist as
-- this retrieves the active worklist for the user that is currently logged in
	      select TAP.ActivityId, AL.ActivityTypeId, AL.ActivityTypeName, WL.Assigned, AL.SubProcessName, AL.ProcessRevisionId, WL.Delayed,
				 OpenedBy, WL.UserId AllocatedTo, TAP.UserId, WL.StatusTypeId,TAP.ApplicationId, AL.SubProcessGuid, TAP.ActivityGuid,
				 WL.InstanceId, AL.SubProcessId, AL.ProcessModelId, AL.ProcessName, WL.Activate, WL.Priority, AL.ActivityName, WL.KeyValue, WL.Created, 
				 WL.DocWait
		   from  [cloudcore].vwActivityAllocationPriority AS TAP
			     inner join [cloudcoremodel].vwLiveProcess AL on AL.ActivityId = TAP.ActivityId
				 inner hash join [cloudcore].Worklist WL -- a hash join is used because the work list is usually the larger data set, where the other smaller tables are used as input for the join. In such scenarios this type of join usually works better than the nested loop join.
				    on  WL.ActivityId = TAP.ActivityId 
				        and ((StatusTypeId = 1 and WL.OpenedBy = TAP.UserId) -- Started
			             or (StatusTypeId = 3 and WL.UserId = TAP.UserId) -- Assigned
			             or (StatusTypeId = 0))