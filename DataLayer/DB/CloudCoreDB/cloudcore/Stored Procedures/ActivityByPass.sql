create procedure [cloudcore].[ActivityByPass]
-- ===================================================================
-- Author:		AHM for CloudCore
-- Description:	Engine that will start the Activity with existing Outcome
-- ===================================================================
@ActivityGuid uniqueidentifier,
@KeyValue bigint
as
begin
    declare @ActivityName varchar(50)
    declare @InstanceId bigint
    declare @GotoWorklist bit
    declare @ActivityId int
    
   begin transaction
   begin try

      select @ActivityId = BA.ActivityId  
        from [cloudcore].Activity BA
        where BA.ActivityGuid = @ActivityGuid

      insert into [cloudcore].Worklist(Activate, Assigned, ActivityId, [Priority], KeyValue, UserId, DocWait, StatusTypeId, Opened, OpenedBy)
      select GETDATE(), GETDATE(), @ActivityId,  0, @KeyValue, 0, AM.DocWait, 1, GETDATE(), 0
       from [cloudcore].Activity BA
      inner join [cloudcoremodel].ActivityModel AM
         on AM.ActivityModelId = BA.ActivityModelId
      where ActivityId = @ActivityId and AM.Startable = 1
       
       -- get the new Instance ID
      set @InstanceId = SCOPE_IDENTITY()

      exec [cloudcore].WorkItemFlow @InstanceId   = @InstanceId, 
                                    @UserId       = 0
       
       update [cloudcore].Worklist 
          set StatusTypeId = 0
        where InstanceId = @InstanceId 
            
      commit transaction
   end try
   begin catch
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