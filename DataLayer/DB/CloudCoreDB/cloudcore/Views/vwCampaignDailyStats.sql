create view [cloudcore].[vwCampaignDailyStats]
as 
select COUNT(InstanceId) Completed, CONVERT(date, Finished) Finished, CampaignID 
from [cloudcore].CampaignArchive
where Status = 'Completed'
group by CONVERT(date,Finished), CampaignID