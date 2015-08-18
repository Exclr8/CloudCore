CREATE PROCEDURE [cloudcore].[WorkflowKeepAlive]
    @InstanceId bigint
AS
BEGIN
    update  W
    set     W.KeepAliveDate = getdate()
    from    cloudcore.Worklist W
    where   W.InstanceId = @InstanceId
END
