CREATE procedure [cloudcore].[WorkItemFlow]
-- ===================================================================
-- Author:		AHM for CloudCore
-- Description:	Engine that will shift the Activity based on Outcome
-- ===================================================================
@InstanceId bigint,
@UserId int,
@Outcome varchar(50) = null
as
declare @ActivityTypeId int
declare @FromActivityId int
declare @ToActivityId int
declare @PInstanceId bigint
declare @ToDocWait bit
declare @KeyValue bigint
declare @FlowModelId int
begin
  begin transaction
  begin try
         
        -- get the additional data needed throughout the move
        declare @InstanceAndOutcomes table
            (
                ActivityId int,
                ToActivityId int,
                PInstanceId bigint,
                DocWait bit,
                KeyValue bigint,
                FlowModelId int,
                ActivityTypeId tinyint,
                Outcome varchar(50) not null default('-')
            )

        insert into @InstanceAndOutcomes (ActivityId, ToActivityId, PInstanceId, DocWait, KeyValue, FlowModelId, ActivityTypeId, Outcome)
            select  WL.ActivityId, 
                    FM.ToActivityId, 
                    WL.PInstanceId, 
                    AMT.DocWait,
                    WL.KeyValue,
                    FM.FlowModelId, 
                    AMT.ActivityTypeId,
                    isnull(FM.Outcome, '-') as Outcome
              from  [cloudcore].Worklist WL with (nolock)
             inner join [cloudcore].Activity A with (nolock)
                on  A.ActivityId = WL.ActivityId
             inner join [cloudcoremodel].vwLiveFlow FM
                on  FM.FromActivityId = A.ActivityId
             inner join [cloudcoremodel].ActivityModel AMT with (nolock)
                on  AMT.ActivityModelId = FM.ToActivityModelId
             where  WL.InstanceId = @InstanceId
             
        if (@@ROWCOUNT <= 0)
        begin
            raiserror ('There was an error selecting the data for the flow of workitem %I64d', 16, 1, @InstanceId)  
            return
        end

        select  @FromActivityId = ActivityId, 
                @PInstanceId = PInstanceId, 
                @ToDocWait = DocWait,
                @KeyValue = KeyValue,
                @ActivityTypeId = ActivityTypeId
        from    @InstanceAndOutcomes

        select  @ToActivityId = ToActivityId, 
                @FlowModelId = FlowModelId
        from    @InstanceAndOutcomes
        where   ((Outcome = isnull(@Outcome, '-')) or ((isnull(Outcome, '-') = '-') and (isnull(@Outcome, '-') = '-')))

        -- check the outcome
        if @ToActivityId is null
        begin
            raiserror ('The activity %d does not have an outcome of %s.', 16, 1, @FromActivityId, @Outcome) 
            return
        end
        
        -- update the history  
        insert into [cloudcore].[ActivityHistory](InstanceId, PInstanceId, ActivityModelId, FlowModelId, Assigned, Activate, Opened, [Priority], StatusTypeId, UserId)
                                          select  InstanceId, PInstanceId, ActivityModelId, @FlowModelId, Assigned, Activate, Opened,  [Priority], 100, @UserId from vwWorklist WL where WL.InstanceId = @InstanceId
    
    -- move the activity
    if (@ToActivityId <> 0)
    begin
      -- move task & activity
      update WL 
         set ActivityId = @ToActivityId,
             DocWait = @ToDocWait,
             StatusTypeId = case when WL.UserId <> 0 then 3 else 0 end, -- keep it allocated if it is
             OpenedBy = 0,
             Assigned = GETDATE()
        from [cloudcore].Worklist WL
      where WL.InstanceId = @InstanceId

      -- Release if to Activity is Page
      update WL 
         set UserId = case when @ActivityTypeId = 0 then 0 else UserId end,
             StatusTypeId = case when @ActivityTypeId = 0 then 0 else StatusTypeId end
        from [cloudcore].Worklist WL
       where WL.InstanceId = @InstanceId
    end
    
    exec [cloudcore].CampaignItemFinish @InstanceId, @UserId	
    if (@ToActivityId = 0)
    begin

      -- if this is the end then remove the item from the worklist  
      update Worklist set StatusTypeId = 100 where InstanceId = @InstanceId
      delete from [cloudcore].Worklist where InstanceId = @InstanceId 
    end
        

    commit transaction    
  end try
  begin catch
    if (XACT_STATE()<>0)
    begin
      print 'Transaction rollback occured'
      rollback transaction
    end
    
   --Throw exception to calling SP
    declare @MSG varchar(1000)
    set @MSG = error_message()
    raiserror ('Error in Flow Navigation for this item - %s', 16, 1, @MSG) 
  end catch

end
GO

