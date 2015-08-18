CREATE TABLE [cloudcore].[UserAccessMapping]
(
    [UserId] INT NOT NULL, 
    [ProviderId] INT NOT NULL, 
    [UserKey] VARCHAR(255) NOT NULL, 
    CONSTRAINT [FK_UserAccessMapping_User] FOREIGN KEY ([UserId]) REFERENCES [cloudcore].[User]([UserId]),
	CONSTRAINT [FK_UserAccessMapping_Provider] FOREIGN KEY ([ProviderId]) REFERENCES [cloudcore].[UserAccessProvider]([ProviderId]),
	CONSTRAINT [PK_UserAccessMapping] Primary KEY ([UserId],[ProviderId],[UserKey])
)