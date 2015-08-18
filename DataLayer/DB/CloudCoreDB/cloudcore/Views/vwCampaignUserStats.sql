create VIEW [cloudcore].[vwCampaignUserStats]
	AS 
select COUNT(InstanceId) Completed, CONVERT(date, Finished) Finished, UserId,  CampaignID 
from [cloudcore].CampaignArchive
where Status = 'Completed'
group by CONVERT(date,Finished), CampaignID, UserId