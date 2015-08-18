CREATE VIEW [cloudcore].[vwAccessPool]
	AS 
	SELECT
	apu.UserId,
	ap.AccessPoolId,
	ap.AccessPoolName,
	u.Fullname
FROM 
	[cloudcore].AccessPoolUser apu
	JOIN [cloudcore].AccessPool ap ON apu.AccessPoolId = ap.AccessPoolId
	JOIN [cloudcore].[User] u ON ap.ManagerId = u.UserId