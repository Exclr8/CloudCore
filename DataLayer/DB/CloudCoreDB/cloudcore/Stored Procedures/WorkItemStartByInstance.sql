create PROCEDURE [cloudcore].[WorkItemStartByInstance]
    @UserId INT, 
	@InstanceId bigint,
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
	inner join cloudcore.Activity AAP with (nolock)
	     on AAP.ActivityId = wl.ActivityId
    WHERE wl.InstanceId = @InstanceId
	  and  wl.Activate <= @Now 
      AND AAP.ActivityTypeId = 0
      AND ((wl.StatusTypeId = 3 AND (wl.UserId = @UserId)) OR (wl.StatusTypeId = 0) OR (wl.StatusTypeId = 1 AND (wl.OpenedBy = @UserId)))


    SELECT  @KeyValue = wl.KeyValue, @SubProcessGuid = p.SubProcessGuid,
            @ActivityGuid = p.ActivityGuid
    FROM    @Data wl
    INNER JOIN cloudcore.Activity p WITH (NOLOCK)
        ON  wl.ActivityId = p.ActivityId
	inner join cloudcore.SystemModule SM with (nolock)
	    on p.SystemModuleId = SM.SystemModuleId
	   
end