CREATE TABLE [cloudcore].[SystemModule] (
    [SystemModuleId]    INT             IDENTITY (1, 1) NOT NULL,
    [SystemModuleGuid]  UNIQUEIDENTIFIER NOT NULL,
    [AssemblyName]      VARCHAR (400)    NOT NULL,
    CONSTRAINT [PK_SystemModule] PRIMARY KEY CLUSTERED ([SystemModuleId] ASC)
);

