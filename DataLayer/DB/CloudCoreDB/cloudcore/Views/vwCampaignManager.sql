CREATE VIEW [cloudcore].[vwCampaignManager]
	AS 

select c.CampaignID, c.CampaignName, c.CampaignDesc, c.StatusID, c.ManagerId
  from [cloudcore].Campaign c