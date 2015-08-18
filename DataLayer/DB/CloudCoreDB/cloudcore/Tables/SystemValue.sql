CREATE TABLE [cloudcore].[SystemValue] (
    [ValueID]          INT            IDENTITY (1, 1) NOT NULL,
    [CategoryId]       INT            NOT NULL,
    [ValueName]        VARCHAR (50)   NOT NULL,
    [ValueData]        VARCHAR (MAX)  NOT NULL,
    [ValueDescription] VARCHAR (8000) NOT NULL,
    CONSTRAINT [PK_SystemValue] PRIMARY KEY CLUSTERED ([ValueID] ASC),
    CONSTRAINT [FK_SystemValue_SystemValueCategory] FOREIGN KEY ([CategoryId]) REFERENCES [cloudcore].[SystemValueCategory] ([CategoryId])
);

