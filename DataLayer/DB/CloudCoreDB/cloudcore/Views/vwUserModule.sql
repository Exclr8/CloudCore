create view [cloudcore].[vwUserModule]
as
	select distinct u.UserId, su.SystemModuleId, sm.AssemblyName
      from [cloudcore].[User] u
     inner join [cloudcore].AccessPoolUser up
        on u.UserId = up.UserId
     inner join [cloudcore].SystemActionAllocation sul
        on up.AccessPoolId = sul.AccessPoolId
     inner join [cloudcore].SystemAction su
        on sul.ActionId = su.ActionId
     inner join [cloudcore].SystemModule sm
       on su.SystemModuleId = sm.SystemModuleId