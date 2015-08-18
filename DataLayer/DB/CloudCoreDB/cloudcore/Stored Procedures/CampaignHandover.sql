CREATE PROCEDURE [cloudcore].[CampaignHandover]
	@CampaignID int,
	@ManagerId int
as
begin
					  
	begin transaction
	begin try
		update [cloudcore].Campaign 
		   set ManagerId = @ManagerId
		 where CampaignID = @CampaignID 
	end try
	
	begin catch
		rollback transaction
		
		declare @errstr nvarchar(4000) 
		set @errstr = ERROR_MESSAGE()
		
		raiserror(N'Unable to handover campaign, unexpected error: %s',18,1, @errstr)
		return
	end catch	
	
	commit transaction
end