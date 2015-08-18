CREATE PROCEDURE [cloudcore].[ScheduledTaskGroupDeploy]
    @Guid uniqueidentifier,
    @GroupName varchar(50),
	@SystemModuleId int,
    @ScheduledTaskGroupId int = NULL out
AS
BEGIN
    set @ScheduledTaskGroupId = (select  ScheduledTaskGroupId
                                 from    cloudcore.ScheduledTaskGroup
                                 where   ScheduledTaskGroupGuid = @Guid)

    if @ScheduledTaskGroupId is not NULL
    begin
        update  G
        set     G.ScheduledTaskGroupName = @GroupName
        from    cloudcore.ScheduledTaskGroup G
        where   G.ScheduledTaskGroupGuid = @Guid
    end
    else
    begin
        insert into cloudcore.ScheduledTaskGroup (ScheduledTaskGroupGuid, ScheduledTaskGroupName, SystemModuleId)
            values (@Guid, @GroupName, @SystemModuleId)

        set @ScheduledTaskGroupId = SCOPE_IDENTITY()
    end
END