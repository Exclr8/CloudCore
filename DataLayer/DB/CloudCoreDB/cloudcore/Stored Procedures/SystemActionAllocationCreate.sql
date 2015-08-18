create procedure [cloudcore].[SystemActionAllocationCreate]
	@ActionId int,
	@AccessPoolId int
as
begin				      
    insert into [cloudcore].SystemActionAllocation (ActionId,AccessPoolId)
        select  @ActionId, @AccessPoolId
        where   not exists (select  null
                            from    cloudcore.SystemActionAllocation 
                            where   ActionId = @ActionId 
                                    and AccessPoolId = @AccessPoolId)

end