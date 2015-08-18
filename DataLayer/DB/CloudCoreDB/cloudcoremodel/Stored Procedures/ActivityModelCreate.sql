create procedure [cloudcoremodel].[ActivityModelCreate]
    @ProcessRevisionId int, 
    @ReplacementId int, 
    @ActivityGuid uniqueidentifier, 
    @ActivityName varchar(50), 
    @ActivityTypeId tinyint, 
    @SubProcessGuid uniqueidentifier,
    @Startable bit,
    @Priority tinyint,
    @DocWait bit,
	@OnlyVisibleAtLocation bit,
    @LocationRadius int
as
begin
    declare @ActivityModelID int,
            @SubProcessId int
            
    select @SubProcessId = SubProcessId
      from cloudcoremodel.SubProcess
     where SubProcessGuid = @SubProcessGuid

    insert into [cloudcoremodel].ActivityModel(ProcessRevisionId, ReplacementId, ActivityGuid, ActivityName, ActivityTypeId, Startable, [Priority], DocWait, OnlyVisibleAtLocation, LocationRadius, SubProcessId)
    values(@ProcessRevisionId, 0, @ActivityGuid, @ActivityName, @ActivityTypeId, @Startable, @Priority, @DocWait, @OnlyVisibleAtLocation, @LocationRadius, @SubProcessId)

    set @ActivityModelID = SCOPE_IDENTITY()

    update [cloudcoremodel].ActivityModel 
    set ReplacementId = @ActivityModelID
    where ActivityModelId = @ReplacementId

    return @ActivityModelID
end