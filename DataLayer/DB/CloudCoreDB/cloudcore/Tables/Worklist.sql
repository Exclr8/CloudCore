CREATE TABLE [cloudcore].[Worklist] (
    [InstanceId]   BIGINT   IDENTITY (1, 1) NOT NULL CONSTRAINT PK_Worklist PRIMARY KEY,
    [PInstanceId]  BIGINT   CONSTRAINT [DF_Worklist_PInstanceId] DEFAULT ((0)) NOT NULL,
    [ActivityId]   INT      NOT NULL,
    [StatusTypeId] TINYINT  CONSTRAINT [DF_Worklist_StatusTypeId] DEFAULT ((0)) NOT NULL,
    [DocWait]      BIT      CONSTRAINT [DF_Worklist_DocWait] DEFAULT ((0)) NOT NULL,
    [Priority]     TINYINT  CONSTRAINT [DF_Worklist_Priority] DEFAULT ((0)) NOT NULL,
    [UserId]       INT      CONSTRAINT [DF_Worklist_UserId] DEFAULT ((0)) NOT NULL,
    [Assigned]     DATETIME CONSTRAINT [DF_Worklist_Assigned] DEFAULT (getdate()) NOT NULL,
    [OpenedBy]     INT      CONSTRAINT [DF_Worklist_OpenedBy] DEFAULT ((0)) NOT NULL,
    [Opened]       DATETIME CONSTRAINT [DF_Worklist_Opened] DEFAULT (getdate()) NOT NULL,
    [Activate]     DATETIME CONSTRAINT [DF_Worklist_Activate] DEFAULT (getdate()) NOT NULL,
    [KeyValue]     BIGINT   NOT NULL,
    [Created]      DATETIME CONSTRAINT [DF_Worklist_Created] DEFAULT (getdate()) NOT NULL,
    [Delayed]      AS       (CONVERT([bit],case when [Activate]<=getdate() then (0) else (1) end,(0))),
    [Age]          AS       (getdate()-[Assigned]),
    [Location] [sys].[geometry] NULL, 
    [Retries]	   INT CONSTRAINT [DF_Worklist_Retries] DEFAULT ((0)) NOT NULL, 
    [KeepAliveDate] DATETIME NOT NULL CONSTRAINT DF_Worklist_KeepAliveDate DEFAULT (0),
    [DateCompleted] DATETIME NULL, 
    [TimeTakenInSeconds] as case when isnull(Opened, 1) > isnull(DateCompleted, 0) then 'Not Completed Yet' else cast(datediff(second, Opened, DateCompleted) as varchar(20)) end,
    
    CONSTRAINT [FK_Worklist_Activity] FOREIGN KEY ([ActivityId]) REFERENCES [cloudcore].[Activity] ([ActivityId]),
    CONSTRAINT [FK_Worklist_OpenedBy] FOREIGN KEY ([OpenedBy]) REFERENCES [cloudcore].[User] ([UserId]),
    CONSTRAINT [FK_Worklist_StatusType] FOREIGN KEY ([StatusTypeId]) REFERENCES [cloudcoremodel].[StatusType] ([StatusTypeId]),
    CONSTRAINT [FK_Worklist_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [cloudcore].[User] ([UserId])
);

GO
CREATE NONCLUSTERED INDEX [IX_Worklist_Priority_Activate]
    ON [cloudcore].[Worklist]
(
    [Priority] DESC, 
    [Activate] ASC
)
INCLUDE([UserId], [OpenedBy], [ActivityId], [StatusTypeId], [DocWait], [KeyValue]);

GO

CREATE NONCLUSTERED INDEX [IX_Worklist_KeyValue] 
ON [cloudcore].[Worklist] 
(
    [KeyValue] ASC
)
INCLUDE([UserId], [OpenedBy], [StatusTypeId], [ActivityId]);
GO

create TRIGGER [cloudcore].[WorkItemUpdate]
    ON [cloudcore].[Worklist]
    FOR UPDATE
    AS 
begin
   SET NOCOUNT ON
   
   if update(StatusTypeId)
   begin
    
 	  insert into [cloudcore].[ActivityHistory]
 	         (InstanceId, ActivityModelId, Assigned, Activate, Opened, Priority, StatusTypeId, UserId,FlowModelId,PInstanceId) 
      select distinct WL.InstanceId, WL.ActivityModelId, WL.Assigned, WL.Activate, WL.Opened, 0, 99, 0, FM.FlowModelId,WL.PInstanceId
        from [cloudcore].vwWorklist WL
        INNER JOIN cloudcoremodel.ActivityModel AM ON WL.ActivityGuid = AM.ActivityGuid
		INNER JOIN cloudcoremodel.FlowModel FM ON AM.ActivityModelId = FM.FromActivityModelId
        inner join inserted INS on INS.InstanceId = WL.InstanceId
	   where INS.StatusTypeId = 99


	  insert into [cloudcore].[ProcessHistory] (InstanceId, PInstanceId, ProcessModelId, [KeyValue], [Started], StatusId) 
	  select WL.InstanceId, WL.PInstanceId, WL.ProcessModelId, WL.KeyValue, WL.Created, 99
        from [cloudcore].vwWorklist WL
       inner join inserted INS on INS.InstanceId = WL.InstanceId
	   where INS.StatusTypeId = 99

      if exists (select null from DELETED)
	  begin
		  -- To Clean Up Worklist Failure on Retry
		  delete af
		  from [cloudcore].WorklistFailure af
		  inner join deleted del on af.InstanceId = del.InstanceId
		  inner join inserted ins on af.InstanceId = ins.InstanceId
		  where (del.StatusTypeId  = 42 OR del.StatusTypeId = 101) 
                and ins.StatusTypeId = 0

		  update wl
		  set    wl.Retries = 0
		  from  cloudcore.Worklist wl
		  inner join deleted del on wl.InstanceId = del.InstanceId
		  inner join inserted ins on wl.InstanceId = ins.InstanceId
		  where (del.StatusTypeId  = 42 OR del.StatusTypeId = 101)
                and ins.StatusTypeId = 0
	  end

	  -- To Clean Up Worklist Failure on Cancel
	  delete af
	  from [cloudcore].WorklistFailure af
	  inner join inserted ins on af.InstanceId = ins.InstanceId
	  where ins.StatusTypeId = 99
  
    -- now remove the records
	delete WL
       from [cloudcore].Worklist WL
      inner join INSERTED INS
         on INS.InstanceId = WL.InstanceId
      where INS.StatusTypeId = 99
   end
end
GO
CREATE TRIGGER [cloudcore].[CCWorkItemInsert] ON  [cloudcore].[Worklist]
 AFTER INSERT
AS 
BEGIN
  SET NOCOUNT ON
  -- Insert statements for trigger here
  update WL
     set PInstanceId = INS.InstanceId
    from [cloudcore].Worklist WL with (nolock)
   inner join Inserted INS
      on INS.InstanceId = WL.InstanceId
   where INS.PInstanceId = 0
  
  insert into [cloudcore].ProcessHistory ([InstanceId], [PInstanceId], [ProcessModelId], [KeyValue], [Started], [Ended], [StatusId])
      select I.InstanceId, I.PInstanceId, PR.ProcessModelId, I.KeyValue, getdate(), null, 0
        from Inserted I
       inner join [cloudcore].Activity A with (nolock)
          on A.ActivityId = I.ActivityId
       inner join [cloudcoremodel].ProcessRevision PR with (nolock)
          on PR.ProcessRevisionId = A.ProcessRevisionId
END
GO

CREATE TRIGGER [cloudcore].[CCWorkItemDelete]
 on [cloudcore].[Worklist]
for delete
as 
begin
  SET NOCOUNT ON

  update PH
     set Ended = GETDATE(),
	     StatusId = case when D.StatusTypeId = 100 then 100 else 99 end   
    from cloudcore.ProcessHistory PH
   inner join deleted D
      on D.InstanceId = PH.InstanceId

    delete  F
    from    cloudcore.WorklistFailure F
    inner join DELETED D
        on  F.InstanceId = D.InstanceId
end
GO
