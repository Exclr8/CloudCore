create procedure [cloudcore].[CampaignUserCreate]
	@CampaignID int,
	@UserId int
as
begin
	insert into [cloudcore].CampaignUser (CampaignID, UserId)
	values (@CampaignID, @UserId)
end