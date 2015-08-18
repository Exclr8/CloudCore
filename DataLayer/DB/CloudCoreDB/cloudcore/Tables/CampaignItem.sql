CREATE TABLE [cloudcore].[CampaignItem] (
    [CampaignID] INT    NOT NULL,
    [InstanceId] BIGINT NOT NULL,
    [ActivityId] INT    NOT NULL,
    [Opened]     BIT    CONSTRAINT [DF_CampaignItem_Opened] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_CampaignItem] PRIMARY KEY CLUSTERED ([CampaignID] ASC, [InstanceId] ASC),
    CONSTRAINT [FK_CampaignItem_Activity] FOREIGN KEY ([ActivityId]) REFERENCES [cloudcore].[Activity] ([ActivityId]),
    CONSTRAINT [FK_CampaignItem_Campaign] FOREIGN KEY ([CampaignID]) REFERENCES [cloudcore].[Campaign] ([CampaignID]),
    CONSTRAINT [FK_CampaignItem_Worklist] FOREIGN KEY ([InstanceId]) REFERENCES [cloudcore].[Worklist] ([InstanceId])
);


GO
CREATE NONCLUSTERED INDEX [IX_CampaignItem_InstanceId]
    ON [cloudcore].[CampaignItem]([InstanceId] ASC);

