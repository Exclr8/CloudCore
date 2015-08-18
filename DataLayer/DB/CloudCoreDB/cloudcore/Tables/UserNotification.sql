CREATE TABLE [cloudcore].[UserNotification]
(
	[UserId] INT NOT NULL, 
    [NotificationId] INT NOT NULL, 
    [HasRead] BIT NOT NULL default 0,
    [Important] BIT NOT NULL default 0,
	CONSTRAINT [PK_UserNotification] Primary KEY ([UserId],[NotificationId])
)
