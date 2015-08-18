CREATE VIEW [cloudcore].[vwUserAccess]
    AS 
    
    SELECT  u.UserId, u.Email, u.[Login], u.Active, u.IntAccess, u.ExtAccess, u.IsAdministrator,
            u.Firstnames, u.Surname,
            isnull((select  MAX(Connected)
                                from    cloudcore.LoginHistory
                                where   UserId = u.UserId), getdate()) as LastLoginDateTime
    FROM    cloudcore.[User] u