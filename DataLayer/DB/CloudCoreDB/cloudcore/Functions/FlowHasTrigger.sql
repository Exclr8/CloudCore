CREATE FUNCTION [cloudcore].[FlowHasTrigger]
(@FlowGuid uniqueidentifier)
RETURNS bit
as
begin
	return
	case when exists(select null
			    from sys.sysobjects
			   where type = 'P'
				 and name like 'CCTrigger_' + Replace(Cast(@FlowGuid as varchar(38)), '-', '_'))
	then
		1
	else
		0
	end
end