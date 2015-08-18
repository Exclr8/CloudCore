create function cloudcore.CalculateNextInitDate(@InitDate datetime,	@IntervalType tinyint, @IntervalValue int)
returns datetime
as
begin
    declare @Now datetime = getdate(),
            @ReturnDate datetime = [cloudcore].CalculateNextRunDate(@InitDate, @IntervalType, @IntervalValue)
         
         
         return case @IntervalType
                        when 1 then DATEADD(Month, -@IntervalValue, @ReturnDate)
                        when 2 then DATEADD(WEEK, -@IntervalValue, @ReturnDate)
                        when 3 then DATEADD(DAY, -@IntervalValue, @ReturnDate)
                        when 4 then DATEADD(HOUR, -@IntervalValue, @ReturnDate)
                        when 5 then DATEADD(MINUTE, -@IntervalValue, @ReturnDate)
                        else DATEADD(SECOND, -@IntervalValue, @ReturnDate)
                    end
end