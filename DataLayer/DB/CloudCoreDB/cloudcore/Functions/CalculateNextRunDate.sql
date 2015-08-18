create function [cloudcore].CalculateNextRunDate(@InitDate datetime,	@IntervalType tinyint, @IntervalValue int)
returns datetime
as
begin
	/*
		1= Montly
		2=Weekly
		3=Daily
		4=Hourly
		5=Minutes
	*/
	declare @Now datetime = getdate(),
	        @Range int = 10000,
			@ReturnDate datetime = dateadd(day, -1, @InitDate)
		 
    while (@ReturnDate <= @Now)
    begin
	        select @ReturnDate = min(ReturnDate)
			from 
			(select case @IntervalType
						when 1 then DATEADD(Month, @IntervalValue * ST.ZeroBased, @InitDate)
						when 2 then DATEADD(WEEK, @IntervalValue * ST.ZeroBased, @InitDate)
						when 3 then DATEADD(DAY, @IntervalValue * ST.ZeroBased, @InitDate)
						when 4 then DATEADD(HOUR, @IntervalValue * ST.ZeroBased, @InitDate)
						when 5 then DATEADD(MINUTE, @IntervalValue * ST.ZeroBased, @InitDate)
						else DATEADD(SECOND, @IntervalValue * ST.ZeroBased, @InitDate)
					end ReturnDate, ZeroBased
			from cloudcore.SystemTally ST
			where ST.ZeroBased <= @Range) NR
			where (ReturnDate > @Now) or (ZeroBased = @Range)
			set @InitDate = @ReturnDate
	end
	
	return @ReturnDate
end