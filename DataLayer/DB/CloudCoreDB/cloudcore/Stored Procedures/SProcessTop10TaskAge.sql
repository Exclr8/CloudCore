CREATE PROCEDURE [cloudcore].[SProcessTop10TaskAge]
	@ProcessModelId int
as

select top 5 LP.ActivityModelId, LP.ActivityName, AVG(DATEDIFF(minute, Assigned, Completed)) Age
  from [cloudcore].ActivityHistory th
 inner join [cloudcoremodel].vwLiveProcess LP on LP.ActivityModelId = TH.ActivityModelId
 where DATEPART(week, getdate()) = DATEPART(week, Completed)
   and LP.ProcessModelId = @ProcessModelId
 group by LP.ActivityModelId, LP.ActivityName
 order by AVG(DATEDIFF(minute, Assigned, Completed)) desc