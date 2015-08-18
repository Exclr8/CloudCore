CREATE TABLE [cloudcore].[SystemApplication]
(
    [ApplicationId]  INT IDENTITY (1, 1) NOT NULL PRIMARY KEY ,
	[ApplicationGuid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [ApplicationName] VARCHAR(100) NOT NULL,
	[Enabled] bit not null default 1,
	[CompanyName] VARCHAR(200) NOT NULL, 
    [ContactPerson] VARCHAR(100) NOT NULL, 
    [ContactNumber] VARCHAR(50) NOT NULL
    
)
