CREATE PROCEDURE [cloudcore].[SystemValueCreate]
	@CategoryId int = 0, 
	@ValueName varchar(50),
	@ValueData varchar(max),
	@ValueDescription varchar(1000),
	@SystemValueId int out
AS
begin
	if not exists (Select null from [cloudcore].SystemValue where CategoryId = @CategoryId and ValueName = @ValueName)
	BEGIN
		insert into [cloudcore].SystemValue(CategoryId,  ValueName,  ValueData, ValueDescription)
		values                   (@CategoryId, @ValueName, @ValueData, @ValueDescription) 

		set @SystemValueId = SCOPE_IDENTITY()
	END ELSE
	BEGIN
        set @SystemValueId = null
		raiserror(N'The specified system value already exists, please enter a unique name.',18, 1) 
		return
	END
end
