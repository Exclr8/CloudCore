create procedure [cloudcoremodel].[ProcessModelCreate]
	@ProcessGuid uniqueidentifier,
	@ProcessName varchar(50)
as
begin
	declare @ProcessModelId int

	insert into [cloudcoremodel].ProcessModel(ProcessGuid, ProcessName)
	values(@ProcessGuid, @ProcessName)
	
	set @ProcessModelId = SCOPE_IDENTITY()

	select @ProcessModelId
end