CREATE TABLE [cloudcore].[CampaignArchive] (
    [CampaignID] INT      NOT NULL,
    [InstanceId] BIGINT   NOT NULL,
    [UserId]     INT      NOT NULL,
    [Finished]   DATETIME CONSTRAINT [DF_CampaignArchive_Finished] DEFAULT (getdate()) NOT NULL,
    [StatusID]   INT      CONSTRAINT [DF_CampaignArchive_StatusID] DEFAULT ((0)) NOT NULL,
    [Status]     AS       (case [StatusID] when (1) then 'Cancelled' when (2) then 'Unavailable' else 'Completed' end),
    CONSTRAINT [PK_CampaignArchive] PRIMARY KEY CLUSTERED ([CampaignID] ASC, [InstanceId] ASC),
    CONSTRAINT [FK_CampaignArchive_Campaign] FOREIGN KEY ([CampaignID]) REFERENCES [cloudcore].[Campaign] ([CampaignID]),
    CONSTRAINT [FK_CampaignArchive_User] FOREIGN KEY ([UserId]) REFERENCES [cloudcore].[User] ([UserId])
);

