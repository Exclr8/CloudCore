CREATE PROCEDURE [cloudcore].[SProcessDailyStats]
	@ProcessModelId int
as

declare @tTable table
(
	dte datetime,
	wd int,
	wk int
)

declare @wk int = datepart(week, getdate())
declare @dte datetime = dateadd(weekday, 7 - datepart(weekday, getdate()), getdate())

declare @i int = 0
while @i >= - 13
begin
	declare @tdte datetime = dateadd(day, @i, @dte)
	insert into @tTable (dte, wd, wk) values (@tdte, datepart(weekday, @tdte), datepart(week, @tdte))
	set @i = @i - 1
end

select p.ProcessModelId, datename(weekday, t.dte) [Weekday], t.wk % 2 [Week], t.dte Finished, count(distinct th.InstanceId) Completed
  from [cloudcore].vwWorklist p
 cross join @tTable t
  left outer join [cloudcore].ActivityHistory th on p.ActivityModelId = th.ActivityModelId and convert(date, th.Completed) = t.dte
 where isnull(th.StatusTypeId,100) = 100
   and (Completed is null or cast(convert(varchar(10), Completed, 120) as datetime) >= dateadd(day, -14, getdate()))
   and isnull(p.ProcessModelId,@ProcessModelId) = @ProcessModelId
 group by  datename(weekday, t.dte), t.wk, t.dte, p.ProcessModelId
 order by t.dte
