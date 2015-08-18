CREATE PROCEDURE [cloudcoremodel].[RevisionUpdate]
	@ProcessGuid uniqueidentifier,
	@CheckSum varchar(max),
	@UserId int
AS
begin
	update pr 
	   set pr.[CheckSum] = @CheckSum,
	       pr.UserId = @UserId 
	  from [cloudcoremodel].ProcessModel pm
	 inner join [cloudcoremodel].ProcessRevision pr
		on pm.ProcessModelId = pr.ProcessModelId 
	 where pm.ProcessGuid = @ProcessGuid 
	   and pr.ProcessRevision = (select MAX(prmax.ProcessRevision) 
								   from [cloudcoremodel].ProcessRevision prmax
								  where prmax.ProcessModelId = pr.ProcessModelId)
end