create procedure [cloudcoremodel].[CostTypeModify]
	@CostTypeId int,
	@CostType varchar(30)
as
begin
		if exists (select null
					 from [cloudcoremodel].CostType
					where CostType = @CostType and CostTypeId <> @CostTypeId)
						  begin
								raiserror(N'A cost type named <i>"%s"</i> already exists.', 18,1,@CostType)
								return
						  end
						  
		update [cloudcoremodel].CostType
		   set CostType = @CostType
		 where CostTypeId = @CostTypeId 
end