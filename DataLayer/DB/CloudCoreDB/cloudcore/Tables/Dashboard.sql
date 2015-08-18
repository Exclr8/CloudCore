CREATE TABLE [cloudcore].[Dashboard] (
    [DashboardId]    INT           IDENTITY (1, 1) NOT NULL,
	[DashboardGuid] UNIQUEIDENTIFIER NOT NULL,
    [SystemModuleId] INT           NOT NULL,
    [Title]          VARCHAR (100) NOT NULL,
    [Description]    VARCHAR (MAX) NOT NULL,
	[IntervalInMinutes] INT NOT NULL, 
	[LastRun] DateTime NOT NULL CONSTRAINT [DF_Dashboard_LastRun] DEFAULT GETDATE(),
	[NextRun] AS DATEADD(MINUTE, IntervalInMinutes, LastRun),
	[StatusId]             TINYINT          NOT NULL CONSTRAINT [DF_Dashboard_StatusId] DEFAULT 0,
    [Status]               AS               (case [StatusId] when (0) then 'Scheduled' when (1) then 'Running' when (101) then 'Failed' when (100) then 'Disabled' else 'Unknown' end),    
    CONSTRAINT [PK_Dashboard] PRIMARY KEY CLUSTERED ([DashboardId] ASC),
    CONSTRAINT [FK_Dashboard_SystemModule] FOREIGN KEY ([SystemModuleId]) REFERENCES [cloudcore].[SystemModule] ([SystemModuleId]),
    CONSTRAINT [UK_Dashboard_DashboardGuid] UNIQUE NONCLUSTERED ([DashboardGuid] ASC)
);

