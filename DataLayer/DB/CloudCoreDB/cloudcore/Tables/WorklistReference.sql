CREATE TABLE [cloudcore].[WorklistReference] (
    [InstanceId]          BIGINT       NOT NULL,
    [ReferenceTypeId]     INT          NOT NULL,
    [Reference]           VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_WorklistReference] PRIMARY KEY CLUSTERED ([ReferenceTypeId] ASC, [InstanceId] ASC),
    CONSTRAINT [FK_WorklistReference_ReferenceType] FOREIGN KEY ([ReferenceTypeId]) REFERENCES [cloudcore].[ReferenceType] ([ReferenceTypeId]),
    CONSTRAINT [FK_WorklistReference_Worklist] FOREIGN KEY ([InstanceId]) REFERENCES [cloudcore].[Worklist] ([InstanceId]) ON DELETE CASCADE
);


GO
