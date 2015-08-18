CREATE TABLE [cloudcore].[ActivityHistory] (
    [ActivityArchiveId] BIGINT   IDENTITY (1, 1) NOT NULL,
    [ActivityModelId]   INT      NOT NULL,
    [FlowModelId]       INT      NOT NULL,
    [InstanceId]        BIGINT   NOT NULL,
    [PInstanceId]       BIGINT   NOT NULL,
    [Assigned]          DATETIME NOT NULL,
    [Activate]          DATETIME NOT NULL,
    [Opened]            DATETIME NOT NULL,
    [Completed]         DATETIME DEFAULT (getdate()) NOT NULL,
    [Priority]          TINYINT  NOT NULL,
    [StatusTypeId]      TINYINT  NOT NULL,
    [UserId]            INT      NOT NULL,
    CONSTRAINT [PK_ActivityHistory] PRIMARY KEY CLUSTERED ([ActivityArchiveId] ASC),
    CONSTRAINT [FK_ActivityHistory_ActivityModel] FOREIGN KEY ([ActivityModelId]) REFERENCES [cloudcoremodel].[ActivityModel] ([ActivityModelId]),
    CONSTRAINT [FK_ActivityHistory_StatusType] FOREIGN KEY ([StatusTypeId]) REFERENCES [cloudcoremodel].[StatusType] ([StatusTypeId]),
    CONSTRAINT [FK_ActivityHistory_User] FOREIGN KEY ([UserId]) REFERENCES [cloudcore].[User] ([UserId])
);

