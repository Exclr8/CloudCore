CREATE VIEW [cloudcore].[vwActivityAllocationPriority]
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
