CREATE TABLE [cloudcore].[AccessPool] (
    [AccessPoolId]   INT          IDENTITY (1, 1) NOT NULL,
    [AccessPoolName] VARCHAR (50) NOT NULL,
    [ManagerId]      INT          NOT NULL,
    CONSTRAINT [PK_AccessPool] PRIMARY KEY CLUSTERED ([AccessPoolId] ASC)
);

