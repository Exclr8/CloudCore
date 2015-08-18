create procedure [cloudcore].[SystemActionAllocationDelete]
	@ActionId int,
	@AccessPoolId int 
as
begin
	delete from [cloudcore].SystemActionAllocation 
	 where ActionId = @ActionId 
	   and AccessPoolId = @AccessPoolId
end