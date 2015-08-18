CREATE PROCEDURE [cloudcore].[ScheduledTaskDeploy]
    @ScheduledTaskGroupGuid uniqueidentifier, 
    @ScheduledTaskGuid uniqueidentifier,
    @ScheduledTaskName varchar(50),
    @ScheduledTaskTypeId tinyint,
    @SystemModuleId int,
    @IntervalType tinyint,
    @IntervalValue int,
    @StartDate datetime,
    @ScheduledTaskId int = NULL out
AS
BEGIN	
    set @ScheduledTaskId = (select  ScheduledTaskId
                            from    cloudcore.ScheduledTask
                            where   ScheduledTaskGuid = @ScheduledTaskGuid)

    declare @ScheduledTaskGroupId int

    select  @ScheduledTaskGroupId = G.ScheduledTaskGroupId
    from    cloudcore.ScheduledTaskGroup G
    where   G.ScheduledTaskGroupGuid = @ScheduledTaskGroupGuid

    if @ScheduledTaskId is not NULL
    begin
        update  S
        set     S.ScheduledTaskGroupId = @ScheduledTaskGroupId,
                S.ScheduledTaskName = @ScheduledTaskName,
                S.ScheduledTaskTypeId = @ScheduledTaskTypeId
        from    cloudcore.ScheduledTask S
        where   S.ScheduledTaskGuid = @ScheduledTaskGuid
    end
    else
    begin
        
        if @ScheduledTaskTypeId = 1
        begin
            -- TODO: Should we raise an error if the ActionLibrary does not exist in SystemModule ???
            select  @SystemModuleId = isnull(ActionMod.SystemModuleId, @SystemModuleId)
            from    cloudcore.SystemModule WebMod
            left join cloudcore.SystemModule ActionMod
                on  WebMod.AssemblyName = WebMod.AssemblyName + '.ActionLibrary'
            where   WebMod.SystemModuleId = @SystemModuleId
        end

        insert into cloudcore.ScheduledTask (ScheduledTaskGroupId, ScheduledTaskGuid, ScheduledTaskName, ScheduledTaskTypeId, SystemModuleId, IntervalType, IntervalValue, Active, NextRunDate, InitDate, StatusId)
            values (@ScheduledTaskGroupId, @ScheduledTaskGuid, @ScheduledTaskName, @ScheduledTaskTypeId, @SystemModuleId, @IntervalType, @IntervalValue, 0, @StartDate, @StartDate, 0)

        set @ScheduledTaskGroupId = SCOPE_IDENTITY()
    end
END