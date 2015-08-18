CREATE TABLE [cloudcoremodel].[SubProcess] (
    [SubProcessId]      INT              IDENTITY (1, 1) NOT NULL,
    [ProcessRevisionId] INT              NOT NULL,
    [SubProcessGuid]    UNIQUEIDENTIFIER NOT NULL,
    [SubProcessName]    VARCHAR (200)    NOT NULL,
    CONSTRAINT [PK_SubProcess] PRIMARY KEY CLUSTERED ([SubProcessId] ASC),
    CONSTRAINT [FK_SubProcess_ProcessRevision] FOREIGN KEY ([ProcessRevisionId]) REFERENCES [cloudcoremodel].[ProcessRevision] ([ProcessRevisionId])
);

