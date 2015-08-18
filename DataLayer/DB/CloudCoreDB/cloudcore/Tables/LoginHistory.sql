CREATE TABLE [cloudcore].[LoginHistory] (
    LoginHistoryId BIGINT NOT NULL IDENTITY(1, 1) CONSTRAINT PK_LoginHistory PRIMARY KEY CLUSTERED,
    [UserId]    INT      NOT NULL,
	[ApplicationId] INT NOT NULL,
	[Connected] DATETIME CONSTRAINT [DF_LoginHistory_Connected] DEFAULT (getdate()) NOT NULL,
	CONSTRAINT [FK_LoginHistory_User] FOREIGN KEY ([UserId]) REFERENCES [cloudcore].[User] ([UserId]),
	CONSTRAINT [FK_LoginHistory_ApplicationId] FOREIGN KEY ([ApplicationId]) REFERENCES [cloudcore].[SystemApplication] ([ApplicationId])
);
GO

CREATE NONCLUSTERED INDEX [IX_LoginHistory_Connected] ON [cloudcore].[LoginHistory] 
(
    [Connected] DESC
);
GO


