CREATE TABLE [cloudcore].[ScheduledTaskGroup] (
    [ScheduledTaskGroupId]   INT              IDENTITY (1, 1) NOT NULL,
    [ScheduledTaskGroupGuid] UNIQUEIDENTIFIER NOT NULL,
    [SystemModuleId]         INT              NOT NULL,
    [ScheduledTaskGroupName] VARCHAR (50)     NOT NULL,
    [ManagerUserId]          INT              DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ScheduledTaskGroup] PRIMARY KEY CLUSTERED ([ScheduledTaskGroupId] ASC),
    CONSTRAINT [FK_ScheduledTaskGroup_SystemModule] FOREIGN KEY ([SystemModuleId]) REFERENCES [cloudcore].[SystemModule] ([SystemModuleId]),
    CONSTRAINT [FK_ScheduledTaskGroup_User] FOREIGN KEY ([ManagerUserId]) REFERENCES [cloudcore].[User] ([UserId])
);

