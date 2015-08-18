create PROCEDURE [cloudcore].[ActivitySpawn]
@ActivityGuid uniqueidentifier, @KeyValue bigint, @Activate DATETIME=null, @DocWait INT=null, @Priority TINYINT=null, @UserId INT=null, @InstanceId BIGINT OUTPUT
AS
begin
  set nocount on;
  
  -- insert the new item into the worklist
    insert into [cloudcore].Worklist(Activate, Assigned, ActivityId, KeyValue, [Priority], UserId, DocWait, StatusTypeId)
    select isnull(@Activate, GETDATE()), GETDATE(), WA.ActivityId, @KeyValue, ISNULL(@Priority,0), ISNULL(@UserId, 0), ISNULL(@DocWait, AM.DocWait), 0
      from [cloudcore].Activity WA
	 inner join [cloudcoremodel].ActivityModel AM
	    on WA.ActivityModelId = AM.ActivityModelId
     where AM.ActivityGuid = @ActivityGuid
    
    -- get the new Instance ID
    set @InstanceId = SCOPE_IDENTITY()
end