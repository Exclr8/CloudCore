create view [cloudcore].[vwWorklistEx] 
as
	select WL.InstanceId, WL.PInstanceId, WL.StatusTypeId, ST.StatusTypeName,WL.DocWait, WL.UserId, WL.OpenedBy,
           WL.Priority, WL.KeyValue, WL.Activate,  WL.Assigned,
           WL.Opened, WL.Created, WL.ActivityId, AL.ActivityModelId, AL.ActivityName, AL.ActivityStartable,
           AL.ActivityTypeId, AL.ProcessRevisionId, AL.ActivityTypeName, AL.ProcessName, 
           AL.ProcessModelId, AL.SubProcessId,  WU.Fullname AS UserName, 
           AL.SubProcessName, AL.ActivityGuid, AL.ProcessGuid, AL.SubProcessGuid
      from cloudcore.Worklist WL with (nolock)
     inner join cloudcoremodel.vwLiveProcess AL 
        on AL.ActivityId = WL.ActivityId 
     inner join cloudcore.[User] WU with (nolock)
        on WU.UserId = WL.UserId
     INNER JOIN cloudcoremodel.StatusType ST with (nolock)
        on WL.StatusTypeId = ST.StatusTypeId
GO


