CREATE TABLE [cloudcoremodel].[ActivityModel] (
    [ActivityModelId]         INT              IDENTITY (1, 1) NOT NULL,
    [ProcessRevisionId]       INT              NOT NULL,
    [ReplacementId]           INT              NOT NULL,
    [ActivityGuid]            UNIQUEIDENTIFIER NOT NULL,
    [SubProcessId]            INT              NOT NULL,
    [ActivityName]            VARCHAR (50)     NOT NULL,
    [ActivityTypeId]          TINYINT          NOT NULL,
    [CostTypeId]              INT              CONSTRAINT [DF_ActivityModel_CostTypeId] DEFAULT (0) NOT NULL,
    [Startable]               BIT              CONSTRAINT [DF_ActivityModel_Startable] DEFAULT (0) NOT NULL,
    [Priority]			      INT              CONSTRAINT [DF_ActivityModel_Priority] DEFAULT (0) NOT NULL,
    [DocWait]                 BIT              CONSTRAINT [DF_ActivityModel_DocWait] DEFAULT (0) NOT NULL,
    [OnlyVisibleAtLocation]	  BIT              CONSTRAINT [DF_ActivityModel_OnlyVisibleAtLocation] DEFAULT (0) NOT NULL,
    [LocationRadius]	      INT              NULL,	
	[MaxRetries]              INT              CONSTRAINT [DF_ActivityModel_MaxRetries] DEFAULT (0) NOT NULL,
	[RetryDelayInSeconds]     INT              CONSTRAINT [DF_ActivityModel_RetryDelayInSeconds] DEFAULT (0) NOT NULL,
    CONSTRAINT [PK_ActivityModel] PRIMARY KEY CLUSTERED ([ActivityModelId] ASC),
    CONSTRAINT [FK_ActivityModel_ActivityModel_Replacement] FOREIGN KEY ([ReplacementId]) REFERENCES [cloudcoremodel].[ActivityModel] ([ActivityModelId]),
    CONSTRAINT [FK_ActivityModel_ActivityType] FOREIGN KEY ([ActivityTypeId]) REFERENCES [cloudcoremodel].[ActivityType] ([ActivityTypeId]),
    CONSTRAINT [FK_ActivityModel_CostType] FOREIGN KEY ([CostTypeId]) REFERENCES [cloudcoremodel].[CostType] ([CostTypeId]),
    CONSTRAINT [FK_ActivityModel_ProcessRevision] FOREIGN KEY ([ProcessRevisionId]) REFERENCES [cloudcoremodel].[ProcessRevision] ([ProcessRevisionId]),
    CONSTRAINT [FK_ActivityModel_SubProcess] FOREIGN KEY ([SubProcessId]) REFERENCES [cloudcoremodel].[SubProcess] ([SubProcessId])
);

