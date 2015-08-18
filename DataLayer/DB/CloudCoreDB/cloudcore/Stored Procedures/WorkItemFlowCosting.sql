CREATE PROCEDURE [cloudcore].[WorkItemFlowCosting]
@ActivityModelId int,
@InstanceId bigint,
@Cost money
as
begin
  -- add the calculated cost to the database
  insert into [cloudcore].CostLedger (InstanceId, ActivityModelId, Cost, PeriodSeq)
       values (@InstanceId, @ActivityModelId, @Cost, [cloudcore].[Period_Get](GETDATE()))					
end