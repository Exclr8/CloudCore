CREATE VIEW [cloudcoremodel].[vwLiveActivity]
as
  select LA.ActivityId, 
		 LA.ActivityModelId, 
         MA.ActivityTypeId, 
		 AT.ActivityTypeName, 
		 MA.ActivityName, 
		 MA.Startable, 
		 MA.[Priority], 
		 MA.DocWait, 
		 MA.ActivityGuid, 
		 SM.SystemModuleId, 
		 SM.AssemblyName as SystemAssemblyName,
		 MA.SubProcessId, 
		 MA.ProcessRevisionId, 
		 SP.SubProcessName, 
		 MA.MaxRetries, 
		 MA.RetryDelayInSeconds,
		 MA.OnlyVisibleAtLocation,
		 MA.LocationRadius
    from [cloudcore].Activity LA with (nolock)
   inner join [cloudcoremodel].ActivityModel MA with (nolock)
      on MA.ActivityModelId = LA.ActivityModelId
   inner join [cloudcoremodel].SubProcess SP with (nolock)
      on SP.SubProcessId = MA.SubProcessId
   inner join [cloudcore].SystemModule SM with (nolock)
      on sm.SystemModuleId = LA.SystemModuleId
   inner join [cloudcoremodel].ActivityType AT with (nolock)
      on AT.ActivityTypeId = MA.ActivityTypeId