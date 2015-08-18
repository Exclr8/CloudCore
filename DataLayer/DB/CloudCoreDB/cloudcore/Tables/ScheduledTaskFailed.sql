CREATE TABLE [cloudcore].[ScheduledTaskFailed] (
    [ScheduledTaskFailedId] BIGINT        IDENTITY (1, 1) NOT NULL,
    [ScheduledTaskId]       INT           NOT NULL,
    [FailedAt]              DATETIME      CONSTRAINT [DF_ScheduledTaskFailed_FailedAt] DEFAULT (getdate()) NOT NULL,
    [Reason]                VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_ScheduledTaskFailed] PRIMARY KEY CLUSTERED ([ScheduledTaskFailedId] ASC),
    CONSTRAINT [FK_ScheduledTaskFailed_ScheduledTask] FOREIGN KEY ([ScheduledTaskId]) REFERENCES [cloudcore].[ScheduledTask] ([ScheduledTaskId])
);

