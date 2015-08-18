CREATE TABLE [cloudcore].[SystemActionAllocation] (
    [ActionId]     INT NOT NULL,
    [AccessPoolId] INT NOT NULL,
    CONSTRAINT [PK_SystemActionAllocation] PRIMARY KEY CLUSTERED ([ActionId] ASC, [AccessPoolId] ASC),
    CONSTRAINT [FK_SystemActionAllocation_AccessRight] FOREIGN KEY ([AccessPoolId]) REFERENCES [cloudcore].[AccessPool] ([AccessPoolId]),
    CONSTRAINT [FK_SystemActionAllocation_SystemAction] FOREIGN KEY ([ActionId]) REFERENCES [cloudcore].[SystemAction] ([ActionId])
);

