create procedure [cloudcoremodel].[ProcessRevisionCreate]
	@ProcessModelId int,
	@CheckSum varchar(max),
	@UserId int,
	@Changed datetime
as
begin
	declare @ProcessRevision int
	set @ProcessRevision = (select isnull(MAX(ProcessRevision),0)+1
							  from [cloudcoremodel].ProcessRevision 
							 where ProcessModelId = @ProcessModelId)

	insert into [cloudcoremodel].ProcessRevision(ProcessModelId, ProcessRevision, [CheckSum], UserId, Changed)
	values(@ProcessModelId, @ProcessRevision, @CheckSum, @UserId, @Changed)

	return SCOPE_IDENTITY()
end