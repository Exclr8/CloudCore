CREATE VIEW [cloudcoremodel].[vwLiveFlow]
	AS 
  select FMM.FlowModelId, FMM.FlowGuid, FA.ActivityId FromActivityId, FA.ActivityModelId FromActivityModelId, FMM.Outcome, TA.ActivityId ToActivityId, TA.ActivityModelId ToActivityModelId, FMM.Storyline, FMM.NegativeFlow, FMM.OptimalFlow
    from [cloudcore].Activity FA with (nolock)
   inner join [cloudcoremodel].FlowModel FMM with (nolock)
      on FMM.FromActivityModelId = FA.ActivityModelId
   inner join [cloudcore].Activity TA with (nolock)
      on TA.ActivityModelId = FMM.ToActivityModelId