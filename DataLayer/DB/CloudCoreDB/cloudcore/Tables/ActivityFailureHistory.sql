CREATE TABLE [cloudcore].[ActivityFailureHistory]
(
	[ArchiveFailureId] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [ActivityModelId] INT NOT NULL, 
    [FailedAt] DATETIME NOT NULL, 
    [UserId] INT NOT NULL, 
    [Reason] VARCHAR(MAX) NOT NULL, 
    [KeyValue] BIGINT NOT NULL, 
    CONSTRAINT [FK_ActivityFailureHistory_ActivityModel] FOREIGN KEY ([ActivityModelId]) REFERENCES [cloudcoremodel].[ActivityModel]([ActivityModelId]), 
    CONSTRAINT [FK_ActivityFailureHistory_User] FOREIGN KEY ([UserId]) REFERENCES [cloudcore].[User]([UserId])
)
