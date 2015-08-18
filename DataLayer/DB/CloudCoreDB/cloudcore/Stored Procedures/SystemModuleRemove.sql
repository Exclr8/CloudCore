create procedure [cloudcore].[SystemModuleRemove]
	@SystemModuleId int
as
begin


	if exists ( select null
			      from [cloudcore].Worklist W
				 inner join [cloudcore].Activity A
				    on A.ActivityId = W.ActivityId
				 where A.SystemModuleId = @SystemModuleId)
				 begin
				   raiserror(N'Unable to delete, there are active worklist items for this system module.',18, 1) 
				   return
				 end

	if exists ( select null
			      from [cloudcore].Activity
				 where SystemModuleId = @SystemModuleId)
				 begin
				   raiserror(N'Unable to delete, there are live process activities that depend on this system module.',18, 1) 
				   return
				 end

	begin transaction
	begin try
		delete from [cloudcore].SystemActionAllocation
		 where ActionId in (
						  select ur.ActionId from [cloudcore].SystemActionAllocation ur
						   inner join [cloudcore].SystemAction u on u.ActionId = ur.ActionId
						   where u.SystemModuleId = @SystemModuleId
						 )

		delete from [cloudcore].SystemAction
		 where SystemModuleId = @SystemModuleId

		 delete from [cloudcore].DashboardRight 
		 where DashboardId in (select DashboardId 
		                         from [cloudcore].Dashboard 
								where SystemModuleId = @SystemModuleId)
		delete from [cloudcore].Dashboard  
		 where DashboardId in (select DashboardId 
		                         from [cloudcore].Dashboard 
								where SystemModuleId = @SystemModuleId)

		delete from [cloudcore].SystemModule 
		 where SystemModuleId = @SystemModuleId

		
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