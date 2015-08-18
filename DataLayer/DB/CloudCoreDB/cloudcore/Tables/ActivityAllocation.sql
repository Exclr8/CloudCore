CREATE TABLE [cloudcore].[ActivityAllocation] (
    [ActivityId]   INT NOT NULL,
    [AccessPoolId] INT NOT NULL,
    CONSTRAINT [PK_ActivityAllocation] PRIMARY KEY CLUSTERED ([ActivityId] ASC, [AccessPoolId] ASC),
    CONSTRAINT [FK_ActivityAllocation_AccessPool] FOREIGN KEY ([AccessPoolId]) REFERENCES [cloudcore].[AccessPool] ([AccessPoolId]),
    CONSTRAINT [FK_ActivityAllocation_Activity] FOREIGN KEY ([ActivityId]) REFERENCES [cloudcore].[Activity] ([ActivityId])
);


GO
CREATE NONCLUSTERED INDEX [IX_ActivityAllocation_AccessPoolId]
    ON [cloudcore].[ActivityAllocation]([AccessPoolId] ASC);

