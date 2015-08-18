CREATE TABLE [cloudcore].[ReferenceType] (
    [ReferenceTypeId] INT           IDENTITY (1, 1) NOT NULL,
    [ReferenceType]   VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_ReferenceType] PRIMARY KEY CLUSTERED ([ReferenceTypeId] ASC)
);

