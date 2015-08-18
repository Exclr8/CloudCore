CREATE PROCEDURE [cloudcore].[CampaignItemFinish]
	@InstanceId bigint,
	@UserId int
AS
begin
	insert into [cloudcore].CampaignArchive(CampaignID, InstanceId, StatusID, Finished, UserId)
		select CampaignID, InstanceId, 0, GETDATE(), @UserId
		  from [cloudcore].CampaignItem 
		 where InstanceId = @InstanceId 
		 
		 delete from [cloudcore].CampaignItem 
		  where InstanceId = @InstanceId 
end