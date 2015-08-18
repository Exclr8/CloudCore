create view [cloudcore].[vwWorklist] as
select WL.InstanceId,
       WL.PInstanceId,
	   WL.StatusTypeId,
	   WL.DocWait,
	   WL.UserId,
	   WL.Priority, 
	   WL.KeyValue, 
	   WL.Activate, 
	   WL.Opened, 
	   WL.Created, 
       AL.ActivityId, 
	   AL.ActivityModelId, 
	   AL.ActivityName, 
	   AL.ActivityStartable, 
	   AL.ActivityTypeId, 
	   AL.ActivityTypeName, 
	   AL.ProcessName, 
	   AL.ProcessModelId, 
	   WL.Assigned, 
	   AL.ProcessGuid, 
	   WL.Delayed,
	   AL.ActivityGuid,
	   AL.SubProcessId,
	   AL.SubProcessName
   from [cloudcore].Worklist WL with (nolock)
 inner join [cloudcoremodel].vwLiveProcess AL with (nolock)
    on AL.ActivityId = WL.ActivityId