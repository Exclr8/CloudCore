create view [cloudcoremodel].vwLiveProcess
as
  select LA.ActivityId, LA.ActivityModelId, MA.ActivityTypeId, MA.ActivityName,
         MA.Startable as ActivityStartable, MA.[Priority] as ActivityPriority, MA.DocWait as ActivityDocWait, MA.ActivityGuid,  
         AT.ActivityTypeName, MA.MaxRetries as ActivityMaxRetries, MA.RetryDelayInSeconds as ActivityRetryDelayInSeconds,
         MP.ProcessModelId, 
         MP.ProcessName, RP.ManagerId as ManagerUserId, U.Fullname as ManagerFullname, U.Firstnames as ManagerFirstNames, U.Surname as ManagerSurname, 
         RP.ProcessRevision, RP.ProcessRevisionId, MP.ProcessGuid, 
         SP.SubProcessId, SP.SubProcessName, SP.SubProcessGuid, SM.AssemblyName as SystemAssemblyName, RP.Changed as ProcessLastChanged         
    from [cloudcore].Activity  LA with (NOLOCK)
   inner join [cloudcoremodel].ActivityModel MA with (NOLOCK)
      on MA.ActivityModelId = LA.ActivityModelId
   inner join [cloudcoremodel].ProcessRevision RP with (NOLOCK)
      on RP.ProcessRevisionId = MA.ProcessRevisionId
   inner join [cloudcoremodel].ProcessModel MP with (NOLOCK)
      on MP.ProcessModelId = RP.ProcessModelId
   inner join [cloudcoremodel].SubProcess SP with (NOLOCK)
      on SP.SubProcessId = MA.SubProcessId
   inner join [cloudcore].SystemModule SM with (NOLOCK)
      on sm.SystemModuleId = LA.SystemModuleId
   inner join [cloudcoremodel].ActivityType AT with (NOLOCK)
      on AT.ActivityTypeId = MA.ActivityTypeId
	  inner join [cloudcore].[User] U with (NOLOCK)
      on RP.ManagerId = U.UserId