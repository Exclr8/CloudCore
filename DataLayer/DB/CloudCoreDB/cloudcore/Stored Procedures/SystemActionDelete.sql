create procedure [cloudcore].[SystemActionDelete]
	@ActionId int
AS
begin
    begin transaction
	begin try		
		delete from [cloudcore].SystemActionAllocation where ActionId = @ActionId
		delete from [cloudcore].SystemAction where ActionId = @ActionId
	end try
	
	begin catch
		rollback transaction
		
		declare @errstr nvarchar(4000) 
		set @errstr = ERROR_MESSAGE()
		
		raiserror(N'Unable to delete, unexpected error: %s',18,1, @errstr)
		return
	end catch	
	
	commit transaction		
end