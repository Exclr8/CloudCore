CREATE TABLE [cloudcore].[SystemAction] (
    [ActionId]       INT           IDENTITY (1, 1) NOT NULL,
	[ActionGuid]     UNIQUEIDENTIFIER NOT NULL, 
    [SystemModuleId] INT           NOT NULL,
    [ActionType]     VARCHAR (10)  NOT NULL,
    [ActionTitle]    VARCHAR (50)  NOT NULL,
    [Area]           VARCHAR (100) NOT NULL,
    [Controller]     VARCHAR (100) NOT NULL,
    [Action]         VARCHAR (100) NOT NULL
    CONSTRAINT [PK_SystemAction] PRIMARY KEY CLUSTERED ([ActionId] ASC),
    CONSTRAINT [CK_SystemAction_ActionType] CHECK ([ActionType]='Folder' OR [ActionType]='Report' OR [ActionType]='Statistic' OR [ActionType]='Search' OR [ActionType]='Create' OR [ActionType]='Delete' OR [ActionType]='Modify' OR [ActionType]='Tools' OR [ActionType]='Details' OR [ActionType]='Secure'),
    CONSTRAINT [FK_SystemAction_SystemModule] FOREIGN KEY ([SystemModuleId]) REFERENCES [cloudcore].[SystemModule] ([SystemModuleId])
);

