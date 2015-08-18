CREATE PROCEDURE [cloudcore].[STaskSummary]
    @UserId INT,
    @TotalCnt INT OUTPUT
AS
begin
declare @subset table (InstanceId bigint, ActivityModelId int, Archived DateTime, [Days] int not null, UserId int not null)
	declare @period table (InstanceId bigint, ActivityModelId int, Period varchar(8))
	declare @pivot table (ActivityModelId int, PToday int,PWeek int,PMonth int,TToday int,TWeek int,TMonth int)
	declare @t datetime
	declare @d datetime
	set @t = GETDATE()
	set @d = DATEADD(day, -30, getdate())
	
	insert into @subset (InstanceId, ActivityModelId, Archived, [Days], UserId)
    select InstanceId, ActivityModelId, Completed, datediff(day, Completed, GETDATE()) as [Days], UserId
      from [cloudcore].ActivityHistory 
     where Completed between @d and @t
		   
    insert into @period (InstanceId, ActivityModelId, Period)
	select InstanceId, ActivityModelId, 'PToday' Period
		  from @subset
		 where [Days] = 0 and
				UserId = @UserId
		 
	insert into @period (InstanceId, ActivityModelId, Period)
	select InstanceId, ActivityModelId, 'PWeek' Period
		  from @subset
		 where [Days] < 7 and
				UserId = @UserId
		 
	insert into @period (InstanceId, ActivityModelId, Period)
	select InstanceId, ActivityModelId, 'PMonth' Period
		  from @subset
		  where  UserId = @UserId
		  
	insert into @period (InstanceId, ActivityModelId, Period)
	select InstanceId, ActivityModelId, 'TToday' Period
		  from @subset
		 where [Days] = 0 and
				UserId <> @UserId
		 
	insert into @period (InstanceId, ActivityModelId, Period)
	select InstanceId, ActivityModelId, 'TWeek' Period
		  from @subset
		 where [Days] < 7 and
				UserId <> @UserId
		 
	insert into @period (InstanceId, ActivityModelId, Period)
	select InstanceId, ActivityModelId, 'TMonth' Period
		  from @subset 
		  where UserId <> @UserId
 
	insert into @pivot		   
	select ActivityModelId,PToday,PWeek,PMonth,TToday,TWeek,TMonth
		from @period
	pivot(count(InstanceId) for Period in (PToday,PWeek,PMonth,TToday,TWeek,TMonth)) as P
	

	set @TotalCnt = isnull((select sum(PMonth) + sum(TMonth) from @pivot),0)

	select t.ActivityModelId, t.ActivityName, 
			PToday, PToday+TToday TToday, PWeek, PWeek+TWeek TWeek, PMonth, PMonth+TMonth TMonth,
			((100 * PToday) / @TotalCnt) PTodayPerc,
			((100 * (TToday+PToday)) / @TotalCnt) TTodayPerc,
			((100 * TToday) / @TotalCnt) RTodayPerc,
			((100 * PWeek) / @TotalCnt) PWeekPerc,
			((100 * (TWeek+PWeek)) / @TotalCnt) TWeekPerc,
			((100 * TWeek) / @TotalCnt) RWeekPerc,
			((100 * PMonth) / @TotalCnt) PMonthPerc,
			((100 * (PMonth+TMonth)) / @TotalCnt) TMonthPerc,
			((100 * TMonth) / @TotalCnt) RMonthPerc
	from @pivot p
		inner join [cloudcoremodel].ActivityModel t on p.ActivityModelId = t.ActivityModelId
end
