create PROCEDURE [cloudcore].[WorkItemStartByActivity]
    @UserId INT, 
	@ActivityId int,
	@InstanceId bigint OUTPUT,
	@KeyValue bigint OUTPUT, 
    @ActivityGuid uniqueidentifier OUTPUT, 
    @SubProcessGuid uniqueidentifier OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    declare @Now DATETIME

    SET @Now = GETDATE()

    declare @Data table
    (
        InstanceId      bigint,
        KeyValue        bigint,
        ActivityId      int
    )

    UPDATE  Top (1) wl
    SET     wl.StatusTypeId = 1,
            wl.OpenedBy = @UserId,
            wl.Opened = @Now
    OUTPUT  INSERTED.InstanceId,
            INSERTED.KeyValue,
            INSERTED.ActivityId
    INTO    @Data (InstanceId, KeyValue, ActivityId)
    FROM    cloudcore.Worklist wl WITH (ROWLOCK, READPAST, UPDLOCK, INDEX(IX_Worklist_Priority_Activate)) 
	inner join vwActivityAllocationPriority AAP
	     on AAP.ActivityId = wl.ActivityId
		and AAP.UserId = @UserId
    WHERE  wl.Activate < @Now 
      AND AAP.ActivityTypeId = 0
	  AND AAP.ActivityId = @ActivityId
      AND ((wl.StatusTypeId = 3 AND (wl.UserId = @UserId)) OR (wl.StatusTypeId = 0))


    SELECT  @InstanceId = wl.InstanceId, 
            @KeyValue = wl.KeyValue, 
            @ActivityId = p.ActivityId,
            @ActivityGuid = p.ActivityGuid,
            @SubProcessGuid = p.SubProcessGuid
    FROM    @Data wl
    INNER JOIN cloudcoremodel.vwLiveProcess p WITH (NOLOCK)
        ON  wl.ActivityId = p.ActivityId
    inner join cloudcoremodel.vwLiveActivity a
        on p.ActivityId = p.ActivityId
	inner join cloudcore.SystemModule SM with (nolock)
	    on a.SystemModuleId = SM.SystemModuleId	   
end
