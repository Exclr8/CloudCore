create procedure [cloudcore].SystemValueUpdate 
	@CategoryId int = 0, 
	@ValueName varchar(50),
	@ValueData varchar(max),
	@ValueDescription varchar(1000)
as
begin
	if exists(select null 
				from [cloudcore].SystemValue 
			   where CategoryId = @CategoryId 
			     and ValueName = @ValueName)
	begin
		update [cloudcore].SystemValue 
		   set ValueData = @ValueData,
			   ValueDescription = @ValueDescription
		 where CategoryId = @CategoryId 
		   and ValueName = @ValueName 
	end
	else
	begin
		insert into [cloudcore].SystemValue(CategoryId,  ValueName,  ValueData, ValueDescription)
		values                   (@CategoryId, @ValueName, @ValueData, @ValueDescription) 
	end
end