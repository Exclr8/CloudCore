CREATE TABLE [cloudcore].[CampaignUser] (
    [CampaignID] INT NOT NULL,
    [UserId]     INT NOT NULL,
    [Active] BIT NOT NULL CONSTRAINT DF_CampaignUser_Active default (0), 
    CONSTRAINT [PK_CampaignUser] PRIMARY KEY CLUSTERED ([CampaignID] ASC, [UserId] ASC),
    CONSTRAINT [FK_CampaignUser_Campaign] FOREIGN KEY ([CampaignID]) REFERENCES [cloudcore].[Campaign] ([CampaignID]),
    CONSTRAINT [FK_CampaignUser_User] FOREIGN KEY ([UserId]) REFERENCES [cloudcore].[User] ([UserId])
);

