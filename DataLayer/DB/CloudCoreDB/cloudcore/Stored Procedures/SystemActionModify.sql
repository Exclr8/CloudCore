create procedure [cloudcore].[SystemActionModify]
	@ActionId int,
	@ActionTitle varchar(50),
	@Area varchar(100),
	@Controller varchar(100),
	@Action varchar(100),
	@ActionType varchar(10),
	@SystemModuleId int
as
begin
		update [cloudcore].SystemAction 
		   set ActionTitle = @ActionTitle,
			   Area = isnull(@Area, ''),
			   Controller = isnull(@Controller, ''),
			   [Action] = isnull(@Action, ''),
			   ActionType = @ActionType,
			   SystemModuleId = @SystemModuleId
		 where ActionId = @ActionId
end