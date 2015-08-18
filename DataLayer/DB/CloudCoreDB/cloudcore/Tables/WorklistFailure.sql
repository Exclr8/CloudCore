CREATE TABLE [cloudcore].[WorklistFailure] (
    [WorklistFailureId]  BIGINT        NOT NULL IDENTITY (1,1),
	[InstanceId]         BIGINT        NOT NULL,
	[ActivityId]         INT           NOT NULL,
    [KeyValue]           BIGINT        NOT NULL,
    [FailedAt]           DATETIME      NOT NULL CONSTRAINT [DF_ActivityFailed_FailedAt] DEFAULT (getdate()),
    [UserId]             INT           NOT NULL,
    [Reason]             VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_ActivityFailed] PRIMARY KEY CLUSTERED ([WorklistFailureId]),
    CONSTRAINT [FK_ActivityFailed_Activity] FOREIGN KEY ([ActivityId]) REFERENCES [cloudcore].[Activity] ([ActivityId]),
    CONSTRAINT [FK_ActivityFailed_User] FOREIGN KEY ([UserId]) REFERENCES [cloudcore].[User] ([UserId]), 
    CONSTRAINT [FK_WorklistFailure_Worklist] FOREIGN KEY ([InstanceId]) REFERENCES [cloudcore].[Worklist]([InstanceId])
);


GO

CREATE TRIGGER [cloudcore].[WorklistFailureInsert]
    ON [cloudcore].[WorklistFailure]
    FOR INSERT
    AS
    BEGIN
        
		insert into cloudcore.ActivityFailureHistory (ActivityModelId, FailedAt, UserId, Reason, KeyValue)
		select a.ActivityModelId, ins.FailedAt, ins.UserId, ins.Reason, ins.KeyValue
		  from cloudcore.Activity a
		 inner join inserted ins on a.ActivityId = ins.ActivityId

    END