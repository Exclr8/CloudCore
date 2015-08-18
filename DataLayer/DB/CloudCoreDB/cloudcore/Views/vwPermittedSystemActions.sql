create view [cloudcore].[vwPermittedSystemActions] as
  select distinct SU.ActionGuid, U.UserId -- into AllowPaths
    from [cloudcore].[User] U with (nolock) -- for a specific user
   inner join [cloudcore].[AccessPoolUser] UP with (nolock) -- and his/her permissions for the current location].
      on UP.UserId = U.UserId
   inner join [cloudcore].SystemActionAllocation SUR with (nolock) -- and the urls these rights are allowed to access
      on SUR.AccessPoolId = UP.AccessPoolId
   inner join [cloudcore].SystemAction SU with (nolock) -- and the urls in those modules
      on SU.ActionId = SUR.ActionId