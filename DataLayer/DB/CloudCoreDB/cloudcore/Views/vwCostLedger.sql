CREATE VIEW [cloudcore].[vwCostLedger]
	AS

select cl.LedgerID, cl.TransDate, cl.Cost, pm.ProcessModelId, pm.ProcessName,
	   tm.SubProcessId, tm.SubProcessName
  from [cloudcore].CostLedger cl
 inner join [cloudcoremodel].ActivityModel am on am.ActivityModelId = cl.ActivityModelId
 inner join [cloudcoremodel].SubProcess tm on am.SubProcessId = tm.SubProcessId
 inner join [cloudcoremodel].ProcessRevision pr on tm.ProcessRevisionId = pr.ProcessRevisionId
 inner join [cloudcoremodel].ProcessModel pm on pr.ProcessModelId = pm.ProcessModelId