CREATE TABLE [cloudcore].[Campaign] (
    [CampaignID]   INT           IDENTITY (1, 1) NOT NULL,
    [CampaignName] VARCHAR (50)  NOT NULL,
    [CampaignDesc] VARCHAR (250) NOT NULL,
    [ManagerId]    INT           NOT NULL,
    [StatusID]     SMALLINT      CONSTRAINT [DF_Campaign_StatusID] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Campaign] PRIMARY KEY CLUSTERED ([CampaignID] ASC),
    CONSTRAINT [FK_Campaign_User] FOREIGN KEY ([ManagerId]) REFERENCES [cloudcore].[User] ([UserId])
);

