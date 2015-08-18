CREATE PROCEDURE [cloudcore].[CampaignCancel]
	@CampaignID int,
	@UserId int
as
begin
	begin transaction
	begin try
		insert into [cloudcore].CampaignArchive(CampaignID, InstanceId, StatusID, Finished, UserId)
		select CampaignID, InstanceId, 1, GETDATE(), @UserId
		  from [cloudcore].CampaignItem 
		 where CampaignID = @CampaignID 
		 
		 delete from [cloudcore].CampaignItem 
		  where CampaignID = @CampaignID 
		  
		update [cloudcore].Campaign 
		   set StatusID = 0
		 where CampaignID = @CampaignID 
	end try
	
	begin catch
		rollback transaction
		
		declare @errstr nvarchar(4000) 
		set @errstr = ERROR_MESSAGE()
		
		raiserror(N'Unable to cancel campaign, unexpected error: %s',18,1, @errstr)
		return
	end catch	
	
	commit transaction
end