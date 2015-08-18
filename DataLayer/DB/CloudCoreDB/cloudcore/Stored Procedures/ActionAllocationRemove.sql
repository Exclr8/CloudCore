CREATE PROCEDURE [cloudcore].[ActionAllocationRemove]
	@AccessPoolId int,
	@ActionId int
AS
Begin
	delete from cloudcore.SystemActionAllocation 
	where AccessPoolId = @AccessPoolId and ActionId = @ActionId
End
