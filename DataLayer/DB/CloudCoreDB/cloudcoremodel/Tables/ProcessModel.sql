CREATE TABLE [cloudcoremodel].[ProcessModel] (
    [ProcessModelId] INT              IDENTITY (1, 1) NOT NULL,
    [ProcessGuid]    UNIQUEIDENTIFIER NOT NULL,
    [ProcessName]    VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_ProcessModel] PRIMARY KEY CLUSTERED ([ProcessModelId] ASC),
    CONSTRAINT [UNQ_ProcessModel_Guid] UNIQUE NONCLUSTERED ([ProcessGuid] ASC)
);

