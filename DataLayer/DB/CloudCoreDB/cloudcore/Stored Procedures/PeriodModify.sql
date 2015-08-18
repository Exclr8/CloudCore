CREATE PROCEDURE [cloudcore].[PeriodModify]
    @PeriodSeq Int,
	@StartDate DateTime,
	@EndDate DateTime,
	@PeriodMonth Int,
	@PeriodYear Int
as
begin
	
	if exists (select null 
                from [cloudcore].Period 
               where @StartDate between StartDate and EndDate
				 and PeriodSeq <> @PeriodSeq)
		begin
		      raiserror(N'The start date cannot be within another financial period', 18, 1)
		end 
	
	  update [cloudcore].Period 
		 set StartDate = @StartDate,
			 EndDate = @EndDate,
			 PeriodMonth = @PeriodMonth,
			 PeriodYear = @PeriodYear
	   where PeriodSeq = @PeriodSeq
		   
end