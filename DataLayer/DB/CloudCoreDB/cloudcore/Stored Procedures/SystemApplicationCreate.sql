CREATE PROCEDURE [cloudcore].[SystemApplicationCreate]
	@ApplicationName Varchar(100),
	@CompanyName Varchar(100),
	@ContactPerson Varchar(100),
	@ContactNumber Varchar(50),
	@ApplicationId Int out
AS
	if not exists (Select null from SystemApplication where ApplicationName = @ApplicationName)
	BEGIN
	    insert into [cloudcore].SystemApplication(ApplicationName, CompanyName, ContactNumber, ContactPerson)
	        values (@ApplicationName, @CompanyName, @ContactNumber, @ContactPerson)

	    set @ApplicationId = (select ApplicationId from [cloudcore].SystemApplication where ApplicationName = @ApplicationName)
	END 
    ELSE
	BEGIN
        set @ApplicationId = null
		raiserror(N'The specified system application name already exists, please enter a unique name.',18, 1) 
		return
	END

