create PROCEDURE [cloudcore].[WorkItemDelay]
@InstanceId BigInt,
@ReactivateAt DateTime
AS
begin
   -- delay the workitem
   update [cloudcore].Worklist 
      set Activate = @ReactivateAt,
          StatusTypeId = 0
    where InstanceId = @InstanceId
end