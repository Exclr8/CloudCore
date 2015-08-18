create procedure [cloudcore].[ProcessChangeOwner]
	@ProcessRevisionId int, 
	@ManagerId int
as
begin
	update [cloudcoremodel].ProcessRevision
	set ManagerId = @ManagerId
	where ProcessRevisionId = @ProcessRevisionId
end