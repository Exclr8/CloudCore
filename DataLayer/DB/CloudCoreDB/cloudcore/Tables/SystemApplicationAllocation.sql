CREATE TABLE [cloudcore].[SystemApplicationAllocation]
(
	[ApplicationId] INT NOT NULL, 
    [ActivityId] INT NOT NULL, 
    CONSTRAINT [PK_SystemApplicationAllocation] PRIMARY KEY CLUSTERED ([ApplicationId] ASC, [ActivityId] ASC),
    CONSTRAINT [FK_SystemApplicationAllocation_Application] FOREIGN KEY ([ApplicationId]) REFERENCES [cloudcore].[SystemApplication] ([ApplicationId]),
    CONSTRAINT [FK_SystemApplicationAllocation_Activity] FOREIGN KEY ([ActivityId]) REFERENCES [cloudcore].[Activity] ([ActivityId])
)

GO
CREATE NONCLUSTERED INDEX [IX_SystemApplicationAllocation_Application]
    ON [cloudcore].[SystemApplicationAllocation]([ApplicationId] ASC);