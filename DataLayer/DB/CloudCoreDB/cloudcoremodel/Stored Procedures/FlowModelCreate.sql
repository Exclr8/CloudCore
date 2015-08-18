CREATE procedure [cloudcoremodel].[FlowModelCreate]
    @FlowGuid uniqueidentifier,
    @ProcessRevisionId int,
    @FromActivityModelId int,
    @Outcome varchar(50),
    @ToActivityModelId int,
    @OptimalFlow bit,
    @NegativeFlow bit,
    @Storyline varchar(200)
as
begin

    insert into [cloudcoremodel].FlowModel(FlowGuid, ProcessRevisionId, FromActivityModelId, Outcome, ToActivityModelId, OptimalFlow, NegativeFlow, Storyline)  
    values(@FlowGuid, @ProcessRevisionId, @FromActivityModelId, @Outcome, @ToActivityModelId, @OptimalFlow, @NegativeFlow, @Storyline)  
       
    return SCOPE_IDENTITY()  

end
GO

