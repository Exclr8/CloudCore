CREATE TABLE [cloudcore].[DashboardUserAllocation]
(
	[DashboardUserAllocationId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
	[DashboardId] INT NOT NULL,
    [TilePosition] INT NOT NULL , 
    CONSTRAINT [FK_DashboardUserAllocation_User] FOREIGN KEY ([UserId]) REFERENCES [cloudcore].[User] (UserId), 
	CONSTRAINT [FK_DashboardUserAllocation_Dashboard] FOREIGN KEY ([DashboardId]) REFERENCES [cloudcore].[Dashboard] ([DashboardId])
)
