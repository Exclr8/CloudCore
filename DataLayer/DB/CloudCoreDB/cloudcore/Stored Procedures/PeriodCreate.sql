CREATE PROCEDURE [cloudcore].[PeriodCreate]
	@StartDate DateTime,
	@EndDate DateTime,
	@PeriodMonth Int,
	@PeriodYear Int
as
begin
	
	if exists (select null 
                from [cloudcore].Period 
               where @StartDate between StartDate and EndDate)
		begin
		      raiserror(N'The start date cannot be within another financial period', 18, 1)
		      return
		end 

	insert into [cloudcore].Period (StartDate, EndDate, PeriodMonth, PeriodYear)
				  values (@StartDate, @EndDate, @PeriodMonth, @PeriodYear)
end