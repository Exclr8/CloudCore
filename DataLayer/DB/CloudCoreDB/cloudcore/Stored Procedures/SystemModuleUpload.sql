CREATE PROCEDURE [cloudcore].[SystemModuleUpload]
    @AssemblyName varchar(400),
	@SystemModuleGuid uniqueidentifier,
    @SystemModuleId int = NULL out
as
  begin
    if exists(select null from [cloudcore].SystemModule where SystemModuleGuid = @SystemModuleGuid)
      begin
        select @SystemModuleId = SystemModuleId
        from    cloudcore.SystemModule
        where SystemModuleGuid = @SystemModuleGuid

        update cloudcore.SystemModule
        set AssemblyName = @AssemblyName
        where SystemModuleGuid = @SystemModuleGuid
        
      end
    else
      begin
        insert into [cloudcore].SystemModule(SystemModuleGuid, AssemblyName)
             values (@SystemModuleGuid, @AssemblyName)

        set @SystemModuleId = scope_identity()
     end
  end