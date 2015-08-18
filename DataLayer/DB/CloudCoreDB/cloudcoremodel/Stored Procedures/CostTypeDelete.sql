create procedure [cloudcoremodel].[CostTypeDelete]
	@CostTypeId int
as
begin
	
	if exists (select null
			     from [cloudcoremodel].ActivityModel
			    where CostTypeId = @CostTypeId)
					  begin
						    raiserror(N'Unable to delete, this type is used by a cost flow',18, 1) 	
						    return
					  end
	
	
	delete from [cloudcoremodel].CostType 
	      where CostTypeId = @CostTypeId
	
end