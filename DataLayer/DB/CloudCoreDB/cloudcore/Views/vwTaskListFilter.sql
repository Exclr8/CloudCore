create view [cloudcore].[vwTaskListFilter]
as
select TAP.UserId, BA.ProcessRevisionId,
	   TAP.ActivityId, BA.ActivityName, BA.SubProcessId, BA.SubProcessName
  from [cloudcore].vwActivityAllocationPriority TAP
inner join [cloudcoremodel].[vwLiveActivity] BA
   on BA.ActivityId = TAP.ActivityId