CREATE PROCEDURE [cloudcore].[ScheduledTaskKeepAlive]
    @ScheduledTaskId int
AS
BEGIN
    update  S
    set     S.KeepAliveDate = getdate()
    from    cloudcore.ScheduledTask S
    where   S.ScheduledTaskId = @ScheduledTaskId
END
