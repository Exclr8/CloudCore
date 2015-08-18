CREATE TABLE [cloudcore].[DashboardFailure] (
    [DashboardFailedId] BIGINT        IDENTITY (1, 1) NOT NULL,
    [DashboardId]       INT           NOT NULL,
    [FailedAt]              DATETIME      CONSTRAINT [DF_DashboardFailed_FailedAt] DEFAULT (getdate()) NOT NULL,
    [Reason]                VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_DashboardFailed] PRIMARY KEY CLUSTERED ([DashboardFailedId] ASC),
    CONSTRAINT [FK_DashboardFailed_Dashboard] FOREIGN KEY ([DashboardId]) REFERENCES [cloudcore].[Dashboard] ([DashboardId])
);

