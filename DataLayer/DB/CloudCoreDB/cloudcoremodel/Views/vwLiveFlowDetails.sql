create view [cloudcoremodel].[vwLiveFlowDetails] as
  select LF.FlowModelId, LF.FlowGuid, LF.FromActivityId, LF.FromActivityModelId, LF.Outcome, LF.ToActivityId, LF.ToActivityModelId, LF.Storyline, LF.NegativeFlow, LF.OptimalFlow,
         FAM.ActivityName FromActivityName, FAT.ActivityTypeName FromActivityType, TAM.ActivityName ToActivityName, TAT.ActivityTypeName ToActivityType, FAM.SubProcessId, FAM.ProcessRevisionId
    from [cloudcoremodel].vwLiveFlow LF with (nolock)
   inner join [cloudcoremodel].ActivityModel FAM with (nolock)
      on FAM.ActivityModelId = LF.FromActivityModelId
   inner join [cloudcoremodel].ActivityModel TAM with (nolock)
      on TAM.ActivityModelId = LF.ToActivityModelId
   inner join [cloudcoremodel].ActivityType FAT with (nolock)
      on FAT.ActivityTypeId = FAM.ActivityTypeId
   inner join [cloudcoremodel].ActivityType TAT with (nolock)
      on TAT.ActivityTypeId = TAM.ActivityTypeId