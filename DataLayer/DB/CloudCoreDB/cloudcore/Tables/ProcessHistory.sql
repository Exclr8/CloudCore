CREATE TABLE [cloudcore].[ProcessHistory] (
    [ProcessArchiveId] BIGINT   IDENTITY (1, 1) NOT NULL,
    [InstanceId]       BIGINT   NOT NULL,
    [PInstanceId]      BIGINT   NOT NULL,
    [ProcessModelId]   INT      NOT NULL,
    [KeyValue]         BIGINT   NOT NULL,
    [Started]          DATETIME NOT NULL,
    [Ended]            DATETIME NULL,
    [StatusId]         INT      NOT NULL,
    CONSTRAINT [PK_ProcessHistory] PRIMARY KEY CLUSTERED ([ProcessArchiveId] ASC),
    CONSTRAINT [FK_ProcessHistory_ProcessModel] FOREIGN KEY ([ProcessModelId]) REFERENCES [cloudcoremodel].[ProcessModel] ([ProcessModelId])
);
GO

CREATE NONCLUSTERED INDEX [IX_ProcessHistory_InstanceId] ON [cloudcore].[ProcessHistory] 
(
    [InstanceId] ASC
);
GO

