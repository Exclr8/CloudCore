create procedure [cloudcore].[CampaignUserDelete]
	@CampaignID int,
	@UserId int
as
begin
	delete from [cloudcore].CampaignUser 
	where CampaignID = @CampaignID 
	and UserId = @UserId
end