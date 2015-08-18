CREATE TABLE [cloudcore].[SystemValueCategory] (
    [CategoryId]   INT          IDENTITY (1, 1) NOT NULL,
    [CategoryName] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_SystemValueCategory] PRIMARY KEY CLUSTERED ([CategoryId] ASC),
    CONSTRAINT [UNQ_SystemValueCategory_CategoryName] UNIQUE NONCLUSTERED ([CategoryName] ASC)
);

