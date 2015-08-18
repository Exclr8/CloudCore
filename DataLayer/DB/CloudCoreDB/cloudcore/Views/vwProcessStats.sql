create view [cloudcore].[vwProcessStats]
as
 select a.ProcessRevisionId, st.StatusTypeName [Status], COUNT(InstanceId) as cnt
  from [cloudcore].Worklist w
 inner join [cloudcore].Activity a on w.ActivityId = a.ActivityId
 inner join [cloudcoremodel].StatusType st on st.StatusTypeId = w.StatusTypeId
 group by a.ProcessRevisionId, st.StatusTypeName