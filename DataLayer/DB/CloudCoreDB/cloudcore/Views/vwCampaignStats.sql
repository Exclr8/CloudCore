create view [cloudcore].vwCampaignStats
as
select c.CampaignID, 'Outstanding' Status, COUNT(InstanceId) Cnt
  from [cloudcore].Campaign c
 inner join [cloudcore].CampaignItem ci
    on c.CampaignID = ci.CampaignID 
 group by c.CampaignID
 union
select c.CampaignID, 'Completed', COUNT(InstanceId)
  from [cloudcore].Campaign c
 inner join [cloudcore].CampaignArchive ca
    on c.CampaignID = ca.CampaignID 
 where ca.Status = 'Completed'
 group by c.CampaignID
 union
select c.CampaignID, 'Cancelled', COUNT(InstanceId)
  from [cloudcore].Campaign c
 inner join [cloudcore].CampaignArchive ca
    on c.CampaignID = ca.CampaignID 
 where ca.Status = 'Cancelled'
 group by c.CampaignID