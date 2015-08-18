CREATE TABLE [cloudcore].[AccessPoolUser] (
    [AccessPoolId] INT NOT NULL,
    [UserId]       INT NOT NULL,
    CONSTRAINT [PK_AccessPoolUser] PRIMARY KEY CLUSTERED ([AccessPoolId] ASC, [UserId] ASC),
    CONSTRAINT [FK_AccessPoolUser_AccessPool] FOREIGN KEY ([AccessPoolId]) REFERENCES [cloudcore].[AccessPool] ([AccessPoolId]),
    CONSTRAINT [FK_AccessPoolUser_User] FOREIGN KEY ([UserId]) REFERENCES [cloudcore].[User] ([UserId])
);

