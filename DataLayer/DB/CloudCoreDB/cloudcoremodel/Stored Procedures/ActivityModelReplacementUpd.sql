create procedure [cloudcoremodel].[ActivityModelReplacementUpd]
	@ProcessGuid uniqueidentifier,
	@ActivityGuid uniqueidentifier,
	@NewActivityGuid uniqueidentifier
as
begin
	declare @NewActivityModelId int
	declare @ProcessRevisionId int

	select @ProcessRevisionId = pr.ProcessRevisionId
	  from [cloudcoremodel].ProcessRevision pr
	 inner join [cloudcoremodel].ProcessModel pm
		on pr.ProcessModelId = pm.ProcessModelId 
	 where pm.ProcessGuid = @ProcessGuid
	   and pr.ProcessRevision = (select isnull(MAX(ProcessRevision),1)-1
								   from [cloudcoremodel].ProcessRevision 
								  where ProcessModelId = pm.ProcessModelId)

	select @NewActivityModelId = MAX(ActivityModelId)
	  from [cloudcoremodel].ActivityModel 
	 where ActivityGuid = @ActivityGuid 

	update [cloudcoremodel].ActivityModel 
	   set ReplacementId = @NewActivityModelId
	 where ProcessRevisionId = @ProcessRevisionId
	   and ActivityGuid = @ProcessGuid
end