create VIEW [cloudcore].[vwCampaign]
AS
select	tl.InstanceId, tl.SubProcessId, tl.ProcessModelId, tl.StatusTypeId, tl.Delayed,
		tl.UserId, tl.Activate, tl.Priority, tl.KeyValue, tl.Created, tl.SubProcessName, tl.ActivityName,
		tl.ActivityId, case when StatusTypeId = 1 then 'Started' when StatusTypeId = 3 then 'Allocated' else 'Offered' end ListType,
		tl.DocWait, ci.CampaignID
   from [cloudcore].vwTasklist tl
  inner join [cloudcore].CampaignItem ci
	 on tl.InstanceId = ci.InstanceId 
  inner join [cloudcore].CampaignUser cu
	 on ci.CampaignID = cu.CampaignID 
	and tl.UserId = cu.UserId