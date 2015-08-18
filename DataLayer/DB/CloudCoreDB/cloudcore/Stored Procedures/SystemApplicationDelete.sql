CREATE PROCEDURE [cloudcore].[SystemApplicationDelete]
	@ApplicationId Int
AS
	Delete from [cloudcore].SystemApplicationAllocation
	where ApplicationId = @ApplicationId


	Delete from [cloudcore].SystemApplication
	where ApplicationId = @ApplicationId

