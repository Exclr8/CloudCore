CREATE PROCEDURE [cloudcore].[CampaignArc]
	@CampaignID int
as
begin
	if exists (select null
			     from [cloudcore].CampaignItem 
			    where CampaignID = @CampaignID)
	begin
		raiserror(N'Unable to archive campaign, there are active items in the campaign',18, 1) 	
		return
	end
					  
	begin transaction
	begin try
		update [cloudcore].Campaign 
		   set StatusID = 0
		 where CampaignID = @CampaignID 
	end try
	
	begin catch
		rollback transaction
		
		declare @errstr nvarchar(4000) 
		set @errstr = ERROR_MESSAGE()
		
		raiserror(N'Unable to archive campaign, unexpected error: %s',18,1, @errstr)
		return
	end catch	
	
	commit transaction
end