create view [cloudcore].[vwProcessDailyStats]
as
  select null snoo
/*
select  ProcessID, CONVERT(date, Archived) Finished, count(distinct awf.InstanceId) Completed, awf.UserId
from [cloudcore].ArcWorkFlow awf
inner join [cloudcore].Activity fromAct on awf.FromActivity = fromAct.ActivityId
inner join [cloudcore].Activity toAct on awf.ToActivity = toAct.ActivityId
inner join [cloudcore].ArcWorkItem awi on awf.InstanceId = awi.InstanceId
inner join [cloudcore].Task t on fromAct.TaskID = t.TaskID
where fromAct.TaskID <> toAct.TaskID
  and awi.StatusID = 100
group by CONVERT(date, awf.Archived), t.ProcessID, awf.UserId
*/