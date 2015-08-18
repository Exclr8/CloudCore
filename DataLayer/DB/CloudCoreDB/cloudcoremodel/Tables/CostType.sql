CREATE TABLE [cloudcoremodel].[CostType] (
    [CostTypeId] INT          IDENTITY (1, 1) NOT NULL,
    [CostType]   VARCHAR (30) NOT NULL,
    CONSTRAINT [PK_CostType] PRIMARY KEY CLUSTERED ([CostTypeId] ASC)
);

