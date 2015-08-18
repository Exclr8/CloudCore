CREATE PROCEDURE [cloudcore].[WorkItemFail]
	@InstanceId bigint,
	@Reason varchar(max),
	@StatusTypeId tinyint
as
  begin
	
	if (@StatusTypeId not in (42, 101))
	begin
		raiserror('Invalid status type specified for work list failure update. Allowed values are: 42 (Retry) and 101 (Failed).', 16 ,1)
		return
	end
	
	insert into cloudcore.WorklistFailure(InstanceId, KeyValue, UserId, ActivityId, Reason)
	    select @InstanceId, WL.KeyValue, WL.UserId, WL.ActivityId, @Reason
	      from cloudcore.Worklist WL
	     where WL.InstanceId = @InstanceId

	if (@@ROWCOUNT > 0)
	  begin
		update W
		   set StatusTypeId = @StatusTypeId,
			   Activate = CASE WHEN @StatusTypeId = 42
						  THEN dateadd(second,AV.RetryDelayInSeconds, Getdate())
						  ELSE Activate						  
						  END
		   from cloudcore.Worklist as W 
		   inner join cloudcoremodel.vwLiveActivity as AV 
			  on AV.ActivityId = W.ActivityId  
		 where InstanceId = @InstanceId
	  end
  end