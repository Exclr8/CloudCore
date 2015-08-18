create procedure [cloudcore].[SystemActionCreate]
    @ActionGuid UniqueIdentifier,
    @ActionTitle varchar(50),
    @Area varchar(100),
    @Controller varchar(100),
    @Action varchar(100),
    @ActionType varchar(10),
    @SystemModuleId int,
	@ActionId int output
as
begin
  insert into [cloudcore].SystemAction (ActionGuid, ActionType, Area, Controller, [Action], ActionTitle,SystemModuleId)
       values (@ActionGuid, @ActionType, isnull(@Area,''), isnull(@Controller,''), isnull(@Action, ''), @ActionTitle, @SystemModuleId)
  
  set @ActionId = scope_identity()
end