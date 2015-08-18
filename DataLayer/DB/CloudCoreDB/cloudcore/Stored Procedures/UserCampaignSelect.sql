CREATE PROCEDURE [cloudcore].[UserCampaignSelect]
	@UserId int = 0, 
	@CampaignId int
AS
BEGIN
    update CU
    set     CU.Active = (case when CampaignID = @CampaignId then 1 else 0 end)
    from    cloudcore.CampaignUser CU
    where   CU.UserId = @UserId
END