CREATE PROCEDURE [cloudcore].[SystemApplicationUpdate]
	@ApplicationId Int,
	@ApplicationName Varchar(100),
	@CompanyName varchar(100),
	@ContactPerson varchar(100),
	@ContactNumber varchar(50),
	@Enabled bit
AS

	if not exists (Select null from SystemApplication where ApplicationName = @ApplicationName and ApplicationId <> @ApplicationId)
	BEGIN

		Update [cloudcore].SystemApplication set 
		ApplicationName = @ApplicationName,
		CompanyName = @CompanyName,
		ContactPerson = @ContactPerson,
		ContactNumber = @ContactNumber,
		[Enabled] = @Enabled
		From [cloudcore].SystemApplication
		where ApplicationId = @ApplicationId

	END ELSE
	BEGIN
		raiserror(N'The specified system application name already exists, please enter a unique name.',18, 1) 
		return
	END
