create procedure [cloudcore].[ActivityStart]
-- ===================================================================
-- Author:		AHM for CloudCore
-- Description:	Engine that will create & start the Activity
-- ===================================================================
@ActivityGuid uniqueidentifier,
@KeyValue bigint,
@UserId int,
@InstanceId bigint output
as
begin
   declare @ActivityName varchar(255),
           @ActivityGuidStr varchar(38)
   
   begin transaction
   begin try
      if not exists(select null from [cloudcoremodel].vwLiveActivity LA where LA.ActivityGuid = @ActivityGuid)
      begin
         set @ActivityGuidStr = convert(varchar(38), @ActivityGuid)
         
         raiserror(N'Activity with unique identifier "%s" does not exist.', 18,1, @ActivityGuidStr)
      end
      
      if not exists(select null from [cloudcoremodel].vwLiveActivity LA where LA.ActivityGuid = @ActivityGuid and LA.Startable = 1)
      begin
        select @ActivityName = ActivityName
          from cloudcoremodel.ActivityModel
         where ActivityGuid = @ActivityGuid
        
         raiserror(N'Activity %d is not startable.', 18,1, @ActivityName)
      end

      insert into [cloudcore].Worklist(Activate, Assigned, ActivityId, [Priority], KeyValue, UserId, DocWait, StatusTypeId, OpenedBy, Opened)
      select GETDATE(), GETDATE(), BA.ActivityId, BA.[Priority], @KeyValue, 0, BA.DocWait, case when BA.ActivityTypeId = 0 then 1 else 0 end, @UserId, GETDATE()
       from [cloudcoremodel].vwLiveActivity BA
      where BA.ActivityGuid = @ActivityGuid and BA.Startable = 1
       
       -- get the new Instance ID
      set @InstanceId = SCOPE_IDENTITY()
            
      commit transaction
   end try
   begin catch
      set @InstanceId = null
      if (XACT_STATE()<>0)
      begin
         print 'Transaction Rollback occured'
         rollback transaction
      end
      
      declare @MSG varchar(1000)
      set @MSG = error_message()
      --Throw exception to calling SP
      raiserror(@MSG, 16, 1) 
   end catch
end
