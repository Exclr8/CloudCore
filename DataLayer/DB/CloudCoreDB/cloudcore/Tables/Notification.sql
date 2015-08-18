CREATE TABLE [cloudcore].[Notification]
(
	[NotificationId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Subject] VARCHAR(50) NOT NULL,
	[Message] VARCHAR(1000) NOT NULL,
	[Created] datetime not null constraint [DF_Notification_Created] default getdate(),
	[Creator] int NOT NULL,
	CONSTRAINT [FK_Notification_Creator] FOREIGN KEY ([Creator]) REFERENCES [cloudcore].[User] ([UserId])
)
