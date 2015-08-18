CREATE PROCEDURE [cloudcoremodel].[SubProcessCreate]
	@ProcessRevisionId int, 
	@Guid uniqueidentifier,
	@SubProcessName varchar(200)
as
  begin

	insert into [cloudcoremodel].SubProcess(ProcessRevisionId, SubProcessGuid, SubProcessName)
    values (@ProcessRevisionId, @Guid, @SubProcessName)

	return SCOPE_IDENTITY()
  end