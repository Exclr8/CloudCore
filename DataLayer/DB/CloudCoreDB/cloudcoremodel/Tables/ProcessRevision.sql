CREATE TABLE [cloudcoremodel].[ProcessRevision] (
    [ProcessRevisionId] INT           IDENTITY (1, 1) NOT NULL,
    [ProcessModelId]    INT           NOT NULL,
    [ProcessRevision]   INT           NOT NULL,
    [CheckSum]          VARCHAR (MAX) NULL,
    [UserId]            INT           NOT NULL,
    [ManagerId]         INT           CONSTRAINT [DF_ProcessRevision_ManagerId] DEFAULT ((0)) NOT NULL,
    [Changed]           DATETIME      DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_ProcessRevision] PRIMARY KEY CLUSTERED ([ProcessRevisionId] ASC),
    CONSTRAINT [FK_ProcessRevision_ProcessModel] FOREIGN KEY ([ProcessModelId]) REFERENCES [cloudcoremodel].[ProcessModel] ([ProcessModelId]),
    CONSTRAINT [FK_ProcessRevision_User] FOREIGN KEY ([UserId]) REFERENCES [cloudcore].[User] ([UserId]),
    CONSTRAINT [FK_ProcessRevision_User_ManagerId] FOREIGN KEY ([ManagerId]) REFERENCES [cloudcore].[User] ([UserId]),
    CONSTRAINT [UNQ_ProcessRevision_Revision] UNIQUE NONCLUSTERED ([ProcessModelId] ASC, [ProcessRevision] ASC)
);

