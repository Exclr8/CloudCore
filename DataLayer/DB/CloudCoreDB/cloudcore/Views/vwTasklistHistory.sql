CREATE VIEW [cloudcore].[vwTasklistHistory]
AS
select fh.PInstanceId InstanceId, fh.Completed, case when fh.UserId = 0 then 'The System' else U.NFullname end + ' ' + fm.Storyline Storyline
  from [cloudcore].[ActivityHistory] fh
  inner join [cloudcoremodel].FlowModel fm 
     on fm.FlowModelId = fh.FlowModelId
  inner join [cloudcore].[User] U on U.UserId = fh.UserId