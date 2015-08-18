create procedure [cloudcoremodel].[CostTypeCreate]
	@CostTypeId int output,
	@CostType varchar(30)
as	
begin
	if exists (select null
					from [cloudcoremodel].CostType
				where CostType = @CostType)
						begin
							raiserror(N'A cost type named <i>"%s"</i> already exists.', 18,1,@CostType)
							return
						end
					  
	insert into [cloudcoremodel].CostType (CostType) values (@CostType)
		
	set @CostTypeId = scope_identity()

end