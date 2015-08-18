CREATE TABLE [cloudcore].[Activity] (
    [ActivityId]              INT              IDENTITY (1, 1) NOT NULL,
    [ActivityModelId]         INT              NOT NULL,
    [ProcessRevisionId]       INT              NOT NULL,
    [SystemModuleId]          INT              NOT NULL,
    [ActivityTypeId]          TINYINT          NOT NULL,
	[OnlyVisibleAtLocation]	  BIT              CONSTRAINT [DF_Activity_OnlyVisibleAtLocation] DEFAULT (0) NOT NULL,
    [LocationRadius]	      INT              NULL,	
    [ActivityGuid]            UNIQUEIDENTIFIER NOT NULL,
    [SubProcessGuid]          UNIQUEIDENTIFIER NOT NULL,
    [ProcessGuid]             UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED ([ActivityId] ASC),
    CONSTRAINT [FK_Activity_ActivityModel] FOREIGN KEY ([ActivityModelId]) REFERENCES [cloudcoremodel].[ActivityModel] ([ActivityModelId]),
    CONSTRAINT [FK_Activity_ActivityType] FOREIGN KEY ([ActivityTypeId]) REFERENCES [cloudcoremodel].[ActivityType] ([ActivityTypeId]),
    CONSTRAINT [FK_Activity_SystemModule] FOREIGN KEY ([SystemModuleId]) REFERENCES [cloudcore].[SystemModule] ([SystemModuleId]),
    CONSTRAINT [UNQ_Activity_ActivityModelId] UNIQUE NONCLUSTERED ([ActivityModelId] ASC)
);

