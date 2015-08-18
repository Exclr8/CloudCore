CREATE TABLE [cloudcore].[DashboardRight] (
    [DashboardId]  INT NOT NULL,
    [AccessPoolId] INT NOT NULL,
    CONSTRAINT [PK_DashboardRight] PRIMARY KEY CLUSTERED ([DashboardId] ASC, [AccessPoolId] ASC),
    CONSTRAINT [FK_DashboardRight_AccessRight] FOREIGN KEY ([AccessPoolId]) REFERENCES [cloudcore].[AccessPool] ([AccessPoolId]),
    CONSTRAINT [FK_DashboardRight_Dashboard] FOREIGN KEY ([DashboardId]) REFERENCES [cloudcore].[Dashboard] ([DashboardId])
);

