create view [cloudcoremodel].[vwProcessModel]
as
select pm.ProcessModelId, pm.ProcessGuid, pm.ProcessName, pr.ProcessRevisionId, pr.ManagerId,
	   pr.ProcessRevision, pr.UserId, sp.SubProcessId, sp.SubProcessGuid, sp.SubProcessName,
	   am.ActivityModelId, am.ActivityGuid, am.ActivityName, pr.[CheckSum], pr.Changed
  from [cloudcoremodel].ProcessModel pm
 inner join [cloudcoremodel].ProcessRevision pr
    on pm.ProcessModelId = pr.ProcessModelId 
 inner join [cloudcoremodel].SubProcess sp
    on sp.ProcessRevisionId = pr.ProcessRevisionId
 inner join [cloudcoremodel].ActivityModel am
    on am.SubProcessId = sp.SubProcessId